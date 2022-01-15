using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class scr_ResourcePanel : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;
    public int oreValue; 

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
