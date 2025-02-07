﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public Text timertext;
    public static float t;
    public int T;

    public bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        //t = 0;
        T = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (stop != true)
            {
                t += Time.deltaTime;
                //The T below is the one that needs to be displayed
                T = Mathf.RoundToInt(t);

                string minutes = ((int)t / 60).ToString();
                string seconds = (t % 60).ToString("f2");

                timertext.text = minutes + ":" + seconds;
            }
        } else
        {
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timertext.text = minutes + ":" + seconds;
        }
        
    }

    public void resettime()
    {
        t = 0;
    }
}
