using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaUp : MonoBehaviour
{

    private PlayerHealth health;
    private StaminaUPSFX staminaUpSound;

    // Start is called before the first frame update
    void Start()
    {
       health = FindObjectOfType<PlayerHealth>();
       staminaUpSound = FindObjectOfType<StaminaUPSFX>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            staminaUpSound.StaminaUPSFXPlay();
            if (health.currentHealth >= 10000)
            {
                health.currentHealth = health.maxHealth;
            }
            else
            {
                health.currentHealth = health.currentHealth + 2000;
            }
            Destroy(this.gameObject);
        }
    }
  
}
