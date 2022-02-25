using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_LockpickRadius : MonoBehaviour
{

    public GameObject player;
    public bool isActive = false;
    public GameObject lockpickUI;

    public int difficultyLevel; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<scr_FPScontroller>() != null)
        {
            isActive = true;
            player = other.gameObject;
            scr_TooltipsManager.ActivateTooltipDisplay("Press 'Space' To Lockpick");
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
                if (lockpickUI.active == false)
                {
                    LaunchLockpick();  
                }
                else if (lockpickUI.active == true)
                {
                    QuitLockpick();
                }   
            }
        }
    }


    public void LaunchLockpick()
    {
        lockpickUI.SetActive(true);
        lockpickUI.GetComponent<scr_LockpickingGame>().Initialize(difficultyLevel);

        player.GetComponent<scr_FPScontroller>().isTakingCharacterControl = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void QuitLockpick()
    {
        lockpickUI.SetActive(false);

        player.GetComponent<scr_FPScontroller>().isTakingCharacterControl = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
