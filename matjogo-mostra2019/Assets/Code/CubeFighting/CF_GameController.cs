using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Diagnostics;

public class CF_GameController : MonoBehaviour
{
    public GameObject agent;
    public GameObject bullet;

    public Vector3 spawnOffset;
    public float spawnRadius;
    public float bulletKillRadius;
    
    public int sampleAlive;

    public int sampleCount;
    public float maxIterationTime;
    public float cunningSize; // Best percentage of generation that survives
	private int _offspringSize;
	private int _roundSize = 5;
	private float crossoverMethod1Prob = 0.5f;

    private int _myIterationCount;
    private float _myIterationStartTime;
    private Agent[] _myAgents;
	private List<float[]> _offspring = new List<float[]>();
    GameObject _myCanvasObject;

    // Start is called before the first frame update
    void Start()
    {
        _myCanvasObject = GameObject.Find("Canvas");
        _myAgents = new Agent[sampleCount];
        _myIterationCount = 1;
		_offspringSize = sampleCount - (int)(sampleCount*cunningSize);
        FirstIteration();
    }

    void Update()
    {
		UnityEngine.Debug.Log ("ALIVE: " + sampleAlive);
		//UnityEngine.Debug.Log (Time.timeSinceLevelLoad - _myIterationStartTime);
		if(sampleAlive == 195)// || Time.timeSinceLevelLoad - _myIterationStartTime > maxIterationTime)
        {
            Reproduction();
			UnityEngine.Debug.Log ("OFF COUNT:" + _offspring.Count);
			int startRepopulationPos = Cunning();
			UnityEngine.Debug.Log ("STAR REP POS: " + startRepopulationPos+1);
			StartIteration(startRepopulationPos+1);
        }
    }

