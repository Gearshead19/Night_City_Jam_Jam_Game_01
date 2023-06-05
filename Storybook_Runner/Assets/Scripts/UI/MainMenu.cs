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
        HighScoreText.text = "  " + PlayerPrefs.GetInt("HighScore");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Assets/Scenes/Title_Screen.unity");
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Assets/Scenes/Runner_Level_01.unity");
    }
    public void ArtGalleryScene()
    {
        SceneManager.LoadScene("Assets/Scenes/ArtGallery.unity");
    }
    public void CreditsScene()
    {
        SceneManager.LoadScene("Assets/Scenes/Credits.unity");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
