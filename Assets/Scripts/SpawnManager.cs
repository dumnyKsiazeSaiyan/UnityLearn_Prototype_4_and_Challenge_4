using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;


    public int waveNumber = 0;
    public int numberOfEnemyOnIsland;


    public int numberToSpawn = 0;

    private float spawnRange = 15;
    private void Update()
    {


        SpawnEnemy(numberToSpawn);



    }

    //Spawni okreœlona ilosæ wrogów
    void SpawnEnemy(int amountEnemy)
    {
        //aktualizuje libczbê wrogów akutalnie na wyspie
        numberOfEnemyOnIsland = FindObjectsOfType<Enemy>().Length;

        if (numberOfEnemyOnIsland == 0)
        {
            waveNumber++;
            numberToSpawn++;
            for (int i = 0; i < amountEnemy; i++)
            {
                Instantiate(enemyPrefab[0], GenerateSpawnPosition(), enemyPrefab[0].transform.rotation);

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
}
