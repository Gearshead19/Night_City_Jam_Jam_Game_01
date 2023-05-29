using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int HealthPoints = 1000;
    public int currentHealth;
   

    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
       
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
       
        
    }

    // Update is called once per frame
    void Update()
    {
       healthBar.SetHealth(currentHealth);
        currentHealth = currentHealth - 1;
        PlayerDead();
    }


    void PlayerDead()
    {
        if(currentHealth <= 0)
        {
            //MenuQuick.ReloadLevel();
            //SceneManager.LoadScene("GameOver");
           
        }
    }
  

    public void Player_damaged_by_stationary(float damage_done_to_player)
    {
        currentHealth = currentHealth - (int)damage_done_to_player;

        healthBar.SetHealth(currentHealth);
    }

}
