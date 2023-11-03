using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;

    [SerializeField] GameObject enemySpawnerObject;
    private EnemySpawner spawner;
    [SerializeField] Camera camera;

    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        spawner = enemySpawnerObject.GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0) {
            spawner.NewWave();
        }

        slider.value = camera.GetComponent<Player>().health;
    }

    public Transform getCameraTransform()
    {
        return camera.GetComponent<Transform>();
    }

}
