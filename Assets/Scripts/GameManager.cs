using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public int score;
    [SerializeField] private Text scoreText;

    public GameObject gameOverImage;
    public static string HIGHSCORE_KEY= "highScore";
    public GameObject highScoreParticles;

    public List<AudioClip> winAudio;
    public List<AudioClip> loseAudio;
    private AudioSource audioSource;

    private void Start()
    {
        gameOverImage.SetActive(false);
        gameOver = false;
        highScoreParticles.SetActive(false);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOverImage.SetActive(true);
        scoreText.gameObject.SetActive(false);
        gameOverImage.GetComponent<GameOverMenu>().DisplayGameResult(score, IsHighScore());
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt(HIGHSCORE_KEY, score);
    }

    public bool IsHighScore()
    {
        if(score > PlayerPrefs.GetInt(HIGHSCORE_KEY))
        {
            SaveHighScore();
            highScoreParticles.SetActive(true);
            PlayRandomHighScoreAudio();
            return true;
        }

        PlayLoseAudio();
        return false;
    }

    private void PlayRandomHighScoreAudio()
    {
        int randomInt = Random.Range(0, winAudio.Count);
        audioSource.clip = winAudio[randomInt];
        audioSource.Play();
    }

    private void PlayLoseAudio()
    {
        int randomInt = Random.Range(0, loseAudio.Count);
        audioSource.clip = loseAudio[randomInt];
        audioSource.Play();
    }
}