    void FirstIteration()
    {
        GameObject go;
        Vector3 p;
        for(int i = 0; i < sampleCount; i++)
        {
			p = UnityEngine.Random.insideUnitCircle * spawnRadius;
            p = p + spawnOffset;
            go = GameObject.Instantiate(agent, p, Quaternion.identity);

            go.transform.SetParent(_myCanvasObject.transform);

            _myAgents[i] = go.GetComponent<Agent>();
            _myAgents[i].Initialize(
				UnityEngine.Random.Range(10.0f, 100.0f) //Vision
				, UnityEngine.Random.Range(50.0f, 100.0f) //Movespeed
				, UnityEngine.Random.Range(1.0f, 5.0f) //FireRate
				, UnityEngine.Random.Range(75.0f, 200.0f) //FireBulletSpeed
				, UnityEngine.Random.Range(1.0f, 50.0f) //FireDamage
				, UnityEngine.Random.Range(0.0f, 10.0f) //FireDuration
				, UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f) //Color
				, UnityEngine.Random.Range(0.0f, 1.0f) //Prob chase
				, UnityEngine.Random.Range(0.0f, 1.0f) //Prob dodge bullet
				, UnityEngine.Random.Range(0.0f, 1.0f) //Prob random shoot
				, UnityEngine.Random.Range(0.0f, 1.0f) //Prob random move
                            );

            go.name = "IT_" + _myIterationCount + "_Agent" + i;

        }
        sampleAlive = sampleCount;
        _myIterationStartTime = Time.timeSinceLevelLoad;
    }

	int Cunning()
    {
		_myAgents.OrderBy(x => x.timeAlive).ThenBy(x => x.killCount);
		int hasToDie = _myAgents.Length - _offspring.Count;
		UnityEngine.Debug.Log ("HAS TO DIE: " + hasToDie);
		int j = _myAgents.Length - 1;
		int died = 0;
		while(died < hasToDie)
		{
			Destroy(_myAgents [j]);
			j--;
			died++;
		}

		return j;
        
    }

	private System.Random rep_random = new System.Random();

    void Reproduction()
    {
		float chooseFirstParent = 0.5f;
		int k = 2; // Number of partitions in k-point crossover;

		_offspring.Clear ();

		int[] parentsIds = Tournament (_offspringSize / 2, _roundSize);
		UnityEngine.Debug.Log ("PAR SIZE: " + parentsIds.Length);
		Tuple<float[], float[]> childrens;

		for(int i = 0; i < _offspringSize/2; i++)
		{
			int id1 = rep_random.Next (parentsIds.Length);
			int id2 = rep_random.Next (parentsIds.Length);
			if (id2 == id1)
				id2 = (id2 + 1) % parentsIds.Length;

			int p1 = parentsIds[id1];
			int p2 = parentsIds[id2];

			if(UnityEngine.Random.Range(0.0f, 1.0f) <= crossoverMethod1Prob)
			{
				childrens = UniformCrossover (_myAgents[p1], _myAgents[p2], chooseFirstParent);
			}
			else
			{
				childrens = KPointCrossover (_myAgents [p1], _myAgents [p2], k);
			}

			_offspring.Add (childrens.Item1);
			_offspring.Add (childrens.Item2);
		}

    }

	void StartIteration(int startRepopulationPos)
    {
		GameObject go;
		Vector3 p;

		for(int i = 0; i < startRepopulationPos; i++){
			_myAgents [i].Refresh ();
		}

		for(int i = startRepopulationPos; i < sampleCount; i++)
		{
			p = UnityEngine.Random.insideUnitCircle * spawnRadius;
			p = p + spawnOffset;
			go = GameObject.Instantiate(agent, p, Quaternion.identity);

			go.transform.SetParent(_myCanvasObject.transform);

			_myAgents[i] = go.GetComponent<Agent>();
			_myAgents[i].Initialize(_offspring[i - startRepopulationPos]);

			go.name = "IT_" + _myIterationCount + "_Agent" + i;

		}

		sampleAlive = sampleCount;
		_myIterationStartTime = Time.timeSinceLevelLoad;
    }

    public float SampleDied()
    {
        sampleAlive--;
        return Time.timeSinceLevelLoad - _myIterationStartTime;
    }

    public void SetVisible(GameObject go)
    {
        go.transform.SetParent(_myCanvasObject.transform);
    }


	#region Selection Methods



	private System.Random random = new System.Random();
	public int[] Tournament(int totalSelected, int roundSize)
	{
		List<int> ids = Enumerable.Range (0, _myAgents.Length).ToList();
		List<Agent> round = new List<Agent> ();
		HashSet<int> sel = new HashSet<int> ();


		for(int k = 0; k < totalSelected; k++)
		{
			round.Clear ();
			for(int i = 0; i < roundSize; i++)
			{	
				int idx = random.Next (ids.Count);
				round.Add (_myAgents[ids[idx]]);
			}

			int bestId = 0;
			float bestTime = round[0].timeAlive;
			int bestKillCount = round[0].killCount;
			for(int i = 1; i < round.Count; i++)
			{
				if(round[i].timeAlive >= bestTime)
				{
					if(round[i].killCount > bestKillCount)
					{
						bestId = i;
						bestTime = round [i].timeAlive;
						bestKillCount = round [i].killCount;
					}
				}
			}

			sel.Add (bestId);
			ids.Remove (bestId);
		}
		return sel.ToArray ();
	}
	#endregion

	#region Reproduction Methods
	//13
	public Tuple<float[], float[]> KPointCrossover(Agent p1, Agent p2, int numberOfPartitions)
	{
		int[] parts = new int[numberOfPartitions];
		int totalProperties = p1.properties.Length;
		float[] offspring1Props = new float[totalProperties]; 
		float[] offspring2Props = new float[totalProperties];

		for(int i = 0; i < numberOfPartitions; i++)
		{
			parts[i] = random.Next();
		}
		int p = 0;
		int isP1 = 1;
		for(int i = 0; i < totalProperties; i++){
			if(i == parts[p]){
				isP1 *= -1;
				p++;
			}
				
			if(isP1 == 1)
			{
				offspring1Props[i] = p1.properties[i];
				offspring2Props[i] = p2.properties[i];
			}
			else
			{
				offspring1Props[i] = p2.properties[i];
				offspring2Props[i] = p1.properties[i];
			}
			
		}

		return new Tuple<float[], float[]> (offspring1Props, offspring2Props);
	}

	public Tuple<float[], float[]> UniformCrossover(Agent p1, Agent p2, float probChooseP1)
	{
		int totalProperties = p1.properties.Length;
		float[] offspring1Props = new float[totalProperties]; 
		float[] offspring2Props = new float[totalProperties];

		for(int i = 0; i < totalProperties; i++){

			if(UnityEngine.Random.Range(0.0f, 1.0f) <= probChooseP1)
			{
				offspring1Props[i] = p1.properties[i];
				offspring2Props[i] = p2.properties[i];
			}
			else
			{
				offspring1Props[i] = p2.properties[i];
				offspring2Props[i] = p1.properties[i];
			}

		}

		return new Tuple<float[], float[]> (offspring1Props, offspring2Props);
	}

	#endregion

}
