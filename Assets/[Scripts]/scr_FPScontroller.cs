using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_FPScontroller : MonoBehaviour
{
    // Camera
    public float camHoriSpeed = 1f;
    public float camVertiSpeed = -1f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private Camera cam;

    // Movement
    public float movementSpeed = 1f;
    Rigidbody rb;


    public bool isInConsoleRadius = false;
    public bool isTakingCharacterControl = true;

    public GameObject ExtractionUI;

    private void Start()
    {
        cam = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isTakingCharacterControl)
        {
            // Cam Inputs
            float mouseX = Input.GetAxis("Mouse X") * camHoriSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * camVertiSpeed;

            // Movement Inputs
            float horiInput = Input.GetAxis("Horizontal") * movementSpeed;
            float vertiInput = Input.GetAxis("Vertical") * movementSpeed;



            Vector3 moveBy = horiInput * transform.right + vertiInput * transform.forward;

            rb.velocity = moveBy;


            yRotation += mouseX;
            xRotation += mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);

            cam.transform.eulerAngles = new Vector3(xRotation, transform.eulerAngles.y, 0.0f);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, 0);
        }


        if (Input.GetKeyDown(KeyCode.Space) && isInConsoleRadius)
        {
            if (isTakingCharacterControl)
                GoToExtractionUI();
            else
                LeaveExtractionUI();
        }
    }

    private void GoToExtractionUI()
    {
        ExtractionUI.SetActive(true);
        isTakingCharacterControl = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void LeaveExtractionUI()
    {
        ExtractionUI.SetActive(false);
        isTakingCharacterControl = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
