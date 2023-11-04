using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;

    [SerializeField] GameObject enemySpawnerObject;
    private EnemySpawner spawner;
    [SerializeField] Camera camera;
    private Player player;

    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI waveText;
    private int wave = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawner = enemySpawnerObject.GetComponent<EnemySpawner>();
        player = camera.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0) {
            gameOver = true;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (enemies.Length == 0) {
            spawner.NewWave();
            wave++;
            waveText.text = "Wave " + wave;
        }

        slider.value = player.health;
    }

    public Transform getCameraTransform()
    {
        return camera.GetComponent<Transform>();
    }

}
