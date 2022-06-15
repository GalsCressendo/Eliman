using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject newHighScoreText;
    public Button playAgainButton;
    public Text finalScoreText;
    public Button mainMenuButton;

    public void DisplayGameResult(int score, bool isHighScore)
    {
        SetFinalScore(score);
        DisplayHighScore(isHighScore);
        AssignPlayAgainButton();
        AssignMainMenuButton();
    }

    private void SetFinalScore(int score)
    {
        finalScoreText.text = string.Format("Score: {0}",score.ToString());
    }

    private void DisplayHighScore(bool isHighScore)
    {
       newHighScoreText.SetActive(isHighScore);
    }

    private void AssignPlayAgainButton()
    {
        playAgainButton.onClick.AddListener(RestartScene);
    }

    private void AssignMainMenuButton()
    {
        mainMenuButton.onClick.AddListener(LoadStartMenu);
    }

    private void LoadStartMenu()
    {
        SceneManager.LoadScene("startMenu");
    }

    private void RestartScene()
    {
        SceneManager.LoadScene("main");
    }
}
