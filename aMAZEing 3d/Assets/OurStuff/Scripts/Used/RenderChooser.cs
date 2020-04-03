using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderChooser : MonoBehaviour
{
    public GameObject[] sect_list;
    // Start is called before the first frame update
    void Start()
    {
        sect_list = this.GetComponent<mazecreater>().full_section_list;
        for (int i = 0; i < sect_list.Length; i++)
        {
            sect_list[i].GetComponent<Renderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
