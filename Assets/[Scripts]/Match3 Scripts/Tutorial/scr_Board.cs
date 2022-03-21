//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//public class scr_Board : MonoBehaviour
//{
//    public static scr_Board Instance { get; private set; }  // singleton

//    public scr_Row[] rows;

//    public scr_Tile[,] Tiles { get; private set; }

//    public int Width;
//    public int Height;

//    private void Awake() => Instance = this;

//    private void Start()
//    {

//        Tiles = new scr_Tile[rows.Max(row => row.tiles.Length), rows.Length];

        
//        Width = Tiles.GetLength(0);
//        Height = Tiles.GetLength(1);

//        Debug.Log("BOARD STARTING");
//        Debug.Log("Width = " + Width);
//        Debug.Log("Height = " + Height);

//        for (var y = 0; y < Height; y++)
//        {
//            for (var x = 0; x < Width; x++)
//            {
//                var tile = rows[y].tiles[x];

//                tile.r = x;
//                tile.c = y;

//                tile.Item = scr_ItemDatabase.Items[Random.Range(0, scr_ItemDatabase.Items.Length)];
//                Debug.Log("ASSIGNING RANDOM TILES");
                
//                Tiles[x, y] = rows[y].tiles[x];
//            }
//        }
//    }
//}
