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
    public float permissibleDistance;


    private bool isTwisting = false;

    private void Start()
    {
        Initialize();
    }

    void Update()
    {
        float maxAngle = 20;

        float distanceToGoal = Mathf.Abs(aimPick.transform.eulerAngles.z - goalAngle);
        //print(distanceToGoal);
        maxAngle = 90 - distanceToGoal;
        if (maxAngle > 90)
        {
            maxAngle = 90;
        }
        if (maxAngle < 5)
        {
            maxAngle = 5;
        }

        if (distanceToGoal < permissibleDistance)
        {
            maxAngle = 90;
        }

        print(maxAngle);

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

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
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


        mouseFollower.transform.position = mousePos;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePos.x - aimPick.transform.position.x, mousePos.y - aimPick.transform.position.y);


        aimPick.transform.up = direction;
        
    }

    public void LoseGame()
    {

    }

    public void WinGame()
    {

    }

    public void Initialize()
    {
        goalAngle = Random.Range(20, 340);
    }
}
