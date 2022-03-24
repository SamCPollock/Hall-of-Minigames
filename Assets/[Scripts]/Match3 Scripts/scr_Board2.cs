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

    //public int difficulty;

    private readonly List<scr_Tile> _selection = new List<scr_Tile>();

    private const float TweenDuration = 0.25f;

    private void Awake()
    {
        Instance = this;

        tileList = new List<scr_Tile>();
        Height = transform.childCount;
        Width = rows[0].transform.childCount;

        Debug.Log("Width = " + Width);
        Debug.Log("Height = " + Height);
    }


    private void Start()
    {



        //InitializeBoard();
        //CheckForMatches();
    }


    public void InitializeBoard(int difficulty)
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
            tileList[i].Item = scr_ItemDatabase.Items[UnityEngine.Random.Range(0, difficulty)];
            tileList[i].r = i / Width;
            tileList[i].c = i % Width;
            tileList[i].GetNeighbours();

        }

        //CheckForMatchesStartup();     //TODO: FIgure out why broken (getting the wrong tiles as matching) NOTE: Happens only when calling from Start() or InitializeBoard(). The same logic works fine after a swap!! 
        //CheckForMatches();



    }


    public async void Select(scr_Tile tile)
    {
        if (tile.icon != null)
        {

            if (!_selection.Contains(tile))
            {
                _selection.Add(tile);
                tile.icon.color = Color.green;
            }

            if (_selection.Count < 2) return;

            Debug.Log($"Selected tiles at ({_selection[0].r}, {_selection[0].c}) and ({_selection[1].r}, {_selection[1].c}) ");

            await Swap(_selection[0], _selection[1]);

            _selection[0].icon.color = Color.white;
            _selection[1].icon.color = Color.white; 

            _selection.Clear();

            CheckForMatches();
        }

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


    public void CheckForMatches()
    {
        foreach (scr_Tile tile in tileList)
        {
            tile.GetNeighbours();
            if (tile.leftNeighbour != null && tile.rightNeighbour != null)
            {
                scr_Tile _leftNeighbour = tile.leftNeighbour.GetComponent<scr_Tile>();
                scr_Tile _rightNeighbour = tile.rightNeighbour.GetComponent<scr_Tile>();
                if (_leftNeighbour.icon != null && _rightNeighbour.icon != null)
                {
                    if (_leftNeighbour.Item == tile.Item && _rightNeighbour.Item == tile.Item)
                    {

                        tile.isMatched = true;
                        _leftNeighbour.isMatched = true;
                        _rightNeighbour.isMatched = true;
                    }
                }
            }

            if (tile.upNeighbour != null && tile.downNeighbour != null)
            {
                scr_Tile _upNeighbour = tile.upNeighbour.GetComponent<scr_Tile>();
                scr_Tile _downNeighbour = tile.downNeighbour.GetComponent<scr_Tile>();
                if (_upNeighbour.icon != null && _downNeighbour.icon != null)
                {
                    if (_upNeighbour.Item == tile.Item && _downNeighbour.Item == tile.Item)
                    {
                        tile.isMatched = true;
                        _upNeighbour.isMatched = true;
                        _downNeighbour.isMatched = true;
                    }
                }
            }
        }

        foreach(scr_Tile tile in tileList)
        {
            tile.DestroyIfMatched();
        }
    }


    public void CheckForMatchesStartup()
    {
        Debug.Log("RUNNING MATCHES_CHECK");

        List<scr_Tile> matchedTiles = new List<scr_Tile>();

        foreach (scr_Tile tile in tileList)
        {

            tile.GetNeighbours();
            if (tile.leftNeighbour != null && tile.rightNeighbour != null)
            {
                scr_Tile _leftNeighbour = tile.leftNeighbour.GetComponent<scr_Tile>();
                scr_Tile _rightNeighbour = tile.rightNeighbour.GetComponent<scr_Tile>();
                if (_leftNeighbour.Item == tile.Item && _rightNeighbour.Item == tile.Item)
                { 
                    matchedTiles.Add(tile);
                    Debug.Log("ADDING TILE " + tile.Item + ", " + tile.r + "," + tile.c);
                }
            }

            //if (tile.upNeighbour != null && tile.downNeighbour != null)
            //{
            //    scr_Tile _upNeighbour = tile.upNeighbour.GetComponent<scr_Tile>();
            //    scr_Tile _downNeighbour = tile.downNeighbour.GetComponent<scr_Tile>();
            //    if (_upNeighbour.Item == tile.Item && _downNeighbour.Item == tile.Item)
            //    {
            //        matchedTiles.Add(tile);
            //        Debug.Log("ADDING TILE " + tile.r + "," + tile.c);

            //    }
            //}
        }

        foreach (scr_Tile tile in tileList)
        {
            Debug.Log("Tiles list: " + tile.Item + "at " + tile.r + "," + tile.c);
        }

        print("Matching Tiles = " + matchedTiles.Count);
        if (matchedTiles.Count > 0)
        {

            foreach (scr_Tile matchedTile in matchedTiles)
            {
                Debug.Log("MATCH TILE: Tile was: " + matchedTile.Item + "at " + matchedTile.r + ","+  matchedTile.c);
                //matchedTile.Item = scr_ItemDatabase.Items[UnityEngine.Random.Range(0, difficulty)];
                //Debug.Log("Now Tile is: " + matchedTile.Item);

            }

            //matchedTiles.Clear();
            //CheckForMatchesStartup();
        }

       

        if (matchedTiles.Count == 0)
        {
            //foreach(scr_Tile tile in tileList)
            //{
            //    Debug.Log("Tile: " + tile.r + "," + tile.c + ", " + tile.Item);
            //}
        }
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
