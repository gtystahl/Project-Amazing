using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialSwitch : MonoBehaviour
{
    public GameObject menman;
    public GameObject other;
    public Material reg;
    public Material dif;

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("There was a colission");
        this.GetComponent<Renderer>().material = dif;
        other.GetComponent<Renderer>().material = reg;
        menman.GetComponent<mainmenu>().selection = this.name;

    }
}
