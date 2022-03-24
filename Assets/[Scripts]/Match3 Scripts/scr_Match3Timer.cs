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
    public TextMeshProUGUI scoreText;
    public GameObject winScreen;
    public GameObject loseScreen; 
    private int score = 0; 

    void Start()
    {
        remainingTime = totalTime;
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime > totalTime)
        {
            remainingTime = totalTime;
        }

        timerSlider.value = (remainingTime / totalTime);
    }

    public void AddTime(float timeToAdd)
    {
        remainingTime += timeToAdd;
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();

    }
}
