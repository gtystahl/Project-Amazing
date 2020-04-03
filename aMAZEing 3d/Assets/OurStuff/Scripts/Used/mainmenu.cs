using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject play;
    public string selection;

    public void Start()
    {
        Debug.Log("hello World");
        selection = "Play_Button";
        play.GetComponent<Renderer>().material  = play.GetComponent<materialSwitch>().dif;
    }

    /*public void FixedUpdate()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("This works");
            if (selection == "Play_Button")
            {
                SceneManager.LoadScene("Game");
            }
            else if (selection == "Play_Again")
            {
                SceneManager.LoadScene("Game");
            }
            else
            {
                //quit somehow
            }


            
        }
    }
    */
}


