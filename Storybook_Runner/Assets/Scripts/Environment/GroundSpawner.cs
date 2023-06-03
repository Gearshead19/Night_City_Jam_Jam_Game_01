using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [Tooltip("These are the prefabs for endless spawning Grounds")]
    [Header("Ground Prefabs")]
    public GameObject Ground1, Ground2, Ground3, Ground4, Ground5;
    [Header("Ground Prefabs")]
    public GameObject Ground6, Ground7, Ground8, Ground9, Ground10;
    [Header("Ground Prefabs")]
    public GameObject Ground11, Ground12, Ground13, Ground14, Ground15;

    [Tooltip("This variable is used to space out the newly spawned in ground prefabs")]
    [Header("Spawn Distance")]
    public int spawnDistance = 0;

    [Tooltip("These are the Heights each individual ground prefab can spawn at")]
    [Header("Spawn Heights")]
    public float spawnHeight_01 = 0f;
    public float spawnHeight_02 = 0f;
    public float spawnHeight_03 = 0f;
    public float spawnHeight_04 = 0f;
    public float spawnHeight_05 = 0f;

    bool hasGround = true;

    [Header("Ground States")]
    public bool darkGround = true;
    public bool inBetweenGround = false;
    public bool lightGround = false;


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
        if (darkGround == true )
        {
            if (randomNum == 1)
            {
                Instantiate(Ground1, new Vector3(transform.position.x + spawnDistance, spawnHeight_01, 0), Quaternion.identity);
            }
            if (randomNum == 2)
            {
                Instantiate(Ground2, new Vector3(transform.position.x + spawnDistance, spawnHeight_02, 0), Quaternion.identity);
            }
            if (randomNum == 3)
            {
                Instantiate(Ground3, new Vector3(transform.position.x + spawnDistance, spawnHeight_03, 0), Quaternion.identity);
            }
            if (randomNum == 4)
            {
                Instantiate(Ground4, new Vector3(transform.position.x + spawnDistance, spawnHeight_04, 0), Quaternion.identity);
            }
            if (randomNum == 5)
            {
                Instantiate(Ground5, new Vector3(transform.position.x + spawnDistance, spawnHeight_05, 0), Quaternion.identity);
            }

        }
        if (inBetweenGround == true ) 
        {
            if (randomNum == 1)
            {
                Instantiate(Ground6, new Vector3(transform.position.x + spawnDistance, spawnHeight_01, 0), Quaternion.identity);
            }
            if (randomNum == 2)
            {
                Instantiate(Ground7, new Vector3(transform.position.x + spawnDistance, spawnHeight_02, 0), Quaternion.identity);
            }
            if (randomNum == 3)
            {
                Instantiate(Ground8, new Vector3(transform.position.x + spawnDistance, spawnHeight_03, 0), Quaternion.identity);
            }
            if (randomNum == 4)
            {
                Instantiate(Ground9, new Vector3(transform.position.x + spawnDistance, spawnHeight_04, 0), Quaternion.identity);
            }
            if (randomNum == 5)
            {
                Instantiate(Ground10, new Vector3(transform.position.x + spawnDistance, spawnHeight_05, 0), Quaternion.identity);
            }
        }
        if (lightGround == true ) 
        {
            if (randomNum == 1)
            {
                Instantiate(Ground11, new Vector3(transform.position.x + spawnDistance, spawnHeight_01, 0), Quaternion.identity);
            }
            if (randomNum == 2)
            {
                Instantiate(Ground12, new Vector3(transform.position.x + spawnDistance, spawnHeight_02, 0), Quaternion.identity);
            }
            if (randomNum == 3)
            {
                Instantiate(Ground13, new Vector3(transform.position.x + spawnDistance, spawnHeight_03, 0), Quaternion.identity);
            }
            if (randomNum == 4)
            {
                Instantiate(Ground14, new Vector3(transform.position.x + spawnDistance, spawnHeight_04, 0), Quaternion.identity);
            }
            if (randomNum == 5)
            {
                Instantiate(Ground15, new Vector3(transform.position.x + spawnDistance, spawnHeight_05, 0), Quaternion.identity);
            }
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
    public void InbetweenOn()
    {
        darkGround = false;
        inBetweenGround = true;
    }

    public void LightOn()
    {
        inBetweenGround = false;
        lightGround = true;
    }

}
