using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scr_Panel : MonoBehaviour
{
    public int row = 0;
    public int column = 0;
    public bool isClickable = true;
    public scr_HackingMinigame hackingMinigame; 

    void Start()
    {
        hackingMinigame = GameObject.Find("HackingCanvas").GetComponent<scr_HackingMinigame>();
    }

    public void PanelClicked()
    {
        if (isClickable)
        {
            string _myString = GetComponent<scr_PanelRandomizer>().myString;
            hackingMinigame.SetClickablePanels(row, column);
            hackingMinigame.AddToPassword(_myString);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

        }
    }

    public void ToggleClickable(bool clickable)
    {
        isClickable = clickable;
        if (isClickable)
        {
            gameObject.GetComponent<Image>().color = Color.green;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.grey;

        }
    }
}
