using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazedim : MonoBehaviour
{
    public static int mazexdim;
    public static int mazezdim;

    public int displayx;
    public int displayz;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Making sure this script runs");
        displayx = mazexdim;
        displayz = mazezdim;
    }

    /* Checking to see if it changed
    private void Update()
    {
        Debug.Log(mazexdim);
    }
    */
    public void changedim(int x, int y)
    {
        mazexdim = x;
        mazezdim = y;
    }
}
