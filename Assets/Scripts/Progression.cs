using UnityEngine;
using UnityEngine.UI;

public class Progression : MonoBehaviour
{

    public static int score;

    public static int wave;

    public static int rollResult;

    public Text ScoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        ScoreCounter = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreCounter.text = "Score: " + score;
    }

    public static int Roll()
    {
        if (score == 0)
            return Spawner.toSpawnBase;
        else if (wave > 1 && wave <= 10)
            return (int)(Spawner.toSpawnBase + (Random.Range(2, 3) * score * 0.2f));
        else if (wave > 10 || wave <= 20)
            return (int)(Spawner.toSpawnBase + (Random.Range(3, 5) * score * 0.25f));
        else
            return (int)(Spawner.toSpawnBase + (Random.Range(4, 7) * score * 0.3f));
    }
}
