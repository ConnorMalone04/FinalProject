using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;

    [SerializeField] GameObject enemySpawner;
    private GameObject[] enemies;
    public int enemyCount;

    [SerializeField] Camera camera;

    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner.GetComponent<EnemySpawner>().NewWave();
    }

    // Update is called once per frame
    void Update()
    {
        // count enemies
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;

        slider.value = camera.GetComponent<Player>().health;
    }

    public Transform getCameraTransform()
    {
        return camera.GetComponent<Transform>();
    }

}
