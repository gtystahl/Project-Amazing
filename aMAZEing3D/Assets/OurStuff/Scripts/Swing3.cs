using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing3 : MonoBehaviour
{
    public float speed;
    public Vector3 v;
    // Start is called before the first frame update
    void Start()
    {
        v = new Vector3(0, 90, 0);
    }
    void Update(){
       
        //Debug.Log(this.transform.localEulerAngles);
         if (Input.GetKeyDown(KeyCode.Space)){
                //Debug.Log(this.transform.localRotation.eulerAngles.x);
                //Vector3.up and speed
            transform.Rotate(v);
         }
         else if (Input.GetKeyUp(KeyCode.Space)) {
            //Vector3.up and speed
            transform.Rotate(-v);

        }
        

        /*
        Debug.Log(this.transform.localEulerAngles);
        transform.Rotate(-Vector3.up * speed * Time.deltaTime);
        */
    }
}
