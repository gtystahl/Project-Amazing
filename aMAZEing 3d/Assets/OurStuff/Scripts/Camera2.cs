using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
    public Camera Camera1;
    void Update()
    {
        this.transform.position = Camera1.transform.position;
        this.transform.position += new Vector3(0, 20, 0);
    }
}
