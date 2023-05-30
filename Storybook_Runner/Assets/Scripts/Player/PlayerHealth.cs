using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int HealthPoints = 1000;
    public int currentHealth;
   

    public HealthBar healthBar;

    private PlayerCharacterController player;
    
    // Start is called before the first frame update
    void Start()
    {
       
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        player = GetComponent<PlayerCharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
       healthBar.SetHealth(currentHealth);
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

    public void Player_damaged_by_stationary(float damage_done_to_player)
    {
        currentHealth = currentHealth - (int)damage_done_to_player;

        healthBar.SetHealth(currentHealth);
    }

}
