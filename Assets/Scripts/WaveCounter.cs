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
        WaveCounterText.text = "Wave " + Progression.wave + ", Enemies " + Spawner.SetOnScene + "/" + Spawner.leftToSpawn;
    }
}
