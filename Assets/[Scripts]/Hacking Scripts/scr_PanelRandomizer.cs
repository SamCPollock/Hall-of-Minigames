using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_PanelRandomizer : MonoBehaviour
{
    public string[] possibleStrings;
    public TextMeshProUGUI myTextMeshPro;
    private string myString;

    private void Start()
    {
        myString = possibleStrings[Random.Range(0, possibleStrings.Length)];
        myTextMeshPro.text = myString;
    }
}
