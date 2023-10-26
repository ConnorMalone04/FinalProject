using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
        GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        
        Transform trans = newEnemy.transform;

        int rand = Random.Range(0, 40);
        rand = rand - 20;
        Vector3 pos = trans.position;
        trans.position = new Vector3(pos.x + rand, pos.y, pos.z);

        Vector3 rot = new Vector3(trans.eulerAngles.x, trans.eulerAngles.y + 180, trans.eulerAngles.z + 2);
        trans.eulerAngles = rot;

        enemiesRemaining--;
    }
}
