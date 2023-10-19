using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrain : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject landScape;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cPos = transform.position;

        cPos -= transform.forward * speed * Time.deltaTime;

        transform.position = cPos;

        GameObject[] landscapes = GameObject.FindGameObjectsWithTag("Land");
        foreach (GameObject land in landscapes)
        {
            Vector3 landPos = land.transform.position;
            // 380 ~= length of a landscape
            if (cPos.z < landPos.z - 1000)
            {
                Transform plane = land.transform.Find("Plane");

                //383.7207 is length from start of rail to end of rail, I couldn't
                //find an accurate way to calculate it so I just snapped an object to
                //each end and took the difference
                Instantiate(landScape, new Vector3(0, 0, (float)(landPos.z - (383.7207 * 3))), Quaternion.identity);
                Destroy(land);
            }
            
        }
        
    }
}
