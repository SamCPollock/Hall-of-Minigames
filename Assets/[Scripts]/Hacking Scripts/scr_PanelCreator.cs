using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_PanelCreator : MonoBehaviour
{
    public int rows;
    public int columns;

    public GameObject panelPrefab;

    private void Start()
    {
        CreatePanels();
    }

    public void CreatePanels()
    {
        foreach(Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
        int totalPanels = rows * columns;
        gameObject.GetComponent<GridLayoutGroup>().constraintCount = columns;

        for (int i = 0; i < totalPanels; i++)
        {
            GameObject panel = Instantiate(panelPrefab, this.transform);
            //Debug.Log(panel.GetComponent<scr_Panel>().row);
            //Debug.Log(panel);
            panel.GetComponent<scr_Panel>().row = i % columns;

            panel.GetComponent<scr_Panel>().column = i / columns;
            panel.GetComponent<scr_PanelRandomizer>().RandomizeString();

        }
    }
}
