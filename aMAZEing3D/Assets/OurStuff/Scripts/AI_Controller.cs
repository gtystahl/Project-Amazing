using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AI_Controller : MonoBehaviour
{
    
    //These are where the audio files go
    /*
    public AudioClip monster;
    public AudioClip playernoise;
    */
    public AudioSource audsor;
    

    //This might fix a possible duplication bug
    public bool hitonce = false;

    public int ainum;
    //I changed this to be the full path
    public GameObject[] gp;
    public GameObject[] fp;

    //This is the creater of the AI
    public GameObject ac;

    public GameObject pf;
    public GameObject aicr;
    public bool first;
    public GameObject startsec;
    public GameObject currentsec;
    public GameObject targetsec;
    public List<GameObject> pathtofollow;

    //this is the player register
    public GameObject pr;

    //These are the traversal variables
    public Vector3 targetloc;
    public GameObject nextsec;
    public bool start;
    public Vector3 addition;

    //This is for walking along the good path
    public List<GameObject> newpath;

    //This is to have it get back on track if somehow the player escapes
    public bool sawPlayer;

    public int Health;



    // Start is called before the first frame update
    public void Start()
    {
        //makepath mp = pf.GetComponent<makepath>();
        //gp = mp.ret_path;
        //gnp = mp.name_path;
        //startsec = aicr.GetComponent<AI_Creater>().cs;
        //currentsec = startsec;
        first = true;
        start = true;
        setLoc();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("COLLISION!");
        //Debug.Log(collision.gameObject.name);

        
        if (collision.gameObject.name == "SwordV5")
        {
            //Debug.Log(Input.GetKey(KeyCode.Space));
            if(Input.GetKey(KeyCode.Space) == true)
            {
                //Debug.Log("Should destroy");
                
                audsor.clip = ac.GetComponent<AI_Creater>().monster;
                audsor.Play();
                
                ac.GetComponent<AI_Creater>().ailist.Remove(this.gameObject);
                ac.GetComponent<AI_Creater>().spawnmoreplayer = true;
                Destroy(this.gameObject);
            }
            else
            {
                
                audsor.clip = ac.GetComponent<AI_Creater>().playernoise;
                audsor.Play();
                
                hitonce = true;
                ac.GetComponent<AI_Creater>().Health -= 1;
                ac.GetComponent<AI_Creater>().ailist.Remove(this.gameObject);
                ac.GetComponent<AI_Creater>().spawnmoreplayer = true;
                Destroy(this.gameObject);
                //Debug.Log(ac.GetComponent<AI_Creater>().Health);

                if(ac.GetComponent<AI_Creater>().Health == 0)
                {
                SceneManager.LoadScene("Death_screen");
                }
            }

        }
        
        if (collision.gameObject.name == "Player" && hitonce == false)
        {
            
            audsor.clip = ac.GetComponent<AI_Creater>().playernoise;
            audsor.Play();
            
            ac.GetComponent<AI_Creater>().Health -= 1;
            ac.GetComponent<AI_Creater>().ailist.Remove(this.gameObject);
            ac.GetComponent<AI_Creater>().spawnmoreplayer = true;
            Destroy(this.gameObject);
            //Debug.Log(ac.GetComponent<AI_Creater>().Health);

            if(ac.GetComponent<AI_Creater>().Health == 0)
            {
                SceneManager.LoadScene("Death_screen");
            }
        }
        
        if (currentsec.name != collision.collider.name)
        {
            if (collision.collider.tag != "wall")
            {
                for (int i = 0; i < fp.Length; i++)
                {
                    if (fp[i].name == collision.collider.name)
                    {
                        currentsec = fp[i];
                    }
                }
            }
        }
        if (collision.collider.name.StartsWith("AI"))
        {
            ac.GetComponent<AI_Creater>().ailist.Remove(this.gameObject);
            Destroy(this.gameObject);
            ac.GetComponent<AI_Creater>().spawnmoreai = true;
        } 
        if (collision.collider.transform.position.y > 0 && collision.collider.tag == "wall") {
            //Debug.Log("It hits a wall in the up position");
            Vector3 seccenter = currentsec.transform.position;
            pathtofollow = new List<GameObject>();
            startsec = currentsec;
            setLoc();
        }
        if (first)
        {
            pathtofollow = findPath();
            first = false;
        }
    }

    public void Update()
    {
        if (first != true)
        {
            if (start)
            {
                if (currentsec.GetComponent<attributes>().onGood)
                {
                    int playernum = 0;
                    int ailoc = 0;
                    for (int i = 0; i < gp.Length; i++)
                    {
                        if (gp[i] == currentsec)
                        {
                            ailoc = i;
                        }
                        if (gp[i].name == pr.GetComponent<playersection>().col)
                        {
                            playernum = i;
                        }
                    }

                    newpath.Add(gp[playernum]);

                    if (playernum < ailoc)
                    {
                        for (int i = playernum; i < ailoc; i++)
                        {
                            newpath.Add(gp[i]);
                        }
                    } else
                    {
                        for (int i = playernum; i > ailoc; i--)
                        {
                            newpath.Add(gp[i]);
                        }
                    }

                    pathtofollow = newpath;
                }
                //change all of the -1 to be the last item. A pain but necessay
                if (pathtofollow.Count != 0)
                {
                    if (currentsec != pathtofollow[pathtofollow.Count - 1])
                    {
                        nextsec = pathtofollow[pathtofollow.Count - 1];
                        targetloc = nextsec.transform.position;
                        //need to add in the offset for raising the ai up. (done)
                        //targetloc.y = 0;
                        addition.x = targetloc.x - this.transform.position.x;
                        addition.z = targetloc.z - this.transform.position.z;
                        //addition.y = .1f;
                        GameObject rm = pathtofollow[pathtofollow.Count - 1];
                        pathtofollow.Remove(rm);
                        start = false;
                    }
                    else
                    {
                        GameObject rm = pathtofollow[pathtofollow.Count - 1];
                        pathtofollow.Remove(rm);
                    }
                } else
                {
                    pathtofollow = findPath();
                }
            } else
            {
                if (pathtofollow.Count != 0)
                {
                    if (currentsec.name != pr.GetComponent<playersection>().col)
                    {
                        if (currentsec != nextsec || close(this.gameObject, nextsec) != true)
                        {
                            if (sawPlayer)
                            {
                                restartTarget(targetloc);
                                sawPlayer = false;
                            }
                            //old was /5 and * deltatime
                            Vector3 changerot = this.transform.rotation.eulerAngles;
                            float angle = 0;
                            if (addition.z > 2.5)
                            {
                                angle = 90;
                            } 
                            else if (addition.z < -2.5)
                            {
                                angle = 270;
                            }
                            else if (addition.x > 2.5) 
                            {
                                angle = 180;
                            } else
                            {
                                angle = 0;
                            }
                            changerot.y = angle;
                            this.transform.position += (addition) * Time.deltaTime;
                            this.transform.eulerAngles = changerot;

                        }
                        else
                        {
                            nextsec = pathtofollow[pathtofollow.Count - 1];
                            targetloc = nextsec.transform.position;
                            //need to add in the offset for raising the ai up. (done)
                            //targetloc.y = 0;
                            //startsec = currentsec;
                            //setLoc();
                            addition = targetloc - this.transform.position;
                            //addition.y = .1f;
                            GameObject rm = pathtofollow[pathtofollow.Count - 1];
                            pathtofollow.Remove(rm);
                        }
                    } else
                    {
                        //add in the follow player code
                        sawPlayer = true;
                        Vector3 pmovement = new Vector3(0, 0, 0);
                        pmovement.x = pr.transform.position.x - this.transform.position.x;
                        pmovement.z = pr.transform.position.z - this.transform.position.z;
                        
                        //this.transform.position += (pmovement) * Time.deltaTime * 2; Vector3 changerot = this.transform.rotation.eulerAngles;
                        Vector3 changerot = this.transform.rotation.eulerAngles;
                        float angle = changerot.y;
                        if (pmovement.z >= 0 && pmovement.x >= 0)
                        {
                            //Debug.Log(Mathf.Abs(pmovement.x) * (Mathf.PI / 180));
                            //Debug.Log((Mathf.Asin(Mathf.Abs(pmovement.x) * (Mathf.PI / 180))));
                            //angle = (Mathf.Asin(Mathf.Abs(pmovement.x) * (Mathf.PI / 180))) + 90;
                            angle = (Mathf.Atan(Mathf.Abs(pmovement.x) / Mathf.Abs(pmovement.z)) * (180 / Mathf.PI)) + 90;
                        }
                        else if (pmovement.z < 0 && pmovement.x < 0)
                        {
                            //Debug.Log(Mathf.Abs(pmovement.x) * (Mathf.PI / 180));
                            //Debug.Log((Mathf.Asin(Mathf.Abs(pmovement.x) * (Mathf.PI / 180))));
                            angle = (Mathf.Atan(Mathf.Abs(pmovement.x) / Mathf.Abs(pmovement.z)) * (180 / Mathf.PI)) + 270;
                        }
                        else if (pmovement.z < 0)
                        {
                            //Debug.Log(Mathf.Abs(pmovement.x) * (Mathf.PI / 180));
                            //Debug.Log((Mathf.Asin(Mathf.Abs(pmovement.x) * (Mathf.PI / 180))));
                            angle = (Mathf.Atan(Mathf.Abs(pmovement.z) / Mathf.Abs(pmovement.x)) * (180 / Mathf.PI)) + 180;
                        }
                        else
                        {
                            //Debug.Log(Mathf.Abs(pmovement.x) * (Mathf.PI / 180));
                            //Debug.Log((Mathf.Asin(Mathf.Abs(pmovement.x) * (Mathf.PI / 180))));
                            angle = (Mathf.Atan(Mathf.Abs(pmovement.z) / Mathf.Abs(pmovement.x)) * (180 / Mathf.PI));
                        }
                        changerot.y = angle;
                        this.transform.eulerAngles = changerot;
                        //Debug.Log((pmovement) * Time.deltaTime * (1f / 2f));
                        //Debug.Log(angle);
                        this.transform.position += (pmovement) * Time.deltaTime * 2;

                    }
                } else
                {
                    //add in the follow along goodpath code
                    start = true;
                }
            }
        }
    }

    public bool close(GameObject c, GameObject t)
    {
        bool xgood = false;
        bool zgood = false;
        if (Mathf.Abs(t.transform.position.x - c.transform.position.x) < .5f)
        {
            xgood = true;
        }
        if (Mathf.Abs(t.transform.position.z - c.transform.position.z) < .5f)
        {
            zgood = true;
        }

        if (xgood && zgood)
        {
            return true;
        }

        return false;
    }
    public List<GameObject> findPath()
    {
        bool inside = false;
        List<GameObject> aipath = new List<GameObject>();
        //Find a way to make finding good path easier
        if (currentsec.GetComponent<attributes>().onGood)
        {
            inside = true;
        }
        /*
        while(true)
        {
            for (int i = 0; i < gnp.Length; i++)
            {
                if (currentsec.name == gnp[i])
                {
                    inside = true;
                    break;
                }
            }
            break;
        }
        */

        if (inside != true)
        {
            aipath = recurspath(currentsec, aipath, currentsec, currentsec);
        }

        return aipath;
    }

    public List<GameObject> recurspath(GameObject s, List<GameObject> g, GameObject p, GameObject og)
    {
        //Find a way to see if the section is in good path easier (done)
        List<GameObject> path = g;
        List<GameObject> retpath;
        attributes secat = s.GetComponent<attributes>();
        GameObject[] cons;
        GameObject nsec = null;
        int origcount = path.Count;
        if (secat.onGood)
        {
            path.Add(s);
            return path;
        } if (s.name == pr.GetComponent<playersection>().col)
        {
            path.Add(s);
            return path;
        }
        bool change;

        if (secat.topwall.transform.position.y < 0)
        {
            cons = secat.topwall.GetComponent<wall_attributes>().connections;
            if (cons[0] != null)
            {
                for (int i = 0; i < cons.Length; i++)
                {
                    if (s != cons[i])
                    {
                        nsec = cons[i];
                    }
                }
                if (nsec != p)
                {
                    change = false;
                    retpath = recurspath(nsec, path, s, og);
                    //This could be redundant because if they are the same lenght then there should not have been any changes
                    if (retpath.Count != origcount)
                    {
                        change = true;
                    }

                    if (change)
                    {
                        if (og == nsec)
                        {
                            return path;
                        }
                        path = retpath;
                        path.Add(nsec);
                        origcount = path.Count;
                    }
                }
            }
        }

        if (secat.bottomwall.transform.position.y < 0)
        {
            cons = secat.bottomwall.GetComponent<wall_attributes>().connections;
            for (int i = 0; i < cons.Length; i++)
            {
                if (s != cons[i])
                {
                    nsec = cons[i];
                }
            }
            if (nsec != p)
            {
                change = false;
                retpath = recurspath(nsec, path, s, og);
                if (retpath.Count != origcount)
                {
                    change = true;
                }

                if (change)
                {
                    if (og == nsec)
                    {
                        return path;
                    }
                    path = retpath;
                    path.Add(nsec);
                    origcount = path.Count;
                }
            }
        }

        if (secat.leftwall.transform.position.y < 0)
        {
            cons = secat.leftwall.GetComponent<wall_attributes>().connections;
            for (int i = 0; i < cons.Length; i++)
            {
                if (s != cons[i])
                {
                    nsec = cons[i];
                }
            }
            if (nsec != p)
            {
                change = false;
                retpath = recurspath(nsec, path, s, og);
                if (retpath.Count != origcount)
                {
                    change = true;
                }

                if (change)
                {
                    if (og == nsec)
                    {
                        return path;
                    }
                    path = retpath;
                    path.Add(nsec);
                    origcount = path.Count;
                }
            }
        }

        if (secat.rightwall.transform.position.y < 0)
        {
            cons = secat.rightwall.GetComponent<wall_attributes>().connections;
            for (int i = 0; i < cons.Length; i++)
            {
                if (s != cons[i])
                {
                    nsec = cons[i];
                }
            }
            if (nsec != p)
            {
                change = false;
                retpath = recurspath(nsec, path, s, og);
                if (retpath.Count != origcount)
                {
                    change = true;
                }

                if (change)
                {
                    if (og == nsec)
                    {
                        return path;
                    }
                    path = retpath;
                    path.Add(nsec);
                    origcount = path.Count;
                }
            }
        }

        return path;
    }
    public void setLoc()
    {
        this.transform.position = startsec.transform.position + new Vector3(0, 2, 0);
    }

    public void restartTarget(Vector3 tl)
    {
        this.addition = (tl - this.transform.position) * 10;
    }
}
