using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIconMovement : MonoBehaviour
{
    public GameObject cam;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(cam.transform.position.x, distance, cam.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(cam.transform.position.x, distance, cam.transform.position.z);
    }
}
