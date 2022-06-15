using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour
{
    private Text highScoreText;

    private void Start()
    {
        highScoreText = gameObject.GetComponent<Text>();
        SetHighScoreText();
    }

    private void SetHighScoreText()
    {
        int highScore = PlayerPrefs.GetInt(GameManager.HIGHSCORE_KEY);
        highScoreText.text = string.Format("High Score: {0}", highScore);
    }
}
