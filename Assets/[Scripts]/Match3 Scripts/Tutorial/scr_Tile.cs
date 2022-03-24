using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Tile : MonoBehaviour
{
    public int r, c;

    private scr_Item _item;

    public GameObject upNeighbour, downNeighbour, leftNeighbour, rightNeighbour;

    public bool isMatched = false;

    public bool isClickable = true;

    public scr_Match3Timer timer;

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

    // return neighbours 

    // TODO: Add a raycast to get neighbour tiles???? That might be good? 

    private void Start()
    {
            button.onClick.AddListener(() => scr_Board2.Instance.Select(this));
            timer = GameObject.Find("Timer").GetComponent<scr_Match3Timer>();
        
    }

    private void Update()
    {
        //GetNeighbours();
    }

    private GameObject GetAdjacent(Vector2 castDir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir);

        if (hit.collider != null && hit.collider.gameObject != this.gameObject)
        {
            return hit.collider.gameObject;
        }

        return null;
    }
    public void GetNeighbours()
    {
        upNeighbour = GetAdjacent(Vector2.up);
        downNeighbour = GetAdjacent(Vector2.down);
        leftNeighbour = GetAdjacent(Vector2.left);
        rightNeighbour = GetAdjacent(Vector2.right);

    }

    public void DestroyIfMatched()
    {
        if (isMatched)
        {
            //Item = null;
            if (icon)
            {
                Destroy(icon);
                timer.AddTime(1f);
                timer.AddScore(1);

            }
            //isMatched = false;
        }
    }

}
