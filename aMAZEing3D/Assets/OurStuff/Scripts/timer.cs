using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timertext;
    public float t;
    public int T;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        T = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        //The T below is the one that needs to be displayed
        T = Mathf.RoundToInt(t);

        string minutes = ((int)t /60).ToString();
        string seconds =(t%60).ToString("f2");

        timertext.text = minutes + ":" + seconds;
    }
}
