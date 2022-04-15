using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_HackingTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float startingTime;
    private float timeRemaining;
    public scr_HackingMinigame hackingMinigame;
    public bool isGameRunning = true;

    private void Start()
    {
        InitializeTimer();
    }

    public void InitializeTimer()
    {
        timeRemaining = startingTime;
        isGameRunning = true;
    }

    private void FixedUpdate()
    {
        if (isGameRunning)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = Mathf.Round(timeRemaining).ToString();

            if (timeRemaining <= 0)
            {
                hackingMinigame.LoseGame();
            }
        }
    }

}
