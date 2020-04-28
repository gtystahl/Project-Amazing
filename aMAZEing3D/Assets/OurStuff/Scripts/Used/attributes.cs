using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attributes : MonoBehaviour
{
    // this lets us know if the gameobjects were set properly (possibly might be redundant)
    public bool isset = false;

    // These variables will be the pointers to the wall objects
    public GameObject topwall;
    public GameObject leftwall;
    public GameObject rightwall;
    public GameObject bottomwall;

    //These are the materials for rendering good / bad spaces
    public Material good;
    public Material bad;

    // This labels the section for reference
    public int sectionNumber;

    // This is the possible number of places the user can go
    public int paths = 4;

    // This is to see if we have been to this section
    public bool visited = false;

    //This lets the AI know that it is a part of the good path
    public bool onGood;
    // Start is called before the first frame update
    void Start()
    {
        visited = false;
        onGood = false;
        isset = true;
        //this.GetComponent<Renderer>().material = good;
    }
}
