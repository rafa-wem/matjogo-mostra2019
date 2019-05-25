using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Random rnd = new Random();
        Application.LoadScene(rnd.Next(1,4));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
