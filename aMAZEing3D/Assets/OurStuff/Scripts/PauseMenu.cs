﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ac;
    public List<GameObject> al;
    public GameObject gameCam;
    public GameObject pauseCam;
    public GameObject miniCam;
    public void Resume ()
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

    public void Quit ()
    {
        Application.Quit();
    }
}
