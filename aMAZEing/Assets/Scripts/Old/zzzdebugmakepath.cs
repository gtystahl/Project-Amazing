using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zzzdebugmakepath : MonoBehaviour
{
    // This is the current section that the algorithm is on
    public GameObject section;
    public Stack<GameObject> section_walls;
    public Stack<Stack<GameObject>> path = new Stack<Stack<GameObject>>();
    public GameObject mazemaker;
    public GameObject end_section;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        Debug.Log("Hello World");
        Debug.Log("Hello World");

        // This needs to keep running until the algorithm finds its way out.
        mazecreater com;
        com = mazemaker.GetComponent<mazecreater>();
        int mx = com.mazex;
        int mz = com.mazez;
        int diment = mx * mz;
        GameObject[] arr = com.full_section_list;
        int end_num = Random.Range((diment - mx), (diment));
        int start_num = Random.Range(0, mx);
        end_section = arr[end_num];
        section = arr[start_num];
        section.GetComponent<attributes>().visited = true;
        section.GetComponent<Renderer>().enabled = false;

        //sudo debug code
        int j = 1;
    }
    void Update()
    {
        Debug.Log(section.name);
        int possibles = section.GetComponent<attributes>().paths;
        int iter;
        if (possibles == 0)
        {
            //sudo stuff goes here
            Stack<GameObject> sectlst;
            GameObject w;
            if (path.Count != 0)
            {
                sectlst = path.Pop();
                section = sectlst.Pop();
                section.GetComponent<attributes>().visited = true;
                section.GetComponent<Renderer>().enabled = false;
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
            }
            else
            {
                //running = false;
                Debug.Log("done");
            }
        }
        else
        {
            iter = Random.Range(0, possibles);


            section_walls = new Stack<GameObject>();
            GameObject old_section = section;

            //move top
            GameObject wall = old_section.GetComponent<attributes>().topwall;
            if (wall.GetComponent<wall_attributes>().movable)
            {

                if (iter == 0)
                {

                    wall.transform.position += new Vector3(0, -1, 0);
                    wall.GetComponent<wall_attributes>().movable = false;
                    wall.GetComponent<Renderer>().enabled = false;
                    //section.GetComponent<attributes>().paths -= 1;

                    GameObject[] nexts = wall.GetComponent<wall_attributes>().connections;
                    for (int i = 0; i < nexts.Length; i++)
                    {
                        nexts[i].GetComponent<attributes>().paths -= 1;
                        if (nexts[i].GetComponent<attributes>().sectionNumber != old_section.GetComponent<attributes>().sectionNumber)
                        {
                            section = nexts[i];
                            section.GetComponent<attributes>().visited = true;
                            section.GetComponent<Renderer>().enabled = false;
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

            //move right
            wall = old_section.GetComponent<attributes>().rightwall;
            if (wall.GetComponent<wall_attributes>().movable)
            {
                if (iter == 0)
                {
                    wall.transform.position += new Vector3(0, -1, 0);
                    wall.GetComponent<wall_attributes>().movable = false;
                    wall.GetComponent<Renderer>().enabled = false;
                    //section.GetComponent<attributes>().paths -= 1;

                    GameObject[] nexts = wall.GetComponent<wall_attributes>().connections;
                    for (int i = 0; i < nexts.Length; i++)
                    {
                        nexts[i].GetComponent<attributes>().paths -= 1;
                        if (nexts[i].GetComponent<attributes>().sectionNumber != old_section.GetComponent<attributes>().sectionNumber)
                        {
                            section = nexts[i];
                            section.GetComponent<attributes>().visited = true;
                            section.GetComponent<Renderer>().enabled = false;
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

            //move down
            wall = old_section.GetComponent<attributes>().bottomwall;
            if (wall.GetComponent<wall_attributes>().movable)
            {
                if (iter == 0)
                {
                    wall.transform.position += new Vector3(0, -1, 0);
                    wall.GetComponent<wall_attributes>().movable = false;
                    wall.GetComponent<Renderer>().enabled = false;
                    //section.GetComponent<attributes>().paths -= 1;

                    GameObject[] nexts = wall.GetComponent<wall_attributes>().connections;
                    for (int i = 0; i < nexts.Length; i++)
                    {
                        nexts[i].GetComponent<attributes>().paths -= 1;
                        if (nexts[i].GetComponent<attributes>().sectionNumber != old_section.GetComponent<attributes>().sectionNumber)
                        {
                            section = nexts[i];
                            section.GetComponent<attributes>().visited = true;
                            section.GetComponent<Renderer>().enabled = false;
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

            // move left
            wall = old_section.GetComponent<attributes>().leftwall;
            if (wall.GetComponent<wall_attributes>().movable)
            {
                if (iter == 0)
                {
                    wall.transform.position += new Vector3(0, -1, 0);
                    wall.GetComponent<wall_attributes>().movable = false;
                    wall.GetComponent<Renderer>().enabled = false;
                    //section.GetComponent<attributes>().paths -= 1;

                    GameObject[] nexts = wall.GetComponent<wall_attributes>().connections;
                    for (int i = 0; i < nexts.Length; i++)
                    {
                        nexts[i].GetComponent<attributes>().paths -= 1;
                        if (nexts[i].GetComponent<attributes>().sectionNumber != old_section.GetComponent<attributes>().sectionNumber)
                        {
                            section = nexts[i];
                            section.GetComponent<attributes>().visited = true;
                            section.GetComponent<Renderer>().enabled = false;
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

            if (section == end_section)
            {
                // Lets the Algorithm know this is a bad path and time to start moving backwards
                wall = section.GetComponent<attributes>().topwall;
                wall.transform.position += new Vector3(0, -1, 0);
                //running = false;

            }
            else
            {
                section_walls.Push(old_section);
                path.Push(section_walls);
            }
            /*
            if (j == 200)
            {
                running = false;
            }
            else
            {
                j++;
            }
            */
        }
    }
}

    // Update is called once per frame

