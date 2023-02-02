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
        CreaturesCounter.text = Spawner.SetOnScene + " creatures on scene.\n" + Spawner.toSpawn + " to spawn.";
    }
}
