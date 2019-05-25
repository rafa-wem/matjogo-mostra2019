using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime, endPeriod;
    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        endPeriod = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(finished)
            return;

        float t = Time.time - startTime;
        float remainingTime = endPeriod - t;
        string minutes = ((int) remainingTime/60).ToString();
        string seconds = (remainingTime % 60).ToString("f2");

        if(remainingTime < 0) {
            finished = true;
            GameObject.Find("Sphere").SendMessage("Finish");
            minutes = "0";
            seconds = "0.00";
        }

        timerText.text = minutes + ":" + seconds;
    }

    public void Finish() {
        finished = true;
        GameObject.Find("Sphere").SendMessage("Finish");
        timerText.color = Color.yellow;
    }
}
