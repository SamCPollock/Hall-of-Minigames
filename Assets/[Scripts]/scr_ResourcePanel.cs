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
        generatorScript.TileClicked(row, column);

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.yellow;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.grey;

    }

}
