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
    public bool isSelectingRow = false;

    [Range(1, 3)]
    public int difficulty = 1;

    // Start is called before the first frame update
    void Start()
    {
 
            for (int i = 0; i < 4; i++)
            {
                goalPassword += possibleStrings[Random.Range(0, possibleStrings.Length  - (3 - difficulty))];

            }

        goalPasswordTextObject.text = goalPassword;
    }

    // Update is called once per frame
    void Update()
    {

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
        currentPassword += stringToAdd;
        currentPasswordTextObject.text = currentPassword;

        if (currentPassword == goalPassword)
        {
            // YOU WIN! 
            Debug.Log("YOU WIN!!!");
        }

        else if (currentPassword.Length == goalPassword.Length)
        {
            // YOU LOSE! 
            Debug.Log("YOU LOSE!!!");

        }
    }
}
