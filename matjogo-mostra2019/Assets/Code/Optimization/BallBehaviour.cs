using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
	private Rigidbody ball;

	private Vector3 direction;

	private float sideLength = 200.0f;

	public float acceleration = 100f;

    private bool finished = false;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if(finished) return;
    	ball.AddForce(acceleration*direction, ForceMode.Force); // 100/7 acceleration/mass
    	//ball.AddForce(acceleration*direction, ForceMode.Impulse); // 0.1
    }

    // Update is called once per frame
    void Update()
    {
        if(finished) return;

        if(Input.GetKey(KeyCode.W)) {
        	direction.z += 1;
        } else if (Input.GetKey(KeyCode.A)) {
        	direction.x -= 1;
        } else if (Input.GetKey(KeyCode.S)) {
        	direction.z -= 1;
        } else if (Input.GetKey(KeyCode.D)) {
        	direction.x += 1;
        } else if (Input.GetKey(KeyCode.Space)) { // Everyone loves jumping, right? But this is just a test, so let's ignore it for a while
        	direction.y += 3;
        } else {
        	direction = Vector3.zero;
        }

        direction.Normalize();
    }

    public void RandomPosition()
    {
    	Vector3 newPosition = Vector3.zero;
    	newPosition.y = 50;
    	newPosition.x = Random.Range(-sideLength, sideLength);
    	newPosition.z = Random.Range(-sideLength, sideLength);
    	ball.velocity = Vector3.zero;
    	ball.MovePosition(newPosition);
    }

    public void Finish() {
        finished = true;
        ball.velocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;
    }
}
