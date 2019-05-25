using System.Collections;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object
    public float smoothSpeed = 0.125f;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    public float distanceBack = 6f;
    // Use this for initialization
    void Start ()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate ()
    {
        RaycastHit raydata;
        if(Physics.Raycast(player.transform.position, -Vector3.up, out raydata)){
            Debug.DrawLine(player.transform.position, raydata.point, Color.red);
            Debug.DrawRay(raydata.point, raydata.normal*1000, Color.red);
            Vector3 desiredPosition = player.transform.position + 5*raydata.normal;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed) ;
        } else {
            Debug.DrawRay(transform.position, transform.forward*1000, Color.black);
        //    transform.position = player.transform.position + offset;
        }

        transform.rotation = Quaternion.identity;

        transform.position = player.transform.position - transform.TransformDirection(-Vector3.up * distanceBack);
        transform.LookAt(player.transform);

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //transform.position = player.transform.position + offset;
    }
}
