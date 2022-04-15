using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_HackingRadius : MonoBehaviour
{
    public GameObject player;
    public bool isActive = false;
    public GameObject hackingUI;
    public scr_HackingMinigame hackingMinigame; 
    //public GameObject match3Board;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<scr_FPScontroller>() != null)
        {
            isActive = true;
            player = other.gameObject;
            scr_TooltipsManager.ActivateTooltipDisplay("Press 'Space' to Hack");
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
                if (hackingUI.active == false)
                {
                    LaunchHacking();
                }
                else if (hackingUI.active == true)
                {
                    QuitHacking();
                }
            }
        }
    }

    public void LaunchHacking()
    {
        hackingUI.SetActive(true);
        hackingMinigame.InitializeHackingGame();

        player.GetComponent<scr_FPScontroller>().isTakingCharacterControl = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void QuitHacking()
    {
        hackingUI.SetActive(false);
        //match3Board.SetActive(false);

        player.GetComponent<scr_FPScontroller>().isTakingCharacterControl = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
