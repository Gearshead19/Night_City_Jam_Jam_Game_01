using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacles")]
    [Tooltip("These are the obstacles that will spawn over the ground prefabs")]
    public GameObject obstacle1, obstacle2, obstacle3;

    [Header("Spawn Time")]
    [Tooltip("Time in-between spawn-ins of obstacles")]
    public float obstacleSpawnInterval = 2.5f;

    [Header("Drop Heaight of Spawns")]
    [Tooltip("The prefabs will spawn at this Y position over the grounds")]
    public float obstacleHeightSpawnIn;







    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstaclesOverTime");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacterController>().isGameOver)
        {
            StopCoroutine("SpawnObstaclesOverTime");
        }
    }

    private void SpawnObstacle()
    {
        int random = Random.Range(1, 4);

        if(random == 1)
        {
            Instantiate(obstacle1, new Vector3(transform.position.x, obstacleHeightSpawnIn, 0), Quaternion.identity);
        }
        else if (random == 2) 
        {
            Instantiate(obstacle2, new Vector3(transform.position.x, obstacleHeightSpawnIn, 0), Quaternion.identity);
        }
        else if (random == 3)
        {
            Instantiate(obstacle3, new Vector3(transform.position.x, obstacleHeightSpawnIn, 0), Quaternion.identity);
        }
    }

    IEnumerator SpawnObstaclesOverTime()
    {
        while(true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(obstacleSpawnInterval);
        }
    }




}
