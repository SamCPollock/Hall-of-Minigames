using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_LockpickingGame : MonoBehaviour
{
    public GameObject innerLock;
    public GameObject aimPick;
    public GameObject mouseFollower;

    public float rotateSpeed;
    public float goalAngle; 


    private bool isTwisting = false;

    void Update()
    {
        float maxAngle = 20;

        print("Aimpick angle = " + (aimPick.transform.eulerAngles.z) + ", Goal Angle = " + goalAngle + "Difference = " + (aimPick.transform.eulerAngles.z - goalAngle));

        if (aimPick.transform.eulerAngles.z - goalAngle < 20)
        {
            maxAngle = 90;
        }


        // Prevent overtwisting.
        if (innerLock.transform.eulerAngles.z > maxAngle)
        {
            //print("OVERTURNED LOCK");
            innerLock.transform.eulerAngles = new Vector3(0, 0, maxAngle);
        }

        if (isTwisting == false)
        {
            // rotate back to center
            float lockLerp = Mathf.LerpAngle(innerLock.transform.eulerAngles.z, 0, Time.deltaTime * 20);
            innerLock.transform.eulerAngles = new Vector3(0, 0, lockLerp);

        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
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
        //print(Camera.main.ScreenToWorldPoint(mousePos));


        mouseFollower.transform.position = mousePos;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePos.x - aimPick.transform.position.x, mousePos.y - aimPick.transform.position.y);

        aimPick.transform.up = direction;

    }
}
