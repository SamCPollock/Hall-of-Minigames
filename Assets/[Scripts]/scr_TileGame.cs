using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scr_TileGame : MonoBehaviour
{
    public static bool isInScanMode = false;

    public static int score = 0;
    public static int remainingScans = 6;
    public static int remainingExtracts= 3; 

    public Text buttonText;
    
    public static TextMeshProUGUI scoreText;


    private void Awake()
    {
    }

    public void ToggleMode()
    {
        isInScanMode = !isInScanMode;


        if (isInScanMode)
        {
            buttonText.text = "SCAN MODE";
        }
        else
        {
            buttonText.text = "EXTRACT MODE";
        }
    }

    public static void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;


        scoreText = GameObject.Find("Resources Extracted Text").GetComponent<TextMeshProUGUI>();
        scoreText.text = "SCORE: " + score.ToString();

        if (remainingExtracts == 0)
        {
            // game over 
        }
    }
}
