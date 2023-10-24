using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner.GetComponent<EnemySpawner>().NewWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
