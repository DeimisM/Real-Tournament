using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<GameObject> spawnPoints;


    public int enemiesToSpawn;
    [Range(0.1f, 10f)]
    public float spawnInterval = 1f;


    public List<int> enemiesPerWave;
    [Range(1f, 20f)]
    public float timeBetweenWaves = 5f;

    public UnityEvent onWaveStart;
    public UnityEvent onWaveEnd;
    public UnityEvent onWavesCleared;


    private async void Start()
    {
        foreach(var num in enemiesPerWave)
        {
            enemiesToSpawn = num;
            onWaveStart.Invoke();

            //while(true)                         // pavojinga naudoti while(true) - gali crash. Kadangi naudojami async await - siuo atveju galima
            while (enemiesToSpawn > 0)
            {
                await new WaitForSeconds(spawnInterval);
                Spawn();
                enemiesToSpawn--;
            }

            onWaveEnd.Invoke();
            await new WaitForSeconds(timeBetweenWaves);
        }

        onWavesCleared.Invoke();
    }

    void Spawn()
    {
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
