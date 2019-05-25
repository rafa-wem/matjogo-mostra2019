﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassifierGameController : MonoBehaviour
{
    public UnityEngine.UI.Text score;
    public UnityEngine.Sprite[] difficulties;
    public GameObject[] classes;
    public Vector3 delta = new Vector3(-212.5f, -212.5f, 0.0f);
    public int sampleCount = 10;
    public int testCount = 10;
    public float spawnWaitTime = 1.0f;

    private int _mySampleCount;
    private List<GameObject> _generatedSamples;
    private GameObject _myCurrentDifficulty;
    private Functions funcObject;
    private int hitTargets = 0;

    private delegate int r2function(float x, float y);
    private r2function f;
    GameObject plotSpace;

    public int difficulty = 0;

    // Start is called before the first frame update
    void Start()
    {
        funcObject = GameObject.Find("<Functions>").GetComponent<Functions>();
        plotSpace = GameObject.Find("<PlotSpace>");
        _myCurrentDifficulty = GameObject.Find("<difficulty>");
        _generatedSamples = new List<GameObject>();
        StartLevel();
    }

    void ResetLevel()
    {
        _mySampleCount = sampleCount;
        hitTargets = 0;

        foreach(GameObject go in _generatedSamples)
        {
            Destroy(go);
        }
    }

    void StartLevel()
    {
        ResetLevel();

        f = funcObject.function1;

        _myCurrentDifficulty.GetComponent<UnityEngine.UI.Image>().sprite = difficulties[difficulty];

        int chosenFunction;

        switch (difficulty)
        {
            case 0:     chosenFunction = Random.Range(1, 5);    break;
            case 1:     chosenFunction = Random.Range(6, 9);    break;
            case 2:     chosenFunction = Random.Range(11, 15);  break;
            default:    chosenFunction = Random.Range(1, 15);   break;
        }

        switch (chosenFunction)
        {
            case 1:  f = funcObject.function1;  break;
            case 2:  f = funcObject.function2;  break;
            case 3:  f = funcObject.function3;  break;
            case 4:  f = funcObject.function4;  break;
            case 5:  f = funcObject.function5;  break;
            case 6:  f = funcObject.function6;  break;
            case 7:  f = funcObject.function7;  break;
            case 8:  f = funcObject.function8;  break;
            case 9:  f = funcObject.function9;  break;
            case 10: f = funcObject.function10; break;
            case 11: f = funcObject.function11; break;
            case 12: f = funcObject.function12; break;
            case 13: f = funcObject.function13; break;
            case 14: f = funcObject.function14; break;
        }

        while (_mySampleCount > 0)
        {
            float x = Random.Range(0.0f, 100.0f);
            float y = Random.Range(0.0f, 100.0f);
            int c = f(x, y);
            GameObject go = GameObject.Instantiate(classes[c], Vector3.zero, Quaternion.identity);
            _generatedSamples.Add(go);
            go.transform.SetParent(plotSpace.transform, false);
            go.transform.localPosition = 4 * new Vector3(x, y, 0.0f) + delta;

            _mySampleCount--;
        }

        _myTestCount = testCount;
        SpawnNewPoint();
    }

    private Vector3 _myTargetPosition;
    private Vector3 _mySpeed;
    private int _myTestCount;
    private int sc, state = -1;
    private GameObject newSample;
    private float sx, sy;
    void Update()
    {
        score.text = "" + 100.0f * ((float)hitTargets / (float)testCount) + "%";

        switch (state)
        {
            case 0: SpawnSample();                                                                                                                      break;
            case 1: classes[0].transform.localPosition = Vector3.SmoothDamp(classes[0].transform.localPosition, _myTargetPosition, ref _mySpeed, 0.3f); break;
            case 2: EndGame();   break;
            case 3: break;
        }

    }

    void SpawnSample()
    {
        sx = Random.Range(0.0f, 100.0f);
        sy = Random.Range(0.0f, 100.0f);
        sc = f(sx, sy);
        
        _myTargetPosition = new Vector3(4 * sx - 200.0f, 4 * sy - 200.0f, 0.0f); 

        state = 1;
    }

    void EndGame()
    {
        difficulty++;
        if (difficulty <= 2)
            Invoke("StartLevel", 2.0f);
        state = 3;
    }

    void SpawnNewPoint()
    {
        if (_myTestCount > 0)
        {
            state = 0;
            _myTestCount--;
        }
        else
        {
            state = 2;
        }
    }

    #region BUTTONS


    public void pressbutton(int i)
    {
        if (sc == i)
        {
            newSample = GameObject.Instantiate(classes[i], Vector3.zero, Quaternion.identity);
            newSample.transform.SetParent(plotSpace.transform, false);
            newSample.transform.localPosition = 4 * new Vector3(sx, sy, 0.0f) + delta;
            hitTargets++;
        }
        else
        {
            newSample = GameObject.Instantiate(classes[i+4], Vector3.zero, Quaternion.identity);
            newSample.transform.SetParent(plotSpace.transform, false);
            newSample.transform.localPosition = 4 * new Vector3(sx, sy, 0.0f) + delta;
        }
        _generatedSamples.Add(newSample);
        Invoke("SpawnNewPoint", spawnWaitTime);
    }

    public void PressClass1()
    {
        pressbutton(1);
    }

    public void PressClass2()
    {
        pressbutton(2);
    }

    public void PressClass3()
    {
        pressbutton(3);
    }

    public void PressClass4()
    {
        pressbutton(4);
    }


    #endregion


}
