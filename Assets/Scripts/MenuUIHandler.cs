using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public string input;
    public Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        MainManager.Instance.LoadHighScore();

        if (MainManager.Instance != null)
        {
            if (MainManager.Instance.highScore != 0)
            {
                DisplayHighScore();
            }
            else
            {
                bestScoreText.text = "Hello, set a high score!";
            }
        }
        
    }

    public void StorePlayerName(string inputName)
    {
        MainManager.Instance.playerName = inputName;
    }

    void DisplayHighScore()
    {
        bestScoreText.text = "Best Score : " + MainManager.Instance.highScore + " by " + MainManager.Instance.highScoreName;
    }

    void DisplayName()
    {
        bestScoreText.text = MainManager.Instance.playerName + ", set a High Score!";
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }


    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); //Original code to quit Unity player
#endif
    }
}
