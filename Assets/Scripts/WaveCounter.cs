using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    public Text WaveCounterText;

    // Start is called before the first frame update
    void Start()
    {
        WaveCounterText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Spawner.leftToSpawn = Spawner.toSpawn;
        WaveCounterText.text = "Wave " + Progression.wave + ", Enemies " + Spawner.onScene + "/" + Spawner.leftToSpawn;
    }
}
