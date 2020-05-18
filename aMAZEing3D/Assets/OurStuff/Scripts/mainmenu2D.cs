using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu2D : MonoBehaviour
{
    public GameObject Timer;
    public void PlayGame()
    {
        if (SceneManager.GetActiveScene().name != "Start Menu")
        {
            Timer.GetComponent<timer>().resettime();
        }
        SceneManager.LoadScene("Controls");
    }

public void QuitGame ()
{
    Application.Quit ();
}
}
