using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteStamina : MonoBehaviour
{
    public int invincibilityTime;

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
            Destroy(this.gameObject);

            StartCoroutine("InfiniteStaminaActive");
        }
    }
      
    IEnumerator InfiniteStaminaActive()
    {
        health.currentHealth = 20000;
        yield return new WaitForSeconds(invincibilityTime);

    }



}
