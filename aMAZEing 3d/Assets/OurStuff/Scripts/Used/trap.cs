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
    public void Start()
    {
        this.GetComponent<fixtrap>().enabled = true;
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
                        break;

                    }
                }
                if (danger)
                {
                    //Debug.Log("danger should have worked");
                    this.GetComponent<resetwalls>().enabled = true;
                    this.GetComponent<resetwalls>().Start();
                    /*
                    GameObject startsec = collided_object;
                    GameObject endsec = main.GetComponent<makepath>().end_section;
                    Stack<GameObject>[] astack = main.GetComponent<makepath>().pathAlgorithm(startsec, endsec);

                    Stack<GameObject> gp = astack[0];
                    Stack<GameObject> ss = astack[1];

                    int ssc = ss.Count;
                    GameObject[] sa = new GameObject[ssc];
                    string[] nsa = new string[ssc];
                    GameObject ssec;
                    for (int a = 0; a < ssc; a++)
                    {
                        ssec = ss.Pop();
                        sa[a] = ssec;
                        nsa[a] = ssec.name;
                    }

                    int c = gp.Count;
                    GameObject[] ret_path = new GameObject[c];
                    string[] name_path = new string[c];
                    for (int a = 0; a < c; a++)
                    {
                        GameObject s = gp.Pop();
                        ret_path[a] = s;
                        name_path[a] = s.name;
                    }

                    main.GetComponent<makepath>().sa = sa;
                    main.GetComponent<makepath>().nsa = nsa;
                    main.GetComponent<makepath>().ret_path = ret_path;
                    main.GetComponent<makepath>().name_path = name_path;
                    */
                    aswitch = false;
                }
            }
        }
    }
}
