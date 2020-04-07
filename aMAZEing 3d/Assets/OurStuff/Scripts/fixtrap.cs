using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixtrap : MonoBehaviour
{   
    void Update()
    {
        if(this.GetComponent<resetwalls>().enabled != true && this.GetComponent<trap>().enabled != true)
        {
            this.GetComponent<trap>().enabled = true;
            this.GetComponent<trap>().aswitch = true;
        }
    }
}
