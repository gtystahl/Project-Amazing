using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFollow : MonoBehaviour
{
    public GameObject pf;
    public GameObject start_section;
    public int i;


    // Start is called before the first frame update
    void Start()
    {
        
        start_section = pf.GetComponent<makepath>().start_section;
        Debug.Log("This sets the start section");
        Debug.Log("This is the initial position: " + this.transform.position);
        Debug.Log("This is the position we want it to be: " + start_section.transform.position);
        /*
        this.transform.position = start_section.transform.position;
        this.transform.position += new Vector3(0, .5f, 0);
        Debug.Log("This is the position after the switch: " + this.transform.position);
        Debug.Log(this.name);
        */
        i = 0;
    }
    /*
    private void Update()
    {
        Debug.Log(this.transform.position);
    }
    */
    // Update is called once per frame

    void Update()
    {
        if (i == 0)
        {
            this.transform.position = start_section.transform.position;
            this.transform.position += new Vector3(0, 1f, 0);
            i++;
        }
        float x = 0;
        float y = 0;
        float z = 0;

        //Debug.Log(this.transform.rotation.eulerAngles.y);

        if (this.transform.rotation.eulerAngles.y == 90) {
            x = -1.1f;
        }

        if (this.transform.rotation.eulerAngles.y == 270)
        {
            x = 1.1f;
        }

        if (this.transform.rotation.eulerAngles.y == 180)
        {
            z = 1.1f;
        }

        if (this.transform.rotation.eulerAngles.y == 0)
        {
            z = -1.1f;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log(KeyCode.DownArrow);
            this.transform.position += new Vector3(x, y, z);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log(KeyCode.UpArrow);
            this.transform.position += new Vector3(-x, y, -z);
        }


    }
}

