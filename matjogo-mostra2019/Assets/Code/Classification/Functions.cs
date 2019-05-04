using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        function12(0, 0);
        function12(5, 5);
        function12(50, 50);
        function12(100, 50);
        function13(0, 50);
    }

    // Update is called once per frame
    void Update()
    {

    }

    int function1(float x, float y){return 0;}
    int function2(float x, float y){return 0;}
    int function3(float x, float y){return 0;}
    int function4(float x, float y){return 0;}
    int function5(float x, float y)
    {
        if(x < 100.0f/3.0f || x > 200.0f/3.0f)
          return 1;
        else return 2;
    }
    int function6(float x, float y){ return 0;}
    int function7(float x, float y)
    {
      if(y > Mathf.Sin(x))
        return 1;
      else return 2;
    }
    int function8(float x, float y){return 0;}
    int function9(float x, float y){return 0;}
    int function10(float x, float y){return 0;}
    int function11(float x, float y){return 0;}
    int function12(float x, float y)
    {
        RaycastHit info;
        if (Physics.Raycast(new Vector3(x - 300.0f, y - 100.0f, -20.0f), Vector3.forward, out info))
        {
            Debug.Log(info.collider.gameObject.name);
        }
        return 0;
    }
    int function13(float x, float y)
    {
        RaycastHit info;
        if(Physics.Raycast(new Vector3(x - 100.0f, y - 100.0f, -20.0f), Vector3.forward, out info))
        {
            Debug.Log(info.collider.gameObject.name);
        }
        return 0;
    }
    int function14(float x, float y){return 0;}


}
