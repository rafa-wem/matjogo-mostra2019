﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(Random.Range(1, SceneManager.sceneCount));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
