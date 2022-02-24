using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ConsoleRadius : MonoBehaviour
{

    public GameObject player;
    public bool isActive = false;
    public GameObject extractionUI; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<scr_FPScontroller>() != null)
        {
            isActive = true;
            player = other.gameObject;
            other.GetComponent<scr_FPScontroller>().isInConsoleRadius = true;
            scr_TooltipsManager.ActivateTooltipDisplay("Press 'Space'");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<scr_FPScontroller>() != null)
        {
            isActive = false;
            other.GetComponent<scr_FPScontroller>().isInConsoleRadius = false;
            scr_TooltipsManager.DeactivateTooltipDisplay();

        }
    }

    private void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (extractionUI.active == false)
                {
                    extractionUI.SetActive(true);

                    player.GetComponent<scr_FPScontroller>().isTakingCharacterControl = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                }
                else if (extractionUI.active == true)
                {
                    extractionUI.SetActive(false);

                    player.GetComponent<scr_FPScontroller>().isTakingCharacterControl = true;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
    }
}
