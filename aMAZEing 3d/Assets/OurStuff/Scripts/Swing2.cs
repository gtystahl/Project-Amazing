using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing2 : MonoBehaviour
{
    private bool swingingDown = false;
    public Transform to;
    public Transform from;
    //public Transform to2;
    public Transform from2;
    Quaternion startingup = Quaternion.Euler (-90,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            swingingDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            swingingDown = false;
        }

        if(swingingDown)
        {
            //slerp down
           this.transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, .2f);
        }
        else
        {
            //slerp up
            this.transform.rotation = Quaternion.Slerp(from2.rotation, startingup, .2f);
        }
    }
}
