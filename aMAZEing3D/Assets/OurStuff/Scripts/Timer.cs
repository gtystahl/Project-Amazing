using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float elapsedRunningTime = 0f;
    private float runningStartTime = 0f;
    private bool running = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!running)
        {
            runningStartTime = Time.time;
            running = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elaspedRunningTime = Time.time - runningStartTime;
        } 
    }

    public float GetOverallTime()
    {
        return elaspedRunningTime;
    }
}
