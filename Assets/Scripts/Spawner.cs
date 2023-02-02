using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterReference;

    private GameObject spawnedMonsters;

    private int randomIndex;
    private int randomSide;

    public static readonly int toSpawnBase = 3;
    public static int toSpawn;

    public static int onScene;

    public static int leftToSpawn;

    [SerializeField] private Transform leftPos, rightPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FirstWaitForWave());
    }

    private void WaveStart()
    {
        Debug.Log("Wave " + Progression.wave + " starting!");
        leftToSpawn = toSpawn;
        Progression.wave++;
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        for (int i = 0; i == toSpawn; i++)
        {

            yield return new WaitForSeconds(Random.Range(1f, 3f));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonsters = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0) //left side
            {
                spawnedMonsters.transform.position = leftPos.position;
                spawnedMonsters.GetComponent<Enemy>().speed = 3f;
                //note: I don't understand how any of this works, it's just copy-pasted.
                onScene++;

                spawnedMonsters.transform.Rotate(0f, 180f, 0f);
            }
            else //right side
            {
                spawnedMonsters.transform.position = rightPos.position;
                spawnedMonsters.GetComponent<Enemy>().speed = -3f;
                onScene++;
            }

            if (i == toSpawn)
            {
                if (onScene == 0)
                {
                        Debug.Log("Ending wave!");
                        WaveEnd();
                }
            }
        }
    }

    private void WaveEnd()
    {
        StopCoroutine(SpawnMonsters());
        Debug.Log("The wave is over.");
        StartCoroutine(WaitForWave());
    }

    IEnumerator WaitForWave()
    {
        Debug.Log("Waiting...");
        yield return new WaitForSeconds(25f);
        toSpawn = Progression.Roll();
        Debug.Log("Spawning " + toSpawn);
        WaveStart();
    }

    IEnumerator FirstWaitForWave()
    {
        toSpawn = 3;
        Progression.wave++;
        Debug.Log("Starting the first wave. Kill all monsters! Spawning " + toSpawn + " creatures.");
        yield return new WaitForSeconds(15f);
        WaveStart();
    }
}