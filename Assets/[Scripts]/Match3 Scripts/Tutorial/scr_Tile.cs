using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Tile : MonoBehaviour
{
    public int r, c;

    private scr_Item _item;

    public scr_Item Item
    {
        get => _item;

        set
        {
            if (_item == value)
            {
                return;
                Debug.Log("RETURNING");
            }


            _item = value;

            icon.sprite = _item.sprite;
        }
    }
    public Image icon;

    public Button button; 
}
