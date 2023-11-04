using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        Quaternion rot = transform.rotation;
        Vector3 rotV = new Vector3(rot.eulerAngles.x + 90, rot.eulerAngles.y, rot.eulerAngles.z);
        transform.eulerAngles = rotV;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (camera.GetComponent<Transform>().transform.position.z < transform.position.z - 300)
        {

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
