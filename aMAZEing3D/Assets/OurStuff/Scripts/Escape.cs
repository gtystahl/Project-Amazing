﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    public GameObject ac;
    public List<GameObject> al;
    public GameObject gameCam;
    public GameObject pauseCam;
    public GameObject miniCam;

    public RectTransform timertext;
    
    public GameObject timer;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            timertext.position -= new Vector3(0, 400, 0);
            timer.GetComponent<timer>().stop = true;
            al = ac.GetComponent<AI_Creater>().ailist;
            for (int i = 0; i < al.Count; i++)
            {
                al[i].GetComponent<AI_Controller>().enabled = false;
            }
            gameCam.SetActive(false);
            pauseCam.SetActive(true);
            miniCam.SetActive(false);
            //This is where we need to switch the camera
        }

/*
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            al = ac.GetComponent<AI_Creater>().ailist;
            for (int i = 0; i < al.Count; i++)
            {
                al[i].GetComponent<AI_Controller>().enabled = true;
            }
            gameCam.SetActive(true);
            pauseCam.SetActive(false);
            miniCam.SetActive(true);
        }
        */

    }
}
