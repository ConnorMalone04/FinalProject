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

    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject menuButton;
    private int wave = 0;
    private GameObject[] enemies;
    [SerializeField] GameObject train;

    // Start is called before the first frame update
    void Start()
    {
        spawner = enemySpawnerObject.GetComponent<EnemySpawner>();
        player = camera.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (player.health <= 0) {
            GameOver();
        }
        
        else if (enemies.Length == 0) {
            spawner.NewWave();
            player.health = 100;
            wave++;
            waveText.text = "Wave " + wave;
        }

        slider.value = player.health;
    }

    public Transform getCameraTransform()
    {
        return camera.GetComponent<Transform>();
    }

    private void GameOver() {
        if (!gameOver) {
            Debug.Log("GameOver");
            gameOver = true;
            deathScreen.GetComponent<DeathScreen>().gameOver = true;
            menuButton.SetActive(true);

            foreach (GameObject e in enemies) {
                Destroy(e);
            }
            train.GetComponent<MoveTrain>().speed = 0f;
        }
    }

}
