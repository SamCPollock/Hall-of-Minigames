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
    private float permissibleDistance;
    public Animator jigglePickAnimator;
    public TextMeshProUGUI picksRemainingText;
    public TextMeshProUGUI diffultyText;
    public TextMeshProUGUI skillText;


    public int startingPicks;
    private int picksRemaining;

    public float skillLevel; 
    private float jigglingTime = 0;


    private bool isLockpicking;
    private bool isTwisting = false;

    public GameObject winPanel, losePanel;

    private void Start()
    {
       
        Initialize(1);


    }

    void Update()
    {
        if (isLockpicking)
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

                if (jigglingTime >= skillLevel)
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
            }
            else
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

    }

    public void LoseGame()
    {
        print("---YOU LOSE---");
        losePanel.SetActive(true);
        isLockpicking = false;
        jigglePickAnimator.SetBool("isJiggling", false);

    }

    public void WinGame()
    {
        print("---YOU WIN---");
        winPanel.SetActive(true);
        isLockpicking = false;
        jigglePickAnimator.SetBool("isJiggling", false);

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

    public void Initialize(int difficultyLevel)
    {

        permissibleDistance = 30 - (5 * difficultyLevel);
        isLockpicking = true;
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        goalAngle = Random.Range(20, 340);
        picksRemaining = startingPicks;

        picksRemainingText.text = "Picks Remaining: " + picksRemaining.ToString();
        diffultyText.text = "Difficulty level: " + difficultyLevel.ToString() + " - (determines acceptable range for success)";
        skillText.text = "Skill level: " + skillLevel.ToString() + " - (determines durability of picks)";

        GameObject.FindObjectOfType<scr_Timer>().Initialize();

    }
}
