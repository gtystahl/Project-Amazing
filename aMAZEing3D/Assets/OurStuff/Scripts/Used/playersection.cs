using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersection : MonoBehaviour
{
    public string col;
    public string coltouch;
    public string oldcol;

    public string[] npath;
    public bool notgood;
    public bool first;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("This knows");
        first = true;
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("entering section");
        if (collision.gameObject.tag == "section")
        {
            col = collision.collider.name;
            if (first)
            {
                npath = this.GetComponent<trap>().npath;
                notgood = true;
                for (int i = 0; i < npath.Length; i++)
                {
                    if (npath[i] == col)
                    {
                        notgood = false;
                        break;
                    }
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Leaving section");
        if (collision.collider.tag == "section")
        {
            if (notgood)
            {
                first = false;
                this.GetComponent<trap>().trapon = true;
            }
            if (first != true)
            {
                this.GetComponent<trap>().findbad = true;
            }
        }
    }
}
