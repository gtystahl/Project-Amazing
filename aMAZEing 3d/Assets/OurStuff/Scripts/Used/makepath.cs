using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makepath : MonoBehaviour
{
    // This is the current section that the algorithm is on
    public GameObject section;

    //This is a stack of walls that have been changed by a certain traversed section
    public Stack<GameObject> section_walls;

    //This is a stack that hold the path of the algorithm which also include the changes to walls made durin the path
    public Stack<Stack<GameObject>> path = new Stack<Stack<GameObject>>();

    //This is the object that creates the maze
    public GameObject mazemaker;

    //This is the camera object
    public GameObject cam;

    //This is the first section that the pathfinder algorithm starts with
    public GameObject start_section;

    //This is the destination section
    public GameObject end_section;

    //This is the game object that will hold a wall that needs to be looked at
    public GameObject wall;

    //This is for creating that special area
    public bool first_change;

    //This is the stack for the true path to the end stack
    public Stack<GameObject> good_path = new Stack<GameObject>();
    //This is the array used to contain the actual object references
    public GameObject[] ret_path;
    //This is the array that has the string names of each item in good path
    public string[] name_path;
    //This stops the program from adding more sections to the good path after it gets done
    public bool gpd = false;

    //This is a base type of the prefab section
    public GameObject floor;

    //This is a stack and two arrays that hold the special section list
    public Stack<GameObject> ss = new Stack<GameObject>();
    public GameObject[] sa;
    public string[] nsa;

    //This is the full section list
    public GameObject[] arr;

    //This is the return value of the path algorithm
    public Stack<GameObject>[] astack;

    //This is the Ai creater object
    public GameObject ac;
    // Start is called before the first frame update
    void Start()
    {
        //This gets the mazecreater script
        mazecreater com;
        com = mazemaker.GetComponent<mazecreater>();

        //Sets dimensions of the maze
        int mx = com.mazex;
        int mz = com.mazez;
        int diment = mx * mz;

        //This is a list of all sections
        arr = com.full_section_list;

        //This sets the beginning and end
        int end_num = Random.Range((diment - mx), (diment));
        int start_num = Random.Range(0, mx);
        end_section = arr[end_num];
        section = arr[start_num];
        start_section = section;
        section.GetComponent<attributes>().visited = true;

        //about to do some funky things under here:

        //Stack<GameObject>[] astack = pathAlgorithm(start_section, end_section, arr);

        /*
        good_path = astack[0];
        ss = astack[1];

        int ssc = ss.Count;
        sa = new GameObject[ssc];
        nsa = new string[ssc];
        GameObject ssec;
        for (int i = 0; i < ssc; i++)
        {
            ssec = ss.Pop();
            sa[i] = ssec;
            nsa[i] = ssec.name;
        }

        int c = good_path.Count;
        ret_path = new GameObject[c];
        name_path = new string[c];
        for (int i = 0; i < c; i++)
        {
            GameObject s = good_path.Pop();
            ret_path[i] = s;
            name_path[i] = s.name;
        }
        */
        /*
        int j = 1;
        while (running)
        {
            int possibles = section.GetComponent<attributes>().paths;
            int iter;
            if (gpd != true)
            {
                if (good_path.Contains(section) != true)
                {
                    good_path.Push(section);
                    //name_path[good_path.Count] = section.name;
                    //Debug.Log(name_path.Length);
                    //Debug.Log("Add Section: " + section.name);
                    //Debug.Log("good path size: " + good_path.Count);
                    //section.GetComponent<Renderer>().enabled = false;
                    //section.transform.position += new Vector3(0, 10, 0);
                }
            }

            if (possibles == 0)
            {
                if (gpd != true)
                {
                    GameObject s = good_path.Pop();
                    //name_path[good_path.Count] = "-1";
                    //Debug.Log("Remove Section: " + s.name);
                    //Debug.Log("good path size: " + good_path.Count);
                    //section.GetComponent<Renderer>().enabled = true;
                    //section.transform.position += new Vector3(0, -10, 0);
                }
                //sudo stuff goes here
                Stack <GameObject> sectlst;
                GameObject w;
                if (path.Count != 0)
                {
                    if (first_change)
                    {
                        //section.GetComponent<Renderer>().enabled = false;
                        //This is where we set the special spaces
                        section.GetComponent<Renderer>().material = section.GetComponent<attributes>().bad;
                        ss.Push(section);
                        //Debug.Log(section.name);
                        first_change = false;
                    }
                    sectlst = path.Pop();
                    section = sectlst.Pop();
                    section.GetComponent<attributes>().visited = true;
                    for (int i = 0; i < sectlst.Count; i++)
                    {
                        w = sectlst.Pop();
                        GameObject[] nexts = w.GetComponent<wall_attributes>().connections;
                        for (int k = 0; k < nexts.Length; k++)
                        {
                            if (nexts[k].GetComponent<attributes>().sectionNumber != section.GetComponent<attributes>().sectionNumber)
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
                } else
                {
                    running = false;
                    int ssc = ss.Count;
                    //Debug.Log(ss.Count);
                    sa = new GameObject[ssc];
                    nsa = new string[ssc];
                    GameObject ssec;
                    for (int i = 0; i < ssc; i++)
                    {
                        ssec = ss.Pop();
                        sa[i] = ssec;
                        nsa[i] = ssec.name;
                    }
                }
            }
            else
            {
                first_change = true;
                iter = Random.Range(0, possibles);


                section_walls = new Stack<GameObject>();
                GameObject old_section = section;

                for (int a = 0; a < 4; a++)
                {
                    GameObject wall;
                    if (a == 0)
                    {
                        wall = old_section.GetComponent<attributes>().topwall;
                    }
                    else if (a == 1) {
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

                            wall.transform.position += new Vector3(0, wall_height, 0);
                            wall.GetComponent<wall_attributes>().movable = false;

                            GameObject[] nexts = wall.GetComponent<wall_attributes>().connections;
                            for (int i = 0; i < nexts.Length; i++)
                            {
                                nexts[i].GetComponent<attributes>().paths -= 1;
                                if (nexts[i].GetComponent<attributes>().sectionNumber != old_section.GetComponent<attributes>().sectionNumber)
                                {
                                    section = nexts[i];
                                    section.GetComponent<attributes>().visited = true;
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

                if (section == end_section)
                {
                    // Lets the Algorithm know this is a bad path and time to start moving backwards
                    wall = section.GetComponent<attributes>().topwall;
                    wall.transform.position += new Vector3(0, wall_height, 0);
                    GameObject e = Instantiate(floor, new Vector3(section.transform.position.x, section.transform.position.y, section.transform.position.z + (section.transform.localScale.z) + wall.transform.localScale.x), Quaternion.identity);
                    e.name = "end";
                    good_path.Push(section);
                    gpd = true;

                    int c = good_path.Count;
                    ret_path = new GameObject[c];
                    name_path = new string[c];
                    for (int i = 0; i < c; i++)
                    {
                        GameObject s = good_path.Pop();
                        ret_path[i] = s;
                        name_path[i] = s.name;

                        //Debug.Log(s.name);
                        //Debug.Log(i);
                        //s.GetComponent<Renderer>().enabled = false;
                    }
                }
                else
                {
                    section_walls.Push(old_section);
                    path.Push(section_walls);
                }
            }
        } */
    }

    public void setFun()
    {
        good_path = this.astack[0];
        ss = this.astack[1];

        int ssc = ss.Count;
        sa = new GameObject[ssc];
        nsa = new string[ssc];
        GameObject ssec;
        for (int i = 0; i < ssc; i++)
        {
            ssec = ss.Pop();
            sa[i] = ssec;
            nsa[i] = ssec.name;
        }

        int c = good_path.Count;
        ret_path = new GameObject[c];
        name_path = new string[c];
        for (int i = 0; i < c; i++)
        {
            GameObject s = good_path.Pop();
            s.GetComponent<attributes>().onGood = true;
            ret_path[i] = s;
            name_path[i] = s.name;
        }

        ac.GetComponent<AI_Creater>().enabled = true;
    }
    public Stack<GameObject>[] pathAlgorithm(GameObject s, GameObject es, GameObject [] full)
    {
        ArrayList secleft = new ArrayList(full.Length);
        for (int z = 0; z < full.Length; z++) {
            secleft.Add(full[z]);
        } 
        GameObject square = s; //section
        Stack<GameObject> correct_path = new Stack<GameObject>(); //good_path
        bool gpd = false;
        Stack<Stack<GameObject>> path = new Stack<Stack<GameObject>>();
        bool first_change = false;
        Stack<GameObject> ss = new Stack<GameObject>();
        GameObject[] section_array; //sa
        string[] name_section_array; //nsa
        Stack<GameObject> section_walls;
        GameObject[] rp; //ret_path
        string[] np; //name_path


        //here we go
        int j = 1;
        bool running = true;
        while (running)
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
                //path.Count != 0
                if (secleft.Count != 0 || path.Count != 0)
                {
                    if (first_change)
                    {
                        if (square.name != es.name)
                        //square.GetComponent<Renderer>().enabled = false;
                        //This is where we set the special spaces
                        square.GetComponent<Renderer>().material = square.GetComponent<attributes>().bad;
                        ss.Push(square);
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
        }

        Debug.Log("The pathmaker ran");
        //TODO PLEASE FOR THE LOVE OF GOD CHANGE THIS BEFORE BACKMAN SEES!!!!!!!
        Stack<GameObject>[] fuckyouunity = new Stack<GameObject>[2];
        fuckyouunity[0] = correct_path;
        fuckyouunity[1] = ss;
        return fuckyouunity;
    }
}
