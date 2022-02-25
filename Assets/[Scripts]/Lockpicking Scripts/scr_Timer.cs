using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scr_Timer : MonoBehaviour
{
    TextMeshProUGUI myText;

    public float startingTime;
    private float timeRemaining; 


    void Start()
    {
        Initialize();

        myText = gameObject.GetComponent<TextMeshProUGUI>();    
    }


    public void Initialize()
    {
        timeRemaining = startingTime;
    }

    private void FixedUpdate()
    {
        timeRemaining -= Time.deltaTime;
        myText.text = Mathf.Round(timeRemaining).ToString();

        if (timeRemaining <= 0)
        {
            GameObject.FindObjectOfType<scr_LockpickingGame>().LoseGame();
        }
    }
}
