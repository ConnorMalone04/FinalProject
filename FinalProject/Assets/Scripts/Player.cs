using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isFiring = false;
    [SerializeField] GameObject bulletPrefab;
    private Transform barrel;
    [SerializeField] float bulletSpeed = 10f;
    private float spinTimer = 0f;
    [SerializeField] float bulletDelay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        barrel = transform.GetChild(0);
        if (Input.GetButton("Fire1"))
        {
            if (spinTimer < bulletDelay)
            {
                Fire();
            }
            
            isFiring = true;
        }
        else {
            if (spinTimer <= 0)
            {
                isFiring = false;
            }
            
        }
        if (isFiring)
        {
            //Start animation
            Vector3 rot = new Vector3(barrel.eulerAngles.x, barrel.eulerAngles.y, barrel.eulerAngles.z + 2);
            barrel.eulerAngles = rot;
        }
        spinTimer -= 0.01f;

    }

    private void Fire()
    {
        

        Vector3 fireDirection = transform.forward;
        Debug.Log(fireDirection);
        fireDirection = new Vector3(fireDirection.x, fireDirection.y, fireDirection.z).normalized;
        Debug.Log(fireDirection);
        Debug.Log(barrel == null);

        // Why is bullet going kindof diagonal?

        GameObject bullet = Instantiate(bulletPrefab, barrel.position, Quaternion.identity);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = fireDirection * bulletSpeed;
        startSpinTimer();
    }
    private void startSpinTimer()
    {
        spinTimer = 1f;
    }
}
