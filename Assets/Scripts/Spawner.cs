using System;
using System.Collections;
using System.Reflection;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterReference;

    private GameObject spawnedMonsters;

    //private int randomIndex;
    private int randomSide;

    private int monsterIndex;

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
        Progression.wave++;
        Debug.Log("Wave " + Progression.wave + " starting!"); //add UI element.
        leftToSpawn = toSpawn;
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        for (int i = 1; i <= toSpawn; i++)
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
                onScene++;
                Debug.Log("onScene value is " + Spawner.onScene);

                spawnedMonsters.transform.Rotate(0f, 180f, 0f);
            }
            else //right side
            {
                spawnedMonsters.transform.position = rightPos.position;
                spawnedMonsters.GetComponent<Enemy>().speed = -3f;
                onScene++;
                Debug.Log("onScene value is " + Spawner.onScene);
            }

            if (i == toSpawn)
            {
                Debug.Log("i == toSpawn");
                WaveEnd();
            }
        }
    }

    private void WaveEnd()
    {
        if (onScene == 0)
        {
            Debug.Log("Don't worry, be happy.");
            StopCoroutine(SpawnMonsters());
            Debug.Log("The wave is over.");
            StartCoroutine(WaitForWave());
        }
    }

    IEnumerator WaitForWave()
    {
        Debug.Log("Waiting...");
        yield return new WaitForSeconds(15f);
        toSpawn = Progression.Roll();
        Debug.Log("Spawning " + toSpawn);
        WaveStart();
    }

    IEnumerator FirstWaitForWave()
    {
        toSpawn = toSpawnBase;
        Debug.Log("Starting the first wave. Kill all monsters! Spawning " + toSpawn + " creatures."); //add UI element.
        yield return new WaitForSeconds(4f);
        WaveStart();
    }
}