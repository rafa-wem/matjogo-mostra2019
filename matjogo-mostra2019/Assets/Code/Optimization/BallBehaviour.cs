using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
	private Rigidbody ball;

	private Vector3 direction;

	public float acceleration = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
    	ball.AddForce(acceleration*direction, ForceMode.Force);
    	//ball.AddForce(acceleration*direction, ForceMode.Impulse); // 0.1 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
        	direction.z += 1;
        } else if (Input.GetKey(KeyCode.A)) {
        	direction.x -= 1;
        } else if (Input.GetKey(KeyCode.S)) {
        	direction.z -= 1;
        } else if (Input.GetKey(KeyCode.D)) {
        	direction.x += 1;
        } else {
        	direction = Vector3.zero;
        }

        direction.Normalize();
    }
}
