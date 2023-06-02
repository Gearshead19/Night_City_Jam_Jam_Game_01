using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObstacle : MonoBehaviour
{

    public int damagePlayer = 0;

    private PlayerHealth health;

    private ObstacleHitSFX obstacleHitSFX;




    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<PlayerHealth>();
        obstacleHitSFX = FindObjectOfType<ObstacleHitSFX>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            obstacleHitSFX.ObstacleHitSFXPlay();
            if(health.staminaDrain == true)
            {
                health.currentHealth = health.currentHealth - damagePlayer;
                Destroy(this.gameObject);
            }
            else
                Destroy(this.gameObject);

        }
    }

}
