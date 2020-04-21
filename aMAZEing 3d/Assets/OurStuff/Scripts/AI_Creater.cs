using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Creater : MonoBehaviour
{
    //This is the varaible that determines the starting section of the spawned AI
    public GameObject cs;

    //This is the list that contains all of the AI objects
    public List<GameObject> ailist;

    //This is the varaible that the AI will change when it dies. It determines spawning new AI
    public bool spawnmore;

    //This is the variables that will choose the cs and will be determined at random
    public int sectionNumber;

    //This is the temp variable that hold the instantiated ai
    public GameObject spawnedai;

    //This is the base prefab for the ai
    public GameObject ai;

    //These are the pathmaker varaibles

    //This is the pathmaker object
    public GameObject pf;

    //This holds all sections possible
    public GameObject[] fullarr;

    //This just holds the sections inside of the good path
    public GameObject[] goodarr;

    //This is the player register;
    public GameObject pr;
    // Start is called before the first frame update
    void Start()
    {
        spawnmore = false;
        fullarr = pf.GetComponent<makepath>().arr;
        updateGood();
        createAI(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnmore)
        {
            createAI(2);
        }
    }

    public void createAI(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (amount == 3)
            {
                sectionNumber = Random.Range(0, goodarr.Length);
                cs = goodarr[sectionNumber];
            } else
            {
                sectionNumber = Random.Range(0, fullarr.Length);
                cs = fullarr[sectionNumber];
            }
            spawnedai = Instantiate(ai);
            spawnedai.name = ailist.Count.ToString();
            ailist.Add(spawnedai);
            updateAI(spawnedai);
        }
    }
    public void updateGood()
    {
        goodarr = pf.GetComponent<makepath>().ret_path;
        for (int i = 0; i < ailist.Count; i++)
        {
            updateAI(ailist[i]);
        }
    }

    public void updateAI(GameObject sa)
    {
        AI_Controller ac = sa.GetComponent<AI_Controller>();
        makepath mp = pf.GetComponent<makepath>();
        ac.fp = mp.arr;
        ac.gp = mp.ret_path;
        ac.startsec = cs;
        ac.currentsec = cs;
        ac.pr = pr;
    }
}
