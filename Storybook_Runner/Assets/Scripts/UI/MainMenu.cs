using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;









    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Assets/Scenes/Runner_Level_01.unity");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
