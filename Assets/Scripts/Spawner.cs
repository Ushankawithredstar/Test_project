using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterReference;

    private GameObject spawnedMonsters;

    //private int randomIndex;
    private int randomSide;

    private int monsterIndex;

    public static readonly int ToSpawnBase = 3;
    public static int ToSpawn;

    private static int onScene = 0;

    public static int SetOnScene
    {
        get { return onScene; }
        set { onScene = value; }
    }

    //if true, wave ends.
    private bool EndWave = Enemy.Killed == ToSpawn;

    public static int leftToSpawn;

    [SerializeField] private Transform leftPos, rightPos;

    // Start is called before the first frame update
    void Start()
    {
        Enemy.Killed = 0;
        StartCoroutine(FirstWaitForWave());
    }
    private void Update()
    {
        if (EndWave == true)
        {
            Enemy.Killed = 0;
            WaveEnd();
        }
    }

    private void WaveStart()
    {
        Progression.wave++;
        //add UI element.
        Debug.Log("Wave " + Progression.wave + " starting!"); 
        leftToSpawn = ToSpawn;
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        for (int i = 1; i <= ToSpawn; i++)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 3f));

            if (Progression.wave < 10)
                monsterIndex = UnityEngine.Random.Range(0, Progression.wave / 2);
            else
                monsterIndex = UnityEngine.Random.Range(0, monsterReference.Length);

            //randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = UnityEngine.Random.Range(0, 2);

            spawnedMonsters = Instantiate(monsterReference[monsterIndex]);

            if (randomSide == 0) //left side
            {
                spawnedMonsters.transform.position = leftPos.position;
                spawnedMonsters.GetComponent<Enemy>().speed = 3f;
                SetOnScene++;

                spawnedMonsters.transform.Rotate(0f, 180f, 0f);
            }
            else //right side
            {
                spawnedMonsters.transform.position = rightPos.position;
                spawnedMonsters.GetComponent<Enemy>().speed = -3f;
                SetOnScene++;
            }
        }
    }

    private void WaveEnd()
    {
        //Debug.Log("Don't worry, be happy.");
        StopCoroutine(SpawnMonsters());
        //Debug.Log("The wave is over.");
        StartCoroutine(WaitForWave());
    }

    IEnumerator WaitForWave()
    {
        //Debug.Log("Waiting...");
        yield return new WaitForSeconds(15f);
        ToSpawn = Progression.Roll();
        //Debug.Log("Spawning " + toSpawn);
        WaveStart();
    }

    IEnumerator FirstWaitForWave()
    {
        ToSpawn = ToSpawnBase;
        //Debug.Log("Starting the first wave. Kill all monsters! Spawning " + toSpawn + " creatures.");
        yield return new WaitForSeconds(4f);
        WaveStart();
    }
}