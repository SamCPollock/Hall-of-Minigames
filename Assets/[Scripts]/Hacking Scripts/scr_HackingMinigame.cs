using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class scr_HackingMinigame : MonoBehaviour
{
    public string[] possibleStrings;
    public TextMeshProUGUI goalPasswordTextObject;
    public TextMeshProUGUI currentPasswordTextObject; 
    public string goalPassword;
    public string currentPassword; 
    public GameObject CodeMatrixObject;
    public GameObject winScreen;
    public GameObject loseScreen;
    public Slider difficultySlider;
    public Slider skillLevelSlider; 
    public bool isSelectingRow = false;
    public scr_HackingTimer timer; 

    [Range(1, 3)]
    public int difficulty = 1;
    [Range(1, 6)]
    public int skillLevel = 1;

    public scr_PanelCreator panelCreator;

    // Start is called before the first frame update
    void Start()
    {
        InitializeHackingGame();
    }


    public void InitializeHackingGame()
    {
        difficulty = ((int)difficultySlider.value);
        skillLevel = ((int)skillLevelSlider.value);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        timer.startingTime = skillLevel * 10;
        timer.InitializeTimer();
        currentPassword = "";
        AddToPassword("");
        goalPassword = "";
        for (int i = 0; i < 4; i++)
        {
            goalPassword += possibleStrings[Random.Range(0, possibleStrings.Length - (3 - difficulty))];

        }

        goalPasswordTextObject.text = goalPassword;
        panelCreator.CreatePanels();
    }

    public void SetClickablePanels(int clickedRow, int clickedColumn)
    {
        int panelCount = CodeMatrixObject.transform.childCount;

        if (isSelectingRow)     // Selecting Row
        {

            for (int i = 0; i < panelCount; i++)
            {

                if (CodeMatrixObject.transform.GetChild(i).GetComponent<scr_Panel>().row == clickedRow)
                {
                    CodeMatrixObject.transform.GetChild(i).GetComponent<scr_Panel>().ToggleClickable(true);

                }
                else
                {
                    CodeMatrixObject.transform.GetChild(i).GetComponent<scr_Panel>().ToggleClickable(false);

                }

            }
            isSelectingRow = false;

        }

        else                   // Selecting Column
        {
            for (int i = 0; i < panelCount; i++)
            {
                if (CodeMatrixObject.transform.GetChild(i).GetComponent<scr_Panel>().column == clickedColumn)
                {
                    CodeMatrixObject.transform.GetChild(i).GetComponent<scr_Panel>().ToggleClickable(true);

                }
                else
                {
                    CodeMatrixObject.transform.GetChild(i).GetComponent<scr_Panel>().ToggleClickable(false);

                }
            }

            isSelectingRow = true;
        }
    }

    public void AddToPassword(string stringToAdd)
    {

        Debug.Log("ADDING TO PASSWORD: " + stringToAdd);

        currentPassword += stringToAdd;
        currentPasswordTextObject.text = currentPassword;

        if (currentPassword == goalPassword)
        {
            // YOU WIN! 
            Debug.Log("YOU WIN!!!");
            WinGame();
        }

        else if (currentPassword.Length == goalPassword.Length)
        {
            // YOU LOSE! 
            Debug.Log("YOU LOSE!!!");
            LoseGame();
        }
    }

    public void WinGame()
    {
        winScreen.SetActive(true);
        timer.isGameRunning = false;

    }

    public void LoseGame()
    {
        loseScreen.SetActive(true);
        timer.isGameRunning = false;

    }
}
