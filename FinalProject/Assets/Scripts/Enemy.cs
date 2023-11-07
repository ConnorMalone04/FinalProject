using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    [SerializeField] GameObject explosion;

    public int health = 100;
    public bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0, 0, 1);

        transform.Translate(movement * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 20;
            if (health <= 0)
            {
                Explode();
                Destroy(gameObject, 0.1f);
            }
        }
    }

    public void Explode()
    {
        GameObject newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(newExplosion,3f);
    }
}
