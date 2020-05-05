using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 force;
    public float speed;
    public float newspeed;

    public float angle;
    public float x;
    public float z;
    // Start is called before the first frame update
    void Start()
    {
        force = new Vector3(0, 0, 0);
        newspeed = 0;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        //Debug.Log(this.transform.eulerAngles.y);
        angle = this.transform.eulerAngles.y;
        newspeed = speed * Time.deltaTime;
        float unaltangle = angle;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //angle = this.transform.eulerAngles.y;
            z = 0;
            x = 0;
            float conversion = (Mathf.PI / 180f);
            if (angle <= 270 && angle >= 90)
            {
                if (angle < 180)
                {
                    angle -= 90; 
                    z = -Mathf.Sin(conversion * angle) * newspeed;
                    x = Mathf.Sin(conversion * (90 - angle)) * newspeed;
                }
                else
                {
                    angle -= 180;
                    x = -Mathf.Sin(conversion * angle) * newspeed;
                    z = -Mathf.Sin(conversion * (90 - angle)) * newspeed;
                }
            } else
            {
                if (angle > 90)
                {
                    angle = angle - 270;
                    z = Mathf.Sin(conversion * angle) * newspeed;
                    x = -Mathf.Sin(conversion * (90 - angle)) * newspeed;
                } else
                {
                    x = Mathf.Sin(conversion * angle) * newspeed;
                    z = Mathf.Sin(conversion * (90 - angle)) * newspeed;
                }
            }
            force.x = x;
            force.z = z;
            this.transform.position += force;
            //Debug.Log("Key is being pressed");
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            z = 0;
            x = 0;
            float conversion = (Mathf.PI / 180f);
            if (angle <= 270 && angle >= 90)
            {
                if (angle < 180)
                {
                    angle -= 90;
                    z = Mathf.Sin(conversion * angle) * newspeed;
                    x = -Mathf.Sin(conversion * (90 - angle)) * newspeed;
                }
                else
                {
                    angle -= 180;
                    x = Mathf.Sin(conversion * angle) * newspeed;
                    z = Mathf.Sin(conversion * (90 - angle)) * newspeed;
                }
            }
            else
            {
                if (angle > 90)
                {
                    angle = angle - 270;
                    z = -Mathf.Sin(conversion * angle) * newspeed;
                    x = Mathf.Sin(conversion * (90 - angle)) * newspeed;
                }
                else
                {
                    x = -Mathf.Sin(conversion * angle) * newspeed;
                    z = -Mathf.Sin(conversion * (90 - angle)) * newspeed;
                }
            }
            force.x = x;
            force.z = z;
            this.transform.position += force;
            //Debug.Log("Key is lifted");
            //rb.velocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(0, -90f * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0, 90f * Time.deltaTime, 0);
        }



    }
}
