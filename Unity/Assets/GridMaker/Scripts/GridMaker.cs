using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Cells
{
    public string id;
    public GameObject cellPrefab;
}

public class GridMaker : MonoBehaviour
{


    public Cells[] cells;

    public int gridSize = 10;
    public int initialHeight = 0;
    public int scale = 10;

    public GameObject cell_1;

    // Start is called before the first frame update
    void Start()
    {
        // Matrix of chars with random chars from 0 to 9
        char[,] terrain = new char[gridSize, gridSize];
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                terrain[i, j] = (char)UnityEngine.Random.Range(49, 49); // 49, 58
            }
        }

        // Convert the array of cells to a dictionary
        Dictionary<char, GameObject> cellPrefabs = convertDictionary(cells);

        CreateGrid(cellPrefabs, terrain);
    }

    private Dictionary<char, GameObject> convertDictionary(Cells[] cells)
    {
        Dictionary<char, GameObject> cellPrefabs = new Dictionary<char, GameObject>();

        // Convert the array of cells to a dictionary
        foreach (Cells cell in cells)
        {
            cellPrefabs.Add(cell.id[0], cell.cellPrefab);
        }
        return cellPrefabs;
    }

    // Create a grid of cells
    private void CreateGrid(Dictionary<char, GameObject> cellPrefabs, char[,] terrain)
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if (cellPrefabs.ContainsKey(terrain[i, j]))
                {
                    GameObject cell = Instantiate(cellPrefabs[terrain[i, j]], new Vector3(i * scale, initialHeight, j * scale), Quaternion.identity);
                    cell.transform.parent = this.transform;
                    // Change the size of the cell keeping the prefab's y value
                    cell.transform.localScale = new Vector3(scale, cell.transform.localScale.y, scale);
                    // Change the position so regardless of the y scale, the object always starts at the initialHeight
                    cell.transform.position = new Vector3(cell.transform.position.x, initialHeight + cell.transform.localScale.y / 2, cell.transform.position.z);
                }
                else
                {
                    Debug.Log("The key " + terrain[i, j] + " does not exist in the dictionary");
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
