using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ExtractionGridGenerator : MonoBehaviour
{
    public int rows;
    public int columns;

    public GameObject resourcePanelPrefab;

    void Start()
    {
        gameObject.GetComponent<GridLayoutGroup>().cellSize = new Vector2((480 / rows), (480 / columns));

        MakePanels();
        
    }

    public void MakePanels()
    {
        int totalPanels = rows * columns;

        for (int i = 0; i < totalPanels; i++)
        {
            Instantiate(resourcePanelPrefab, gameObject.transform);
        }

    }
}
