using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    public bool spawn = false;
    private int wave = 0;
    public int enemiesRemaining;
    private int eToSpawn;

    private void Update()
    {
 
        if (spawn)
        {
            spawnEnemy();
        }
    }

    public void NewWave()
    {
        wave++;

        enemiesRemaining = Mathf.Clamp(wave,0,10);
        eToSpawn = Mathf.Clamp(wave,0,10);
        
        spawn = true;
    }

    void spawnEnemy()
    {
        for (int i = 0; i < eToSpawn; i++) {
            Debug.Log(wave);
            Debug.Log(eToSpawn);
            //Makes the position relative to the parent
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            
            Transform trans = newEnemy.transform;
            Vector3 pos = trans.position;
            if (i == 0) {
                trans.position = new Vector3(pos.x, pos.y, pos.z);
            }
            if (i % 2 == 0) {
                trans.position = new Vector3(pos.x + (i * 4), pos.y, pos.z);
            }
            else {
                trans.position = new Vector3(pos.x - ((i+1) * 4), pos.y, pos.z);
            }

            Vector3 rot = new Vector3(trans.eulerAngles.x, trans.eulerAngles.y + 180, trans.eulerAngles.z + 2);
            trans.eulerAngles = rot;
            enemiesRemaining--;
        }
        spawn = false;
    }
}
