using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Board2 : MonoBehaviour
{
    public static scr_Board2 Instance { get; private set; }  // singleton

    public scr_Row[] rows;

    public List<scr_Tile> tileList; 

    public int Width;
    public int Height;

    private void Awake() => Instance = this;

    private void Start()
    {
        tileList = new List<scr_Tile>();
        Height = transform.childCount;
        Width = rows[0].transform.childCount;

        Debug.Log("Width = " + Width);
        Debug.Log("Height = " + Height);


        InitializeBoard();
    }


    private void InitializeBoard()
    {
        foreach (scr_Row row in rows)
        {
            for (int i = 0; i < row.transform.childCount; i++)
            {
                tileList.Add(row.transform.GetChild(i).GetComponent<scr_Tile>());
            }
        }

        for (int i = 0; i < tileList.Count; i++)
        {
            tileList[i].Item = scr_ItemDatabase.Items[Random.Range(0, scr_ItemDatabase.Items.Length)];
            tileList[i].r = i / Width;
            tileList[i].c = i % Width;


        }
        //foreach (scr_Tile tile in tileList)
        //{
        //    tile.Item = scr_ItemDatabase.Items[Random.Range(0, scr_ItemDatabase.Items.Length)];
            
        //}
    }

}
