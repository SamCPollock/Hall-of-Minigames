using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_PanelRandomizer : MonoBehaviour
{
    private string[] mPossibleStrings;
    public TextMeshProUGUI myTextMeshPro;
    private string myString;



    private void Start()
    {
        mPossibleStrings = GameObject.Find("HackingCanvas").GetComponent<scr_HackingMinigame>().possibleStrings;
        myString = mPossibleStrings[Random.Range(0, mPossibleStrings.Length)];
        myTextMeshPro.text = myString;
    }
}
