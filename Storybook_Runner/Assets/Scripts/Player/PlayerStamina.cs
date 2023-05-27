using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStamina : MonoBehaviour
{
    public HealthBar staminaBar;

    public float maxStamina = 100;
    public float currentStamina;
    public int StaminaPoints = 100;





    // Start is called before the first frame update
    void Start()
    {
        currentStamina = StaminaPoints;
        staminaBar.SetMaxHealth(StaminaPoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
