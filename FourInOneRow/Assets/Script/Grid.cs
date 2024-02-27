using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    // Grid dimensions
    public int width;
    public int height;

    // Prefab for individual cells
    public Transform cellPrefab;

    // Array to store cell references
    public Cell[,] cells;

    // Start method initializes the grid upon game start
    void Start()
    {
        // Create a 2D array to store cell references
        cells = new Cell[width, height];

        // Loop through each grid position
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Instantiate the cell prefab at the current position
                Transform cellTransform = Instantiate(cellPrefab, new Vector3(x, y, 0), Quaternion.identity);

                // Set the cell's parent as the grid object
                cellTransform.parent = transform;

                // Get the cell component and store it in the array
                cells[x, y] = cellTransform.GetComponent<Cell>();
            }
        }
    }

    // Check if a specific cell is empty
    public bool IsCellEmpty(int x, int y)
    {
        // Check if the coordinates are within the grid bounds
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return cells[x, y].isEmpty;
        }
        else
        {
            // Return false if coordinates are outside the grid
            return false;
        }
    }

    // Place a piece on a specific cell
    public void PlacePiece(int x, int y, int playerID)
    {
        // Check if the cell is empty and within bounds
        if (IsCellEmpty(x, y))
        {
            // Place the piece on the cell by calling its PlacePiece method
            cells[x, y].PlacePiece(playerID);
        }
        else
        {
            // Handle potential error or feedback if the cell is already occupied
            Debug.Log("Cell is already occupied!");
        }
    }
}

