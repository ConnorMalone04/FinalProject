using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isFiring = false;
    [SerializeField] GameObject bulletPrefab;
    private Transform barrel;
    [SerializeField] float bulletSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        barrel = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        else {
            isFiring = false;
        }

    }

    private void Fire()
    {
        if (!isFiring)
        {
            //Start animation
        }

        Vector3 fireDirection = transform.forward;
        Debug.Log(fireDirection);
        fireDirection = new Vector3(fireDirection.x, fireDirection.y, fireDirection.z).normalized;
        Debug.Log(fireDirection);
        Debug.Log(barrel == null);

        // Why is bullet going kindof diagonal?

        GameObject bullet = Instantiate(bulletPrefab, barrel.position, Quaternion.identity);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = fireDirection * bulletSpeed;

    }
}
