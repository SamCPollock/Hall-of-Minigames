using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scr_Match3Timer : MonoBehaviour
{
    public Slider timerSlider;
    public Slider comboSlider; 
    public float totalTime;
    public float remainingTime;

    private float timeSinceLastMatch;
    public float comboBuffer = 2;

    public TextMeshProUGUI scoreText;
    public GameObject winScreen;
    public GameObject loseScreen;
    public AudioSource audioManager; 
    private int score = 0;
    public int winScore;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;
        timeSinceLastMatch += Time.deltaTime;

        if (remainingTime > totalTime)
        {
            remainingTime = totalTime;
        }

        timerSlider.value = (remainingTime / totalTime);
        comboSlider.value = comboBuffer - timeSinceLastMatch;

        if (remainingTime <= 0)
        {
            loseScreen.SetActive(true);
        }
    }

    public void Initialize()
    {
        Debug.Log("-------INITIALIZING TIMER");
        remainingTime = totalTime;
        score = 0;
        timeSinceLastMatch = comboBuffer;
        scoreText.text = "Score: " + score.ToString();

    }

    public void AddTime(float timeToAdd)
    {
        remainingTime += timeToAdd;
    }

    public void AddScore(int scoreToAdd)
    {
        Debug.Log("Time since last match: " + timeSinceLastMatch + " Combo Buffer: " + comboBuffer);

        if (timeSinceLastMatch < comboBuffer)
        {
            score += 1;
            audioManager.pitch = 1.2f;
            audioManager.Play();
        }
        else
        {
            audioManager.pitch = 0.9f;
            audioManager.Play();

        }
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();
        timeSinceLastMatch = 0;

        if (score >= winScore)
        {
            winScreen.SetActive(true);
        }

    }
}
