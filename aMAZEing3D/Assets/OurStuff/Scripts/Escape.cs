using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    public GameObject ac;
    public List<GameObject> al;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            al = ac.GetComponent<AI_Creater>().ailist;
            for (int i = 0; i < al.Count; i++)
            {
                al[i].GetComponent<AI_Controller>().enabled = false;
            }
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
        }
        follow this for getting the AI to start again
        */
    }
}
