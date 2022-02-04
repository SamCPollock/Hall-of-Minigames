using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class scr_ResourcePanel : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;
    public int oreValue;


    public int row;
    public int column;
    public scr_ExtractionGridGenerator generatorScript;

    public GameObject aboveTile;
    public GameObject leftTile;
    public GameObject rightTile;
    public GameObject belowTile;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
        image.color = Color.grey;
    }

    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        image.color = Color.green;
        // Send an event to scr_ExtractionGridGenerator with the row and column of the clicked tile. 
        if (scr_TileGame.isInScanMode)
        {
            generatorScript.TileScanned(row, column);
        }
        else
        {
            generatorScript.TileExtracted(row, column);
        }

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //image.color = Color.yellow;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //image.color = Color.grey;

    }

    public void ScanReveal()
    {
        if (oreValue == 100)
        {
            gameObject.GetComponent<Image>().color = Color.yellow;
        }

        else if (oreValue == 50)
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }

        else if (oreValue == 25)
        {
            gameObject.GetComponent<Image>().color = Color.blue;

        }

        else
        {
            gameObject.GetComponent<Image>().color = Color.black;

        }
    }

    public void Extract()
    {
        //scr_TileGame.score += oreValue;
        
        Debug.Log("CURRENT SCORE: " + scr_TileGame.score);
        scr_TileGame.UpdateScore(oreValue);

        oreValue = 0;

    }

}
