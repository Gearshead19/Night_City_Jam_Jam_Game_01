using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject Ground1, Ground2, Ground3, Ground4, Ground5;
    bool hasGround = true;

    public int spawnDistance = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGround)
        {
            SpawnGround();
            hasGround = true;
        }
    }

    public void SpawnGround()
    {
        int randomNum = Random.Range(1, 5);

        if(randomNum == 1)
        {
            Instantiate(Ground1, new Vector3(transform.position.x + spawnDistance, 0f, 0), Quaternion.identity);
        }
        if (randomNum == 2)
        {
            Instantiate(Ground2, new Vector3(transform.position.x + spawnDistance, 1f, 0), Quaternion.identity);
        }
        if (randomNum == 3)
        {
            Instantiate(Ground3, new Vector3(transform.position.x + spawnDistance, -1f, 0), Quaternion.identity);
        }
        if (randomNum == 4)
        {
            Instantiate(Ground4, new Vector3(transform.position.x + spawnDistance, 2f, 0), Quaternion.identity);
        }
        if (randomNum == 5)
        {
            Instantiate(Ground5, new Vector3(transform.position.x + spawnDistance, -2f, 0), Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasGround = true;
        }


    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasGround = false;
        }



    }




}
