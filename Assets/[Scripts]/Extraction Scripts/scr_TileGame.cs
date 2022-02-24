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
    public static TextMeshProUGUI remainingScansText;
    public static TextMeshProUGUI remainingExtractsText;
    public static TextMeshProUGUI messageText;

    public GameObject gameOverCanvas;


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


        if (remainingExtracts == 0)
        {
            // game over 
            GameObject.Find("GameOverCanvas").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("GameOverScore").GetComponent<TextMeshProUGUI>().text = "SCORE: " + score.ToString();
        }
    }

    public static void UpdateUI()
    {
        // Score text
        scoreText = GameObject.Find("Resources Extracted Text").GetComponent<TextMeshProUGUI>();
        scoreText.text = "SCORE: " + score.ToString();

        // Remaining scans text
        remainingScansText = GameObject.Find("Scans Remaining Text").GetComponent<TextMeshProUGUI>();
        remainingScansText.text = "SCANS REMAINING: " + remainingScans.ToString();

        // Remaining extracts text
        remainingExtractsText = GameObject.Find("Extracts Remaining Text").GetComponent<TextMeshProUGUI>();
        remainingExtractsText.text = "EXTRACTS REMAINING: " + remainingExtracts.ToString();
    }

    public static void ShowMessage(string messageToDisplay)
    {
        messageText = GameObject.Find("Message Text").GetComponent<TextMeshProUGUI>();
        messageText.text = messageToDisplay;
    }


}
