using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_LockpickingGame : MonoBehaviour
{
    public GameObject innerLock;
    public GameObject aimPick;
    public GameObject mouseFollower;

    public float rotateSpeed;
    public float goalAngle;
    public float permissibleDistance;
    public Animator jigglePickAnimator;
    public TextMeshProUGUI picksRemainingText;

    public int startingPicks;
    private int picksRemaining;

    public float jiggleEndurance; 
    private float jigglingTime = 0;



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


        // Prevent overtwisting.
        if (innerLock.transform.eulerAngles.z > maxAngle)
        {
            jigglePickAnimator.SetBool("isJiggling", true);

            jigglingTime += Time.deltaTime;

            if (jigglingTime >= jiggleEndurance)
            {
                BreakPick();
            }

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

            if (innerLock.transform.eulerAngles.z >= 90)
            {
                WinGame();
            }
        } else
        {
            isTwisting = false;
            jigglePickAnimator.SetBool("isJiggling", false);

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
        print("---YOU LOSE---");
    }

    public void WinGame()
    {
        print("---YOU WIN---");

    }

    private void BreakPick()
    {
        picksRemaining--;
        jigglePickAnimator.SetTrigger("break");
        if (picksRemaining <= 0)
        {
            LoseGame();
        }

        jigglingTime = 0;
        picksRemainingText.text = "Picks Remaining: " + picksRemaining.ToString();

    }

    public void Initialize()
    {
        goalAngle = Random.Range(20, 340);
        picksRemaining = startingPicks;

        picksRemainingText.text = "Picks Remaining: " + picksRemaining.ToString();

        GameObject.FindObjectOfType<scr_Timer>().Initialize();

    }
}
