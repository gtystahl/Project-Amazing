using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.VersionControl;

public class Swing : MonoBehaviour
{
  Quaternion targetAngle_90 = Quaternion.Euler (-90,0,-90);
  Quaternion targetAngle_0 = Quaternion.Euler (0,0,0);
  public Quaternion currentAngle;

    // Start is called before the first frame update
    void Start()
    {
      currentAngle = targetAngle_90;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey(KeyCode.Space))
      {
        ChangeCurrentAngle ();
      }
      else
      {
         currentAngle = targetAngle_90;
      }

      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, currentAngle, .2f);

    }

    void ChangeCurrentAngle()
    {
      if(currentAngle.eulerAngles.x==targetAngle_90.eulerAngles.x)
      {
        currentAngle = targetAngle_0;
      }
     /* else
      {
        currentAngle = targetAngle_90;
      }*/
    }
}
