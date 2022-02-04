using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ExtractionGridGenerator : MonoBehaviour
{
    public int rows;
    public int columns;

    public int maxNumberOfRichOreTiles;
    public int richOreTilesValue;

    public GameObject[,] gridArray;

    public GameObject resourcePanelPrefab;

    void Start()
    {
        gameObject.GetComponent<GridLayoutGroup>().cellSize = new Vector2((480 / rows), (480 / columns));

       gridArray = new GameObject[rows, columns];

        MakePanels();
        
    }

    public void MakePanels()
    {

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                GameObject gridTile = (GameObject)Instantiate(resourcePanelPrefab, gameObject.transform);
                scr_ResourcePanel panelScript = gridTile.GetComponent<scr_ResourcePanel>();
                gridArray[r, c] = gridTile;
                panelScript.row = r;
                panelScript.column = c;
                panelScript.generatorScript = gameObject.GetComponent<scr_ExtractionGridGenerator>();
            }
        }
        foreach (GameObject tile in gridArray)
        {
            //      assign neighbours
            scr_ResourcePanel tileScript = tile.GetComponent<scr_ResourcePanel>();

            // above tile
            if (tileScript.row > 0)
            {
                tileScript.aboveTile = gridArray[tileScript.row - 1, tileScript.column];
            }

            // left tile
            if (tileScript.column > 0)
            {
                tileScript.leftTile = gridArray[tileScript.row, tileScript.column - 1];
            }

            // right tile
            if (tileScript.column < columns - 1)
            {
                tileScript.rightTile = gridArray[tileScript.row, tileScript.column + 1];

            }

            // below tile
            if (tileScript.row < rows - 1)
            {
                tileScript.belowTile = gridArray[tileScript.row + 1, tileScript.column];
            }
        }

        AssignOreValues();

             
    }

    public void AssignOreValues()
    {
      
        for (int i = 0; i < maxNumberOfRichOreTiles; i++)
        {

            SetOreValue();
        }

        void SetOreValue()
        {
            int randomRow = Random.Range(0, rows - 1);
            int randomColumn = Random.Range(0, columns - 1);

            scr_ResourcePanel gridScript = gridArray[randomRow, randomColumn].GetComponent<scr_ResourcePanel>();

            if (gridScript.oreValue == 0)
            {
                gridScript.oreValue = richOreTilesValue;
            }
            else
            {
                //SetOreValue();
                Debug.Log("Tile already used");
            }

            // Check 3x3 grid of tiles
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (r >= randomRow - 1 && r <= randomRow + 1)
                    {
                        if (c >= randomColumn - 1 && c <= randomColumn + 1)
                        {


                            scr_ResourcePanel _gridScript = gridArray[r, c].GetComponent<scr_ResourcePanel>();

                            Debug.Log("Adjacent tile found, " + " Rich Ore value = " + richOreTilesValue + " this tile current value: " + _gridScript.oreValue);

                            if (_gridScript.oreValue < (richOreTilesValue / 2))
                            {
                                Debug.Log("Setting adjacent tile value ");

                                _gridScript.oreValue = (richOreTilesValue / 2);
                            }
                        }
                    }
                }
            }

            // Check 4x4 grid of tiles
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (r >= randomRow - 2 && r <= randomRow + 2)
                    {
                        if (c >= randomColumn - 2 && c <= randomColumn + 2)
                        {


                            scr_ResourcePanel _gridScript = gridArray[r, c].GetComponent<scr_ResourcePanel>();

                            Debug.Log("Adjacent tile found, " + " Rich Ore value = " + richOreTilesValue + " this tile current value: " + _gridScript.oreValue);

                            if (_gridScript.oreValue < (richOreTilesValue / 4))
                            {
                                Debug.Log("Setting adjacent tile value ");

                                _gridScript.oreValue = (richOreTilesValue / 4);
                            }
                        }
                    }
                }
            }
        }

        

    }

    public void TileScanned(int rowClicked, int columnClicked)
    {
        if (scr_TileGame.remainingScans > 0)
        {
            scr_TileGame.remainingScans--;

            Debug.Log("CLICKED ON TILE AT X:" + rowClicked + " Y:" + columnClicked);

            // Check 3x3 grid of tiles
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (r >= rowClicked - 1 && r <= rowClicked + 1)
                    {
                        if (c >= columnClicked - 1 && c <= columnClicked + 1)
                        {
                            scr_ResourcePanel _gridScript = gridArray[r, c].GetComponent<scr_ResourcePanel>();

                            _gridScript.ScanReveal();
                            //gridArray[r, c].GetComponent<Image>().color = Color.blue;
                        }
                    }
                }
            }

        }

    }

    public void TileExtracted(int rowClicked, int columnClicked)
    {
        if (scr_TileGame.remainingExtracts > 0)
        {
            scr_TileGame.remainingExtracts--;
            scr_ResourcePanel _gridScript = gridArray[rowClicked, columnClicked].GetComponent<scr_ResourcePanel>();


            // Check 3x3 grid of tiles
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (r >= rowClicked - 1 && r <= rowClicked + 1)
                    {
                        if (c >= columnClicked - 1 && c <= columnClicked + 1)
                        {


                            scr_ResourcePanel __gridScript = gridArray[r, c].GetComponent<scr_ResourcePanel>();


                            if (__gridScript.oreValue == 50)
                            {

                                __gridScript.oreValue = 25;
                            }
                        }
                    }
                }
            }


            _gridScript.Extract();
        }


    }



}
