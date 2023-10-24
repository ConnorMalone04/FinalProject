using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, 40);
        rand -= 20;

        Vector3 pos = transform.position;
        Vector3 enemyPos = new Vector3(pos.x + rand, pos.y, pos.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos -= new Vector3(0, 0, 1) * speed * Time.deltaTime;

        transform.position = pos;
    }
}
