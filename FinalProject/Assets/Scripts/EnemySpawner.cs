using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnDelay = 1f;

    private float timer = 0f;
    public bool spawn = false;
    private int wave = 10;
    private int enemiesRemaining;

    private void Update()
    {
 
        if (spawn)
        {
            if (enemiesRemaining > 0)
            {
                if (timer >= spawnDelay)
                {
                    spawnEnemy();
                    timer = 0f;
                }
                timer += Time.deltaTime;
            }
            else
            {
                spawn = false;
            }
        }
    }

    public void NewWave()
    {
        wave++;
        enemiesRemaining = wave;
        spawn = true;
    }

    void spawnEnemy()
    {
        

        //Makes the position relative to the parent
        Instantiate(enemy, transform, worldPositionStays: false);

        enemiesRemaining--;
    }
}
