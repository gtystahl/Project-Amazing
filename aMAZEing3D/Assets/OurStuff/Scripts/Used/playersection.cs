using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersection : MonoBehaviour
{
    public string col;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("This knows");
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.gameObject.tag == "section")
        {
            col = collision.collider.name;
        }
    }
}
