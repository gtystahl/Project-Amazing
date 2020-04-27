using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zzzdebugmakepath : MonoBehaviour
{
    public GameObject pr;

    public ArrayList secleft;
    public GameObject square;
    public Stack<GameObject> correct_path;
    public bool gpd;
    public Stack<Stack<GameObject>> path;
    public bool first_change;
    public Stack<GameObject> ss;
    public GameObject[] section_array; //sa
    public string[] name_section_array; //nsa
    public Stack<GameObject> section_walls;
    public GameObject[] rp; //ret_path
    public string[] np; //name_path

    public GameObject[] full;
    public GameObject s;
    public GameObject es;

    public int PathSize;
    public bool allvisitedval;

    public GameObject ac;

    public bool running;
    public void Start()
    {
        full = this.GetComponent<makepath>().arr;
        s = this.GetComponent<makepath>().start_section;
        es = this.GetComponent<makepath>().end_section;
        secleft = new ArrayList(full.Length);
        for (int z = 0; z < full.Length; z++) {
            secleft.Add(full[z]);
        }
        square = s; //section
        correct_path = new Stack<GameObject>(); //good_path
        gpd = false;
        path = new Stack<Stack<GameObject>>();
        first_change = false;
        ss = new Stack<GameObject>();
        running = true;

    }
    //here we go

    private void Update()
    {
        /*
        string printable = "secleft: [";
        string flippysticks;
        Debug.Log(secleft.Count);
        for (int i = 0; i < secleft.Count; i++)
        {
            flippysticks = "";
            flippysticks += secleft[i];
            printable += flippysticks.Split(' ')[0];
            if (i + 1 < secleft.Count)
            {
                printable += " ,";
            }
        }
        Debug.Log(printable + "]");
        */
        if (running)
        {
            int possibles = square.GetComponent<attributes>().paths;
            int iter;
            if (gpd != true)
            {
                if (correct_path.Contains(square) != true)
                {
                    correct_path.Push(square);
                    //name_path[correct_path.Count] = square.name;
                    //Debug.Log(name_path.Length);
                    //Debug.Log("Add square: " + square.name);
                    //Debug.Log("good path size: " + correct_path.Count);
                    //square.GetComponent<Renderer>().enabled = false;
                    //square.transform.position += new Vector3(0, 10, 0);
                }
            }

            if (possibles == 0)
            {
                if (gpd != true)
                {
                    correct_path.Pop();
                    //name_path[correct_path.Count] = "-1";
                    //Debug.Log("Remove square: " + s.name);
                    //Debug.Log("good path size: " + correct_path.Count);
                    //square.GetComponent<Renderer>().enabled = true;
                    //square.transform.position += new Vector3(0, -10, 0);
                }
                //sudo stuff goes here
                Stack<GameObject> sectlst;
                GameObject w;
                PathSize = path.Count;
                allvisitedval = allvisited(full);
                if (allvisited(full) != true || path.Count != 0)
                {
                    if (first_change)
                    {
                        if (square.name != es.name)
                        {
                            //square.GetComponent<Renderer>().enabled = false;
                            //This is where we set the special spaces
                            square.GetComponent<Renderer>().material = square.GetComponent<attributes>().bad;
                            ss.Push(square);
                        }
                        //Debug.Log(square.name);
                        first_change = false;
                    }
                    sectlst = path.Pop();
                    square = sectlst.Pop();
                    square.GetComponent<attributes>().visited = true;
                    for (int i = 0; i < sectlst.Count; i++)
                    {
                        w = sectlst.Pop();
                        GameObject[] nexts = w.GetComponent<wall_attributes>().connections;
                        for (int k = 0; k < nexts.Length; k++)
                        {
                            if (nexts[k].GetComponent<attributes>().sectionNumber != square.GetComponent<attributes>().sectionNumber)
                            {
                                if (nexts[k].GetComponent<attributes>().visited != true)
                                {
                                    nexts[k].GetComponent<attributes>().paths += 1;
                                    w.GetComponent<wall_attributes>().movable = true;
                                    if (k == 0)
                                    {
                                        nexts[k + 1].GetComponent<attributes>().paths += 1;
                                    }
                                    else
                                    {
                                        nexts[k - 1].GetComponent<attributes>().paths += 1;
                                    }
                                }
                            }
                        }

                    }
                }
                else
                {
                    Debug.Log("Stops the loop");
                    running = false;
                    //Put this on the outside since we can't return multiple data types easily
                    /*
                    int ssc = ss.Count;
                    //Debug.Log(ss.Count);
                    section_array= new GameObject[ssc];
                    name_section_array = new string[ssc];
                    GameObject ssec;
                    for (int i = 0; i < ssc; i++)
                    {
                        ssec = ss.Pop();
                        section_array[i] = ssec;
                        name_section_array[i] = ssec.name;
                    }
                    */
                }
            }
            else
            {
                first_change = true;
                iter = Random.Range(0, possibles);


                section_walls = new Stack<GameObject>();
                GameObject old_section = square;
                if (secleft.Contains(old_section))
                {
                    secleft.Remove(old_section);
                }

                for (int a = 0; a < 4; a++)
                {
                    GameObject wall;
                    if (a == 0)
                    {
                        wall = old_section.GetComponent<attributes>().topwall;
                    }
                    else if (a == 1)
                    {
                        wall = old_section.GetComponent<attributes>().rightwall;
                    }
                    else if (a == 2)
                    {
                        wall = old_section.GetComponent<attributes>().bottomwall;
                    }
                    else
                    {
                        wall = old_section.GetComponent<attributes>().leftwall;
                    }

                    if (wall.GetComponent<wall_attributes>().movable)
                    {

                        if (iter == 0)
                        {

                            wall.transform.position += new Vector3(0, -(wall.transform.localScale.y), 0);
                            wall.GetComponent<wall_attributes>().movable = false;

                            GameObject[] nexts = wall.GetComponent<wall_attributes>().connections;
                            for (int i = 0; i < nexts.Length; i++)
                            {
                                nexts[i].GetComponent<attributes>().paths -= 1;
                                if (nexts[i].GetComponent<attributes>().sectionNumber != old_section.GetComponent<attributes>().sectionNumber)
                                {
                                    square = nexts[i];
                                    square.GetComponent<attributes>().visited = true;
                                }
                            }
                        }
                        else
                        {
                            wall.GetComponent<wall_attributes>().movable = false;
                            GameObject[] nexts = wall.GetComponent<wall_attributes>().connections;
                            for (int k = 0; k < nexts.Length; k++)
                            {
                                nexts[k].GetComponent<attributes>().paths -= 1;
                            }

                            section_walls.Push(wall);
                        }
                    }
                    else
                    {
                        iter++;
                    }

                    iter--;
                }

                if (square.name == es.name)
                {
                    // Lets the Algorithm know this is a bad path and time to start moving backwards
                    GameObject wall = square.GetComponent<attributes>().topwall;
                    wall.transform.position += new Vector3(0, -(wall.transform.localScale.y), 0);
                    //Could possibly be broken and need ot be changed
                    GameObject e = Instantiate(square, new Vector3(square.transform.position.x, square.transform.position.y, square.transform.position.z + (square.transform.localScale.z) + wall.transform.localScale.x), Quaternion.identity);
                    e.name = "end";
                    correct_path.Push(square);
                    gpd = true;

                    //This needs to be moved to the outside
                    /*
                    int c = correct_path.Count;
                    rp = new GameObject[c];
                    np = new string[c];
                    for (int i = 0; i < c; i++)
                    {
                        GameObject sect = correct_path.Pop();
                        rp[i] = sect;
                        np[i] = sect.name;

                        //Debug.Log(s.name);
                        //Debug.Log(i);
                        //s.GetComponent<Renderer>().enabled = false;
                    }
                    */
                }
                else
                {
                    section_walls.Push(old_section);
                    path.Push(section_walls);
                }
            }
            /*
            printable = "secleft: [";
            Debug.Log(secleft.Count);
            for (int i = 0; i < secleft.Count; i++)
            {
                flippysticks = "";
                flippysticks += secleft[i];
                printable += flippysticks.Split(' ')[0];
                if (i + 1 < secleft.Count)
                {
                    printable += " ,";
                }
            }
            Debug.Log(printable + "]");
            */
        }
        else
        {
            Debug.Log("The pathmaker ran");
            //TODO PLEASE FOR THE LOVE OF GOD CHANGE THIS BEFORE BACKMAN SEES!!!!!!!
            Stack<GameObject>[] fuckyouunity = new Stack<GameObject>[2];
            fuckyouunity[0] = correct_path;
            fuckyouunity[1] = ss;
            this.GetComponent<makepath>().astack = fuckyouunity;
            this.GetComponent<makepath>().setFun();
            pr.GetComponent<trap>().Start();
            pr.GetComponent<trap>().enabled = true; 
            this.GetComponent<zzzdebugmakepath>().enabled = false;
            //ac.GetComponent<AI_Creater>().enabled = true;
        }
    }
    public bool allvisited(GameObject[] f)
    {
        for (int iter = 0; iter < f.Length; iter++)
        {
            if (f[iter].GetComponent<attributes>().visited != true)
            {
                return false;
            }
        }
        return true;
    }
}

    // Update is called once per frame

