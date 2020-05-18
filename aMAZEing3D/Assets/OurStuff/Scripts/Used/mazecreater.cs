using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mazecreater : MonoBehaviour
{
    // The number of mazes that the user will specify
    public int mazex;
    public int mazez;

    // The width and length of the box (They should be the same)
    public float boxx;
    public float boxz;

    // This is where the first section object will be placed
    public float startx;
    public float startz;

    // This is the section Gameobjects that will be specified in the unity window
    public GameObject piece;
    public GameObject fence;
    public GameObject post;


    // These are for loop variables
    public float newx;
    public float newz;
    public int iterationz = 0;
    public int iterationx = 0;
    public int totaliteration = 0;
    public GameObject[] topline;
    public GameObject[] bottomline;

    // This is the array that has all of the sections in it
    public GameObject[] full_section_list;

    //This is the static varaibles taken from the difficulties screen
    public GameObject stat;
    // Start is called before the first frame update
    void Start()
    {
        // Sets the start position of the box based on some math


        mazex = stat.GetComponent<mazedim>().displayx;
        mazez = stat.GetComponent<mazedim>().displayz;

        startx = 0;
        startz = 0;

        int wall_num = 100;

        topline = new GameObject[mazex];
        bottomline = new GameObject[mazex];
        full_section_list = new GameObject[(mazex * mazez)];

        float wall_thickness = fence.transform.localScale.x;
        float wall_height = fence.transform.localScale.y / 2;
        float wall_length = fence.transform.localScale.z / 2;
        float sect_length = piece.transform.localScale.z / 2; //2
        float post_thickness = wall_thickness / 2; 
        boxx = piece.transform.localScale.x; //10
        boxz = piece.transform.localScale.z; //10

        Debug.Log(wall_thickness);
        Debug.Log(wall_height);
        Debug.Log(wall_length);
        Debug.Log(sect_length);
        // This will make the number of boxes equal to boxx times boxy
        for (float z = startz; z < boxz * mazez; z += boxz)
        {
            iterationx = 0;
            for(float x = startx; x < boxx * mazex; x += boxx)
            {
                newx = x;
                newz = z;

                GameObject sect;
                GameObject hor;
                GameObject ver;
                GameObject p;


                sect = Instantiate(piece, new Vector3(newx + wall_thickness * iterationx, -.1f, newz + wall_thickness * iterationz), Quaternion.identity);
                sect.name = totaliteration.ToString();

                ver = Instantiate(fence, new Vector3((newx + wall_thickness * iterationx) + (boxx / 2) + (wall_thickness / 2), wall_height, (newz + wall_thickness * iterationz)), Quaternion.identity);
                p = Instantiate(post, new Vector3(ver.transform.position.x, wall_height, ver.transform.position.z + wall_length + post_thickness), Quaternion.identity);
                p.transform.localScale = new Vector3(wall_thickness, wall_height * 2, wall_thickness);
                wall_num++;
                ver.name = wall_num.ToString();

                if ((newx + boxx) != boxx * mazex) {
                    ver.GetComponent<wall_attributes>().connections[0] = sect;
                }
                else
                {
                    ver.GetComponent<wall_attributes>().movable = false;
                    sect.GetComponent<attributes>().paths -= 1;
                }

                sect.GetComponent<attributes>().rightwall = ver;

                hor = Instantiate(fence, new Vector3((newx + wall_thickness * iterationx), wall_height, (newz + wall_thickness * iterationz) + (boxz / 2) + (wall_thickness / 2)), Quaternion.Euler(0, 90, 0));
                p = Instantiate(post, new Vector3(hor.transform.position.x - wall_length - post_thickness, wall_height, hor.transform.position.z), Quaternion.identity);
                p.transform.localScale = new Vector3(wall_thickness, wall_height * 2, wall_thickness);
                wall_num++;
                hor.name = wall_num.ToString();

                if ((newz + boxz) != boxz * mazez)
                {
                    hor.GetComponent<wall_attributes>().connections[0] = sect;
                }
                else
                {
                    hor.GetComponent<wall_attributes>().movable = false;
                    sect.GetComponent<attributes>().paths -= 1;
                }

                sect.GetComponent<attributes>().topwall = hor;

                if (z == startz)
                {
                    GameObject edge;
                    edge = Instantiate(fence, new Vector3((newx + wall_thickness * iterationx), wall_height, (newz + wall_thickness * iterationz) - (boxz / 2) - (wall_thickness / 2)), Quaternion.Euler(0, 90, 0));
                    edge.GetComponent<wall_attributes>().outside = true;
                    //edge.GetComponent<Renderer>().enabled = false;
                    p = Instantiate(post, new Vector3(edge.transform.position.x + wall_length + post_thickness, wall_height, edge.transform.position.z), Quaternion.identity);
                    p.transform.localScale = new Vector3(wall_thickness, wall_height * 2, wall_thickness);
                    wall_num++;
                    edge.name = wall_num.ToString();

                    //edge.GetComponent<wall_attributes>().connections[0] = sect;
                    sect.GetComponent<attributes>().bottomwall = edge;
                    edge.GetComponent<wall_attributes>().movable = false;
                    sect.GetComponent<attributes>().paths -= 1;
                }
                else
                {
                    GameObject tw = topline[iterationx].GetComponent<attributes>().topwall;
                    sect.GetComponent<attributes>().bottomwall = tw;
                    tw.GetComponent<wall_attributes>().connections[1] = sect;
                }


                if (x == startx)
                {
                    GameObject edge;
                    edge = Instantiate(fence, new Vector3((newx + wall_thickness * iterationx) - (boxx / 2) - (wall_thickness / 2), wall_height, (newz + wall_thickness * iterationz)), Quaternion.identity);
                    edge.GetComponent<wall_attributes>().outside = true;
                    //edge.GetComponent<Renderer>().enabled = false;
                    p = Instantiate(post, new Vector3(edge.transform.position.x, wall_height, edge.transform.position.z - wall_length - post_thickness), Quaternion.identity);
                    p.transform.localScale = new Vector3(wall_thickness, wall_height * 2, wall_thickness);
                    wall_num++;
                    edge.name = wall_num.ToString();

                    sect.GetComponent<attributes>().leftwall = edge;
                    edge.GetComponent<wall_attributes>().movable = false;
                    sect.GetComponent<attributes>().paths -= 1;
                }
                else
                {
                    GameObject rw = bottomline[iterationx - 1].GetComponent<attributes>().rightwall;
                    sect.GetComponent<attributes>().leftwall = rw;
                    rw.GetComponent<wall_attributes>().connections[1] = sect;
                }

                sect.GetComponent<attributes>().sectionNumber = totaliteration;
                if (z + boxz == boxz * mazez)
                {
                    sect.GetComponent<attributes>().topwall.GetComponent<wall_attributes>().outside = true;
                    //sect.GetComponent<attributes>().topwall.GetComponent<Renderer>().enabled = false;
                }

                if (x + boxx == boxx * mazex)
                {
                    sect.GetComponent<attributes>().rightwall.GetComponent<wall_attributes>().outside = true;
                    //sect.GetComponent<attributes>().rightwall.GetComponent<Renderer>().enabled = false;
                }


                if (z == startz)
                {
                    topline[iterationx] = sect;
                    bottomline[iterationx] = sect;
                }
                else
                {
                    bottomline[iterationx] = sect;
                }

                full_section_list[totaliteration] = sect;

                totaliteration++;

                iterationx++;

            }

            if (z != startz)
            {
                topline = bottomline;
            }

            iterationz++;
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
