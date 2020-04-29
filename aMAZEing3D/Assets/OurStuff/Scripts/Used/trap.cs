using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trap : MonoBehaviour
{
    public GameObject[] path;
    public string[] npath;
    public string colid;
    public GameObject main;
    public float time;
    public bool notgood;
    public GameObject collided_object;

    //This is something that will be turned on and off based on 
    public bool aswitch;

    //This is a humerous variable to tell us if the user has ever gone off the path
    public bool virgin;

    //I should really be comenting more lol. This is to see if we are in the danger zone
    public bool danger;

    //This is the name array for danger
    public string[] narr;

    //This is the array that holds all of the gameobjects that are special
    public GameObject[] arr;

    //This is a wild variable that Im adding to make things simpler
    public bool trapon;
    public bool findbad;
    // Start is called before the first frame update
    public void Start()
    {
        //this.GetComponent<fixtrap>().enabled = true;
        //Debug.Log(npath.Length);
        time = 0;
        aswitch = true;
        virgin = true;
        path = main.GetComponent<makepath>().ret_path;
        npath = main.GetComponent<makepath>().name_path;
        arr = main.GetComponent<makepath>().sa;
        narr = main.GetComponent<makepath>().nsa;
        trapon = false;
        findbad = false;
    }

    // Update is called once per frame
    void Update()
    {

        colid = this.GetComponent<playersection>().col;

        if (trapon)
        {
            closepath(path);
            trapon = false;
        }

        /*
        if (colid == "end")
        {
            Debug.Log("This should switch");
            SceneManager.LoadScene("Ending_Screen");
        }
        */

        if (findbad)
        {
            danger = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].name == colid)
                {
                    danger = true;
                    collided_object = arr[i];
                    break;

                }
            }
            if (danger)
            {
                this.GetComponent<resetwalls>().enabled = true;
                this.GetComponent<resetwalls>().Start();
                //arr = new GameObject[0];
                danger = false;
                aswitch = false;
            }
            findbad = false;
        }
    }

    public static void closepath(GameObject[] p)
    {
        int c = p.Length;
        for (int i = 0; i < c; i++)
        {
            GameObject s = p[i];
            attributes a = s.GetComponent<attributes>();
            a.onGood = false;
            if (a.topwall.transform.position.y != 2.5f)
            {
                a.topwall.transform.position += new Vector3(0, 5, 0);
            }

            if (a.bottomwall.transform.position.y != 2.5f)
            {
                a.bottomwall.transform.position += new Vector3(0, 5, 0);
            }

            if (a.leftwall.transform.position.y != 2.5f)
            {
                a.leftwall.transform.position += new Vector3(0, 5, 0);
            }

            if (a.rightwall.transform.position.y != 2.5f)
            {
                a.rightwall.transform.position += new Vector3(0, 5, 0);
            }
        }
    }

}
