using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int HealthPoints = 1000;
    public int currentHealth;
    public bool staminaDrain;
    public int invincibilityTime;

    public HealthBar healthBar;

    private PlayerCharacterController player;
    
    // Start is called before the first frame update
    void Start()
    {
        staminaDrain = true;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        player = GetComponent<PlayerCharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
       healthBar.SetHealth(currentHealth);
        if (staminaDrain == true)
        {
            DraingStamina();

        }
        else if (currentHealth <= 0)
        {
            player.runSpeed = 0;
            player.GameOver();
        }
        
       
    }

    public void DraingStamina()
    {
        
        currentHealth = currentHealth - 1;

        if (currentHealth > 10000)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            player.runSpeed = 0;
            player.GameOver();
        }

    }
    public void StartingTimer()
    {
        StartCoroutine("InfiniteStaminaActive");
    }
    IEnumerator InfiniteStaminaActive()
    {
        if (staminaDrain == false)
        {
            
            yield return new WaitForSeconds(invincibilityTime);
            
            staminaDrain = true;
        }


    }

}
