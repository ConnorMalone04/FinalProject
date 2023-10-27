using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    public int health = 100;

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
            Debug.Log("Hit");
            health -= 50;
            if (health <= 0)
            {
                Explode();
                Destroy(gameObject);
            }
        }
    }

    public void Explode()
    {
        //TODO
    }
}
