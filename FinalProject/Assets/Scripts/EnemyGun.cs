using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
   public GameObject bulletPrefab;
   [SerializeField] float bulletSpeed = 10f;
   [SerializeField] float spread = 0.02f;
	private float lastAttackTime = 0f;
   private float fireRate = 0.5f;
	private Transform player;
	 
	 void Update()
	 {
        
		if (gameObject.GetComponentInParent<Enemy>().inRange)
		{
            player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
			 //Rotate the enemy towards the player
			transform.rotation = Quaternion.LookRotation(player.position - transform.position, transform.up);
			 
			if (Time.time - lastAttackTime >= 1f/fireRate)
			{
				 shootBullet();
				 lastAttackTime = Time.time;
			}
		}
	 }
	 
     void shootBullet()
     {

        //Shoot the Bullet in the forward direction of the player
    
        Vector3 pos = transform.position;
        //pos = new Vector3(pos.x, pos.y, pos.z - 10);
        GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);


      float x = UnityEngine.Random.Range(-spread, spread);
      float y = UnityEngine.Random.Range(-spread, spread);
      float z = UnityEngine.Random.Range(-spread, spread);


        Vector3 dir = transform.forward;
        Vector3 fireDirection = new Vector3(dir.x + x, dir.y + y, dir.z + z);
        fireDirection = new Vector3(fireDirection.x, fireDirection.y, fireDirection.z).normalized;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = fireDirection * bulletSpeed;
     }
}
