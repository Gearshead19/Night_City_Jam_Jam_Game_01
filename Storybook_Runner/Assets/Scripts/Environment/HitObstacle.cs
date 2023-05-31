using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObstacle : MonoBehaviour
{

    public int damagePlayer = 0;

    private PlayerHealth health;






    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            health.currentHealth = health.currentHealth - damagePlayer;
            Destroy(this.gameObject);
        }
    }

}
