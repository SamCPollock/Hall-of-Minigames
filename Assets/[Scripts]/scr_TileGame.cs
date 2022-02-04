using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scr_TileGame : MonoBehaviour
{
    public static bool isInScanMode = true;

    public static int score = 0;

    public Text buttonText;
    
    public static TextMeshProUGUI scoreText;


    private void Awake()
    {
        scoreText = GameObject.Find("Resources Extracted Text").GetComponent<TextMeshProUGUI>();
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

        scoreText.text = "SCORE: " + score.ToString();
    }
}
