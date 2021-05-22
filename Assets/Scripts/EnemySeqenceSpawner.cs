using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeqenceSpawner : MonoBehaviour
{
    public GameObject _enemyBasePrefab;
    public static GameObject enemyBasePrefab;

    public WaveSeqence waveSeqence;

    private static EnemySeqenceSpawner instance;

    private void Awake()
    {
        instance = this;
        enemyBasePrefab = _enemyBasePrefab;
    }

    private void Start()
    {
        StartSeqence(waveSeqence);
    }

    public static void StartSeqence(WaveSeqence waveSeqence)
    {

        instance.StartCoroutine(SpawnSeqence(waveSeqence));

    }

    private static IEnumerator SpawnSeqence(WaveSeqence waveSeqence)
    {

        for (int i = 0; i < waveSeqence.waveObjects.Count; i++)
        {
            yield return new WaitForSeconds(waveSeqence.waveObjects[i].spawnDelay);

            SpawnWave(waveSeqence.waveObjects[i].waveObject);
        }
    }

    public static void SpawnWave(WaveObject waveObject)
    {

        waveObject.InstantiateObject();

        //for (int i = 0; i < waveObject.spawnObjects.Count; i++)
        //{
        //    var enemyObject = waveObject.spawnObjects[i].spawnObject.InstantiateObject();
        //}
    }

}
