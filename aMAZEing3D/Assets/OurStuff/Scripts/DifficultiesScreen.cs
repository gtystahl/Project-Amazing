using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultiesScreen : MonoBehaviour
{
    // Start is called before the first frame update
  public void EasyMode ()
{
    SceneManager.LoadScene("Game");
}

public void MediumMode ()
{
    SceneManager.LoadScene("Game");
}

public void HardMode ()
{
    SceneManager.LoadScene("Game");
}

}
