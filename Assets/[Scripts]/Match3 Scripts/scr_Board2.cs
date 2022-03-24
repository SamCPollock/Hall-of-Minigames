using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks; // using this based on youtube tutorial's suggestion, from Winterbolt Games
using DG.Tweening;
using UnityEngine;

public class scr_Board2 : MonoBehaviour
{
    public static scr_Board2 Instance { get; private set; }  // singleton

    public scr_Row[] rows;

    public List<scr_Tile> tileList; 

    public int Width;
    public int Height;

    private readonly List<scr_Tile> _selection = new List<scr_Tile>();

    private const float TweenDuration = 0.25f;

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
            tileList[i].Item = scr_ItemDatabase.Items[UnityEngine.Random.Range(0, scr_ItemDatabase.Items.Length)];
            tileList[i].r = i / Width;
            tileList[i].c = i % Width;

        }

    }


    public async void Select(scr_Tile tile)
    {
        if (!_selection.Contains(tile))
        {
            _selection.Add(tile);
        }

        if (_selection.Count < 2) return;

        Debug.Log($"Selected tiles at ({_selection[0].r}, {_selection[0].c}) and ({_selection[1].r}, {_selection[1].c}) ");

        await Swap(_selection[0], _selection[1]);

        _selection.Clear();
    }

    
    public async Task Swap(scr_Tile tile1, scr_Tile tile2)
    {
        var icon1 = tile1.icon;
        var icon2 = tile2.icon;

        var icon1Transform = icon1.transform;
        var icon2Transform = icon2.transform;


        var sequence = DOTween.Sequence();

        sequence.Join(icon1.transform.DOMove(icon2Transform.position, TweenDuration))
            .Join(icon2Transform.DOMove(icon1Transform.position, TweenDuration));

        await sequence.Play().AsyncWaitForCompletion();

        // swap parents
        icon1Transform.SetParent(tile2.transform);
        icon2Transform.SetParent(tile1.transform);

        tile1.icon = icon2;
        tile2.icon = icon1;

        var tile1Item = tile1.Item;

        tile1.Item = tile2.Item;

        tile2.Item = tile1Item;
    }

    private bool CanPop()
    {
        throw new NotImplementedException();
    }

    private void Pop()
    {
        throw new NotImplementedException();
    }
}
