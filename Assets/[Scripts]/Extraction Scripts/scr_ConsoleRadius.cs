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
            scr_TooltipsManager.ActivateTooltipDisplay("Press 'Space' to Extract");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<scr_FPScontroller>() != null)
        {
            isActive = false;
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
                    LaunchExtraction();
                }
                else if (extractionUI.active == true)
                {
                    QuitExtraction();
                }
            }
        }
    }

    public void LaunchExtraction()
    {
        extractionUI.SetActive(true);

        player.GetComponent<scr_FPScontroller>().isTakingCharacterControl = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void QuitExtraction()
    {
        extractionUI.SetActive(false);

        player.GetComponent<scr_FPScontroller>().isTakingCharacterControl = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
