using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCamera : MonoBehaviour
{
    public GameObject mm;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = mm.GetComponent<makepath>().start_section.transform.position + new Vector3(0, 1, 0);
    }
}
