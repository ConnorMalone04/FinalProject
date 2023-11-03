using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isFiring = false;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float bulletSpeed = 10f;
    private float spinTimer = 0f;
    [SerializeField] float bulletDelay = 0.5f;

    private Transform barrel;

    private Vector3 camRot;
    [SerializeField] float rotationSpeed;

    public int health = 100;
    [SerializeField] GameManager gm;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        barrel = transform.GetChild(1).transform;
    }

    // Update is called once per frame
    void Update()
    {

        rotateCam();



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
            animator.SetTrigger("Spin");
            /*
            Transform transform = barrel.transform;
            //Start animation
            Vector3 rot = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 2, transform.eulerAngles.z);
            transform.eulerAngles = rot;
            */
        }
        spinTimer -= 0.01f;

    }

    private void rotateCam()
    {
        camRot.x += Input.GetAxis("Mouse X") * rotationSpeed * 3;
        camRot.y += Input.GetAxis("Mouse Y") * rotationSpeed;

        camRot.x = Mathf.Clamp(camRot.x, -50, 50);
        camRot.y = Mathf.Clamp(camRot.y, -10, 10);

        transform.localRotation = Quaternion.Euler(-camRot.y, camRot.x, 0);
    }

    private void Fire()
    {
        
        Vector3 fireDirection = transform.forward;

        fireDirection = new Vector3(fireDirection.x, fireDirection.y, fireDirection.z).normalized;

        GameObject bullet = Instantiate(bulletPrefab, barrel.position, transform.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = fireDirection * bulletSpeed;
        startSpinTimer();
        health--;
    }

    private void startSpinTimer()
    {
        spinTimer = 1f;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 5;
            if (health <= 0)
            {
                gm.gameOver = true;
            }
        }
    }
}
