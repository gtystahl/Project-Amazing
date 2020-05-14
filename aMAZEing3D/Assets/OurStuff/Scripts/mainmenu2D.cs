using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu2D : MonoBehaviour
{
public void PlayGame ()
{
    SceneManager.LoadScene("Controls");
}

public void QuitGame ()
{
    Application.Quit ();
}
}
