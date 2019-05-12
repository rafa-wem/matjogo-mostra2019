using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_GameController : MonoBehaviour
{
    public GameObject agent;
    public GameObject bullet;

    public Vector3 spawnOffset;
    public float spawnRadius;
    public int sampleCount;
    public float maxIterationTime;

    public int sampleAlive;

    private int _myIterationCount;
    private float _myIterationStartTime;
    private Agent[] _myAgents;
    GameObject _myCanvasObject;

    // Start is called before the first frame update
    void Start()
    {
        _myCanvasObject = GameObject.Find("Canvas");
        _myAgents = new Agent[sampleCount];
        _myIterationCount = 1;
        FirstIteration();
    }

    void Update()
    {
        if(sampleAlive == 1 || Time.timeSinceLevelLoad - _myIterationStartTime > maxIterationTime)
        {
            Cunning();
            Reproduction();
            StartIteration();
        }
    }

    void FirstIteration()
    {
        GameObject go;
        Vector3 p;
        for(int i = 0; i < sampleCount; i++)
        {
            p = Random.insideUnitCircle * spawnRadius;
            p = p + spawnOffset;
            go = GameObject.Instantiate(agent, p, Quaternion.identity);

            go.transform.SetParent(_myCanvasObject.transform);

            _myAgents[i] = go.GetComponent<Agent>();
            _myAgents[i].Initialize(Random.Range(10.0f, 100.0f) //Vision
                            , Random.Range(50.0f, 100.0f) //Movespeed
                            , Random.Range(1.0f, 5.0f) //FireRate
                            , Random.Range(75.0f, 200.0f) //FireBulletSpeed
                            , Random.Range(1.0f, 50.0f) //FireDamage
                            , Random.Range(0.0f, 10.0f) //FireDuration
                            , Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f) //Color
                            , Random.Range(0.0f, 1.0f) //Prob chase
                            , Random.Range(0.0f, 1.0f) //Prob dodge bullet
                            , Random.Range(0.0f, 1.0f) //Prob random shoot
                            , Random.Range(0.0f, 1.0f) //Prob random move
                            );

            go.name = "IT_" + _myIterationCount + "_Agent" + i;

        }
        sampleAlive = sampleCount;
        _myIterationStartTime = Time.timeSinceLevelLoad;
    }

    void Cunning()
    {

    }

    void Reproduction()
    {

    }

    void StartIteration()
    {

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
}
