using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing3 : MonoBehaviour
{
    public float speed;
    public Vector3 v;
    public Vector3 v2;
    // Start is called before the first frame update
    void Start()
    {
        v = new Vector3(270, 0, -90);
        v2 = new Vector3(0, 0, -90);
    }
    void Update(){
       
        //Debug.Log(this.transform.localEulerAngles);
         if (Input.GetKeyDown(KeyCode.Space)){
            //Debug.Log(this.transform.localRotation.eulerAngles.x);
            //Vector3.up and speed
            this.transform.eulerAngles = v2;
         }
         else if (Input.GetKeyUp(KeyCode.Space)) {
            //Vector3.up and speed
            this.transform.eulerAngles = v;

        }
        

        /*
        Debug.Log(this.transform.localEulerAngles);
        transform.Rotate(-Vector3.up * speed * Time.deltaTime);
        */
    }
}
