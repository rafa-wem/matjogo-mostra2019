using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassifierGameController : MonoBehaviour
{
    private delegate int r2function(float x, float y);

    // Start is called before the first frame update
    void Start()
    {
        Functions funcObject = GameObject.Find("<Functions>").GetComponent<Functions>();
        int chosenFunction = Random.Range(1, 14);
        r2function f;
        switch(chosenFunction)
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


    }

    // Update is called once per frame
    void Update()
    {

    }
}
