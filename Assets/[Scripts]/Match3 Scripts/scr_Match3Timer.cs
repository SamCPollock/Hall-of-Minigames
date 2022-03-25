using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scr_Match3Timer : MonoBehaviour
{
    public Slider timerSlider;
    public float totalTime;
    public float remainingTime;

    public float timeSinceLastMatch;

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

        if (remainingTime <= 0)
        {
            loseScreen.SetActive(true);
        }
    }

    public void Initialize()
    {
        remainingTime = totalTime;
        score = 0;
    }

    public void AddTime(float timeToAdd)
    {
        remainingTime += timeToAdd;
    }

    public void AddScore(int scoreToAdd)
    {
        
        audioManager.Play();
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();
        timeSinceLastMatch = 0;

        if (score >= winScore)
        {
            winScreen.SetActive(true);
        }

    }
}
