using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handFollow : MonoBehaviour
{
    public GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = p.transform.position + new Vector3(0, 0 ,this.transform.localScale.z / 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
