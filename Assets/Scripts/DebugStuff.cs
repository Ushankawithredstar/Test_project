using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugStuff : MonoBehaviour
{
    public Text CreaturesCounter;
    // Start is called before the first frame update
    void Start()
    {
        CreaturesCounter = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CreaturesCounter.text = Spawner.onScene + " creatures";
    }
}