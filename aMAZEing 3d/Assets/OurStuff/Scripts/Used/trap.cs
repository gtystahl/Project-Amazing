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
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(npath.Length);
        time = 0;
        aswitch = true;
        virgin = true;
        path = main.GetComponent<makepath>().ret_path;
        npath = main.GetComponent<makepath>().name_path;
        arr = main.GetComponent<makepath>().sa;
        narr = main.GetComponent<makepath>().nsa;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            if (aswitch)
            {
                colid = this.GetComponent<playersection>().col;
                if (virgin)
                {
                    notgood = true;
                    for (int i = 0; i < npath.Length; i++)
                    {
                        if (npath[i] == colid)
                        {
                            notgood = false;
                            break;
                        }
                    }
                    if (notgood)
                    {
                        virgin = false;
                        int c = path.Length;
                        for (int i = 0; i < c; i++)
                        {
                            GameObject s = path[i];
                            attributes a = s.GetComponent<attributes>();
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
                if (colid == "end")
                {
                    Debug.Log("This should switch");
                    SceneManager.LoadScene("Ending_Screen");
                }
                danger = false;
                for (int i = 0; i < narr.Length; i++)
                {
                    if (narr[i] == colid)
                    {
                        danger = true;
                        collided_object = arr[i];
                        Debug.Log("This triggers the danger");
                        break;
                    }
                }
                if (danger)
                {
                    //Debug.Log("danger should have worked");
                    this.GetComponent<resetwalls>().enabled = true;
                    aswitch = false;
                }
            }
        }
    }
}
