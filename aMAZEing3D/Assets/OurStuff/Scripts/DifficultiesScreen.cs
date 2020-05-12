using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultiesScreen : MonoBehaviour
{
    public GameObject stat;
    // Start is called before the first frame update
    public void EasyMode ()
{
        stat.GetComponent<mazedim>().changedim(20, 20);
        SceneManager.LoadScene("Game");
}

    public void MediumMode ()
    {
        stat.GetComponent<mazedim>().changedim(35, 35);
        SceneManager.LoadScene("Game");
    }

    public void HardMode ()
    {
        stat.GetComponent<mazedim>().changedim(50, 50);
        SceneManager.LoadScene("Game");
    }

}
