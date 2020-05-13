using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetwalls : MonoBehaviour
{
    //TODO find a way to reset the possibilities of each section
    public GameObject[] sections;
    public GameObject mazemake;
    public GameObject pf;
    public GameObject pr;
    //public makepath mp;
    //can change the height later if needed. 5 is the cales of the wall
    public Vector3 v;
    // Start is called before the first frame update
    public void Start()
    {
        v = new Vector3(0, 5, 0);
        sections = mazemake.GetComponent<mazecreater>().full_section_list;

        Stack<Light> llist2 = pf.GetComponent<makepath>().llist;
        int j = llist2.Count;
        for(int i = 0; i < j; i++)
        {
            Destroy(llist2.Pop());


        }
        pf.GetComponent<makepath>().llist = new Stack<Light>(); 


        for (int i = 0; i < sections.Length; i++)
        {
            GameObject s = sections[i];
            //Changes the bad spaces back to the good spaces
            //s.GetComponent<Renderer>().material = s.GetComponent<attributes>().good;


            s.GetComponent<attributes>().paths = 4;
            s.GetComponent<attributes>().visited = false;
            if (s.GetComponent<attributes>().topwall.GetComponent<wall_attributes>().outside != true)
            {
                if (s.GetComponent<attributes>().topwall.transform.position.y < 0)
                {
                    s.GetComponent<attributes>().topwall.transform.position += v;
                }
                s.GetComponent<attributes>().topwall.GetComponent<wall_attributes>().movable = true;
            }
            else
            {
                s.GetComponent<attributes>().paths -= 1;
            }

            if (s.GetComponent<attributes>().rightwall.GetComponent<wall_attributes>().outside != true)
            {
                if (s.GetComponent<attributes>().rightwall.transform.position.y < 0)
                {
                    s.GetComponent<attributes>().rightwall.transform.position += v;
                }
                s.GetComponent<attributes>().rightwall.GetComponent<wall_attributes>().movable = true;
            }
            else
            {
                s.GetComponent<attributes>().paths -= 1;
            }

            if (s.GetComponent<attributes>().bottomwall.GetComponent<wall_attributes>().outside != true)
            {
                if (s.GetComponent<attributes>().bottomwall.transform.position.y < 0)
                {
                    s.GetComponent<attributes>().bottomwall.transform.position += v;
                }
                s.GetComponent<attributes>().bottomwall.GetComponent<wall_attributes>().movable = true;
            }
            else
            {
                s.GetComponent<attributes>().paths -= 1;
            }

            if (s.GetComponent<attributes>().leftwall.GetComponent<wall_attributes>().outside != true)
            {
                if (s.GetComponent<attributes>().leftwall.transform.position.y < 0)
                {
                    s.GetComponent<attributes>().leftwall.transform.position += v;
                }
                s.GetComponent<attributes>().leftwall.GetComponent<wall_attributes>().movable = true;
            }
            else
            {
                s.GetComponent<attributes>().paths -= 1;
            }

        }


        //Put run mazecreater here

        Debug.Log("stop");
        //zzzdebugmakepath zmp = pf.GetComponent<zzzdebugmakepath>();
        //zmp.Start();
        //zmp.enabled = true;
        //zmp.square = this.GetComponent<trap>().collided_object;

        //Fix the remake maze
        makepath mp = pf.GetComponent<makepath>();
        Debug.Log("first : " + this.GetComponent<trap>().collided_object);
        Debug.Log("second : " + mp.end_section);
        Debug.Log("third : " + mp.arr);
        Debug.Log("fourth : " + mp.player);
        mp.astack = mp.pathAlgorithm(this.GetComponent<trap>().collided_object, mp.end_section, mp.arr, mp.player);
        mp.setFun(mp.player);

        /*
        makepath m = pf.GetComponent<makepath>();
        Stack<GameObject>[] astack = m.pathAlgorithm(pr.GetComponent<trap>().collided_object, pf.GetComponent<makepath>().end_section, sections);
        //Stack<GameObject>[] astack = new Stack<GameObject>[2];

        m.good_path = astack[0];
        m.ss = astack[1];

        int ssc = m.ss.Count;
        m.sa = new GameObject[ssc];
        m.nsa = new string[ssc];
        GameObject ssec;
        for (int i = 0; i < ssc; i++)
        {
            ssec = m.ss.Pop();
            m.sa[i] = ssec;
            m.nsa[i] = ssec.name;
        }

        int c = m.good_path.Count;
        m.ret_path = new GameObject[c];
        m.name_path = new string[c];
        for (int i = 0; i < c; i++)
        {
            GameObject s = m.good_path.Pop();
            m.ret_path[i] = s;
            m.name_path[i] = s.name;
        }
        */
        //this.GetComponent<trap>().enabled = false;
        //this.GetComponent<trap>().Start();
        this.GetComponent<resetwalls>().enabled = false;


    }
}
