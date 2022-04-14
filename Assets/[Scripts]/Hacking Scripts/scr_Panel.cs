using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Panel : MonoBehaviour
{
    public int row = 0;
    public int column = 0;
    public bool isClickable = true;

    void Start()
    {
            
    }

    void Update()
    {
        
    }

    public void PanelClicked()
    {
        GameObject.Find("HackingCanvas").GetComponent<scr_HackingMinigame>().SetClickablePanels(row, column);
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
