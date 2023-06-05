using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{


    public int score = 0;
    public TextMeshProUGUI scoreText;
    
    [Tooltip("When True score is being added every frame, when False it stops it")]
    [Header("Score On/Off")]
    public bool scoreIsOn;

    // Start is called before the first frame update
    void Start()
    {

        scoreIsOn = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacterController>().isGameOver)
        {
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
                //Debug.Log("New High Score is " + score);
            }
        }

        scoreText.text = "Score : " + score;
        if (scoreIsOn == true)
        {
            ScorePlus();
        }


    }

    public void ScorePlus()
    {
        score = score + 1;
    }




}
