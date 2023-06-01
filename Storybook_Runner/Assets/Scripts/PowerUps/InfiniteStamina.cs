using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteStamina : MonoBehaviour
{
    

   

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
            health.staminaDrain = false;
            health.currentHealth = health.maxHealth;
            Destroy(this.gameObject);

            health.StartingTimer();
        }
    }
      
   



}
