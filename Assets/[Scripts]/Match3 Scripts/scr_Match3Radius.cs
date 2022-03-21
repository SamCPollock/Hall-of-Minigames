using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Match3Radius : MonoBehaviour
{
    public GameObject player;
    public bool isActive = false;
    public GameObject match3UI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<scr_FPScontroller>() != null)
        {
            isActive = true;
            player = other.gameObject;
            scr_TooltipsManager.ActivateTooltipDisplay("Press 'Space' to Match 3");
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
                if (match3UI.active == false)
                {
                    LaunchMatch3();
                }
                else if (match3UI.active == true)
                {
                    QuitMatch3();
                }
            }
        }
    }

    public void LaunchMatch3()
    {
        match3UI.SetActive(true);

        player.GetComponent<scr_FPScontroller>().isTakingCharacterControl = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void QuitMatch3()
    {
        match3UI.SetActive(false);

        player.GetComponent<scr_FPScontroller>().isTakingCharacterControl = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
