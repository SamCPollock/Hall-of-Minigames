using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_TooltipsManager : MonoBehaviour
{
    public static GameObject tooltipDisplay;

    void Start()
    {
        tooltipDisplay = GameObject.Find("TooltipUI");
    }

    void Update()
    {
        
    }

    public static void ActivateTooltipDisplay(string tooltipText)
    {
        tooltipDisplay.SetActive(true);
        tooltipDisplay.GetComponent<TextMeshProUGUI>().text = tooltipText;
    }

    public static void DeactivateTooltipDisplay()
    {
        tooltipDisplay.SetActive(false);

    }


}
