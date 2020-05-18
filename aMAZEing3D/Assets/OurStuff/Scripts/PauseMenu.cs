using System.Collections;
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
    public GameObject timer;

    public RectTransform timertext;
    public void Resume ()
    {
        timertext.position += new Vector3(0, 400, 0);
        timer.GetComponent<timer>().stop = false;
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
