using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class scr_HackingMinigame : MonoBehaviour
{
    public string[] possibleStrings;
    public TextMeshProUGUI goalPasswordTextObject;
    public string goalPassword;
    public GameObject CodeMatrixObject;
    public bool isSelectingRow = true;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            goalPassword += possibleStrings[Random.Range(0, possibleStrings.Length)];

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

        //for (int i = 0; i < panelCount; i++)
        //{
        //    if (isSelectingRow)     // Selecting a row
        //    {
        //        if (CodeMatrixObject.transform.GetChild(i).GetComponent<scr_Panel>().row == clickedRow)
        //        {
        //            CodeMatrixObject.transform.GetChild(i).GetComponent<scr_Panel>().ToggleClickable(true);

        //        }
        //        else
        //        {
        //            CodeMatrixObject.transform.GetChild(i).GetComponent<scr_Panel>().ToggleClickable(false);

        //        }

        //        isSelectingRow = false;

        //    }
        //    else              // Selecting a column
        //    {
        //        if (CodeMatrixObject.transform.GetChild(i).GetComponent<scr_Panel>().column == clickedColumn)
        //        {
        //            CodeMatrixObject.transform.GetChild(i).GetComponent<scr_Panel>().ToggleClickable(true);

        //        }
        //        else
        //        {
        //            CodeMatrixObject.transform.GetChild(i).GetComponent<scr_Panel>().ToggleClickable(false);

        //        }
        //        isSelectingRow = true;

        //    }
        //}
    }
}
