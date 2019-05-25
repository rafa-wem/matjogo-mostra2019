using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(Random.Range(0, SceneManager.sceneCount));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
