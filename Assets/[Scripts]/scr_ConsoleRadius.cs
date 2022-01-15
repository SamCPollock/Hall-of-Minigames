using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ConsoleRadius : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<scr_FPScontroller>() != null)
        {
            other.GetComponent<scr_FPScontroller>().isInConsoleRadius = true;
            scr_TooltipsManager.ActivateTooltipDisplay("Press 'Space'");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<scr_FPScontroller>() != null)
        {
            other.GetComponent<scr_FPScontroller>().isInConsoleRadius = false;
            scr_TooltipsManager.DeactivateTooltipDisplay();

        }
    }
}
