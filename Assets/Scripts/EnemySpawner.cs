using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyWalkerPrefab;
    //public GameObject enemyGunnerPrefab;
    int amountOfWalkers;
    int amountOfGunners;
    private float remainingTime =0;
    public float spawnTimer = 5;
    string spawnSide;
    void Start()
    {
        amountOfWalkers = 5;
        amountOfGunners = 3;

    }

    
    void Update()
    {
        remainingTime -= Time.deltaTime;

        if(remainingTime <=0)
        {
            SpawnEnemy();
            remainingTime = spawnTimer;
        }
    }

    void SpawnEnemy()
    {
        //randomly pick which sied of the screen it should spawn
        int randomS = Random.Range(1, 4);
        
        if (randomS == 1)
            spawnSide = "Top";
        if (randomS == 2)
            spawnSide = "Right";
        if (randomS == 3)
            spawnSide = "Bottom";
        if (randomS == 4)
            spawnSide = "Left";
        //Spawn an enemy somewhere on the picked side
        Vector3 spawnPositionEnemyWalker= new Vector3(0,0,0);
        if (randomS == 1)
        {
            spawnPositionEnemyWalker = new Vector3(Random.Range(-15, 15), 8.5f, 0);
        }
        if (randomS == 3)
        {
            spawnPositionEnemyWalker = new Vector3(Random.Range(-15, 15), -8.5f, 0);
        }
        if (randomS == 2)
        {
            spawnPositionEnemyWalker = new Vector3(15, Random.Range(-8.5f, 8.5f), 0);
        }
        if (randomS == 4)
        {
            spawnPositionEnemyWalker = new Vector3(-15, Random.Range(-8.5f, 8.5f), 0);
        }

        GameObject enemy = Instantiate(enemyWalkerPrefab, spawnPositionEnemyWalker, enemyWalkerPrefab.transform.rotation);
        enemy.GetComponent<Enemy>().playerTransform = Movement.t;
    }



    public void ChangeSpawnTimer(float waveTime)
    {
        //
        spawnTimer = waveTime / amountOfWalkers;
    }


}
