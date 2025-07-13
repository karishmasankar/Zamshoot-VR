using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    

    public GameObject gameOverCanvas;
    public TMP_Text finalScoreText;

    public bool isGameOver = false;

    public int currentScore = 0;
    public TMP_Text scoreText;

    public AudioSource gameOverAudio;
    public AudioSource CollectibleAudio;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        // Hide GameOver canvas at start
        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(false);
    }

    public void AddScore(int value)
    {
        CollectibleAudio.Play();
        currentScore += value;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        gameOverAudio.Play();

        Debug.Log("Game Over!");
        // Freeze time
        Time.timeScale = 0f;

        // Show the game over UI
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);

            int finalScore = currentScore;
            finalScoreText.text = finalScore.ToString();
        }     
                
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_1");
    }

}
