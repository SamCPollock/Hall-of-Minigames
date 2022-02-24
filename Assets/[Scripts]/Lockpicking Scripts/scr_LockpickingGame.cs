using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_LockpickingGame : MonoBehaviour
{
    public GameObject innerLock;
    public float rotateSpeed;


    private bool isTwisting = false;

    void Update()
    {

        if (innerLock.transform.eulerAngles.z > 90)
        {
            print("OVERTURNED LOCK");
            innerLock.transform.eulerAngles = new Vector3(0, 0, 90f);
        }

        if (isTwisting == false)
        {
            // rotate back to center
            float lockLerp = Mathf.Lerp(innerLock.transform.eulerAngles.z, 0, Time.deltaTime * 20);
            innerLock.transform.eulerAngles = new Vector3(0, 0, lockLerp);

        }
        if (Input.GetKey(KeyCode.A))
        {
            // rotate left
            isTwisting = true;
            innerLock.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }

        //else if (Input.GetKey(KeyCode.D))
        //{
        //    // rotate right
        //    isTwisting = true;
        //    innerLock.transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);

        //}

        else
        {
            isTwisting = false;
        }

    }
}
