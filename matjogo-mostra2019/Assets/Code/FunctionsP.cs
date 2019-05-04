using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionsP : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	int f3(float x, float y){
		if(y >= x/2.0f && x <= 50.0f){
			return 1;
		}
		else if(y < x/2.0f && y < -x/2.0f + 50.0f){
			return 2;
		}
		else{
			return 3;
		}
	}

	int f4(float x, float y){
		if(Mathf.Sqrt(Mathf.Pow(x - 50.0f, 2.0f) + Mathf.Pow(y - 50.0f, 2.0f)) <= 35.0f){
			return 1;
		}
		else{
			return 2;
		}
	}

	int f6(float x, float y){
		if((y <= -x/2.0f && x < 50.0f) || (y <= x/2.0f + 50.0f && x > 50.0f)){
			return 2;
		}
		else{
			return 1;
		}
	}

	int f8(float x, float y){
		if(y >= 75 || (y >= 25 && y < 50)){
			return 1;
		}
		else{
			return 2;
		}
	}

	int f11(float x, float y){
		if(((Mathf.Pow(x -50.0f, 2)/14.0f) + (Mathf.Pow(y -50.0f, 2)/6.0f)) <= 20.0f){
			return 1;
		}
		else if(((Mathf.Pow(x -50.0f, 2)/14.0f) + (Mathf.Pow(y -50.0f, 2)/6.0f)) <= 80.0f){
			return 2;
		}
		else if(((Mathf.Pow(x -50.0f, 2)/14.0f) + (Mathf.Pow(y -50.0f, 2)/6.0f)) <= 170.0f){
			return 3;
		}
		else if(((Mathf.Pow(x -50.0f, 2)/14.0f) + (Mathf.Pow(y -50.0f, 2)/6.0f)) <= 410.0f){
			return 4;
		}
		else{
			return 1;
		}
	}
}