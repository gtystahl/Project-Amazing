using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing3 : MonoBehaviour
{
      public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update(){
         if (Input.GetKey(KeyCode.Space)){
           //transform.Rotate(Vector3.right * speed * Time.deltaTime);
            if (this.transform.localRotation.eulerAngles.x <= 350){
                //Debug.Log(this.transform.localRotation.eulerAngles.x);
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
            }
          }
          else{
            if(this.transform.localRotation.eulerAngles.x >=275){
              transform.Rotate(-Vector3.up * speed * Time.deltaTime);
            }

        }
    }
}
