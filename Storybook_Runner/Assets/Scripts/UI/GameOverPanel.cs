using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Assets/Scenes/Title_Screen.unity");
    }
    public void Retry()
    {
        SceneManager.LoadScene("Assets/Scenes/Runner_Level_01.unity");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
