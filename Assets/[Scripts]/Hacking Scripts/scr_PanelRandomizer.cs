using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_PanelRandomizer : MonoBehaviour
{
    private string[] mPossibleStrings;
    public TextMeshProUGUI myTextMeshPro;
    public string myString;

    public scr_HackingMinigame hackingMinigame; 



    private void Start()
    {
        hackingMinigame = GameObject.Find("HackingCanvas").GetComponent<scr_HackingMinigame>();
        mPossibleStrings = hackingMinigame.possibleStrings;

            myString = mPossibleStrings[Random.Range(0, mPossibleStrings.Length - (3 - hackingMinigame.difficulty))];

        myTextMeshPro.text = myString;
    }
}
