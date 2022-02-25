using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_LockpickingGame : MonoBehaviour
{
    public GameObject innerLock;
    public GameObject aimPick;
    public GameObject mouseFollower;

    public float rotateSpeed;


    private bool isTwisting = false;

    void Update()
    {
        float maxAngle = 0;


        // Prevent overtwisting.
        if (innerLock.transform.eulerAngles.z > 90)
        {
            print("OVERTURNED LOCK");
            innerLock.transform.eulerAngles = new Vector3(0, 0, 90f);
        }

        if (isTwisting == false)
        {
            // rotate back to center
            float lockLerp = Mathf.LerpAngle(innerLock.transform.eulerAngles.z, 0, Time.deltaTime * 20);
            innerLock.transform.eulerAngles = new Vector3(0, 0, lockLerp);

        }

        if (Input.GetKey(KeyCode.A))
        {
            // rotate left
            isTwisting = true;
            innerLock.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        } else
        {
            isTwisting = false;
        }

        var mousePos = Input.mousePosition;
        mousePos.z = aimPick.transform.position.z;
        print(Camera.main.ScreenToWorldPoint(mousePos));


        mouseFollower.transform.position = mousePos;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePos.x - aimPick.transform.position.x, mousePos.y - aimPick.transform.position.y);

        aimPick.transform.up = direction;

    }
}
