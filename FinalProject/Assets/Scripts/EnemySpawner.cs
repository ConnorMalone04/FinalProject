using System;
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

    }

    public void NewWave()
    {
        wave++;

        enemiesRemaining = Mathf.Clamp(wave,0,8);
        eToSpawn = Mathf.Clamp(wave,0,8);
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        for (int i = 0; i < eToSpawn; i++) {
            //Makes the position relative to the parent
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            
            Transform trans = newEnemy.transform;
            Vector3 pos = trans.position;
            if (i == 0) {
                trans.position = new Vector3(pos.x, pos.y + 0.55f, pos.z);
            }
            if (i % 2 == 0) {
                trans.position = new Vector3(pos.x + (i * 4), pos.y + 0.55f, pos.z);
            }
            else {
                trans.position = new Vector3(pos.x - ((i+1) * 4), pos.y + 0.55f, pos.z);
            }

            Vector3 rot = new Vector3(trans.eulerAngles.x, trans.eulerAngles.y + 180, trans.eulerAngles.z + 2);
            trans.eulerAngles = rot;
            enemiesRemaining--;
            yield return new WaitForSeconds(0.4f);
        }
        spawn = false;
    }
}
