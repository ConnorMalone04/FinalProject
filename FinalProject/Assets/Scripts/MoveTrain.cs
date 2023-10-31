using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrain : MonoBehaviour
{
    public float speed = 1f;
    [SerializeField] GameObject landScape;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cPos = transform.position;

        Vector3 movement = new Vector3(0, 0, -1);
        transform.Translate(movement * speed * Time.deltaTime);

        GameObject[] landscapes = GameObject.FindGameObjectsWithTag("Land");
        foreach (GameObject land in landscapes)
        {
            Vector3 landPos = land.transform.position;
            // 380 ~= length of a landscape
            if (cPos.z < landPos.z - 1000)
            {

                //383.7207 is length from start of rail to end of rail, I couldn't
                //find an accurate way to calculate it so I just snapped an object to
                //each end and took the difference
                Instantiate(landScape, new Vector3(0, 0, (float)(landPos.z - (383.7207 * 3))), Quaternion.identity);
                Destroy(land);
            }
            
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger");
        if (other.tag == "Enemy")
        {
            float enemySpeed = other.gameObject.GetComponent<Enemy>().speed;
            Debug.Log("In Range");
            if (enemySpeed >= speed) {
                enemySpeed -= 50 *Time.deltaTime;
                other.gameObject.GetComponent<Enemy>().speed = enemySpeed;
            }
        }
    }
}
