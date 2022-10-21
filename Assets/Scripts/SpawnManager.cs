using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerupsPrefab;


    public int waveNumber = 0;
    public int enemyCount;


    public int numberToSpawn = 0;

    private float spawnRange = 15.0f;

    private void Update()
    {


        SpawnEnemyWave(numberToSpawn);



    }

    //Spawni okreœlona ilosæ wrogów
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        //aktualizuje libczbê wrogów akutalnie na wyspie
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            numberToSpawn++;
            SpawnPowerup(2);
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                int randomEnemy = Random.Range(0, enemyPrefab.Length);
                Instantiate(enemyPrefab[randomEnemy], GenerateSpawnPosition(), enemyPrefab[randomEnemy].transform.rotation);

            }
        }
    }

    //Generuje losowy punkt do spawnu
    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 rangeToSpawn = new(spawnPosX, 0, spawnPosZ);

        return rangeToSpawn;

    }

    void SpawnPowerup(int howMuchPowerupsToSpawn)
    {
        for (int i = 0; i < howMuchPowerupsToSpawn; i++)
        {
            int randomPowerup = Random.Range(0, powerupsPrefab.Length);
            Instantiate(powerupsPrefab[randomPowerup], GenerateSpawnPosition(), powerupsPrefab[randomPowerup].transform.rotation);

        }
    }
}
