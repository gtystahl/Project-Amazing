using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.GetComponent<Rigidbody>().AddForce(transform.forward);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log(KeyCode.RightArrow);
            this.transform.Rotate(0, 90f * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log(KeyCode.LeftArrow);
            this.transform.Rotate(0, -90f * Time.deltaTime, 0);
        }
    }
}
