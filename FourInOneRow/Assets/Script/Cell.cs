using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    // Player ID occupying the cell (default -1 for empty)
    public int playerID = -1;

    // Boolean flag indicating if the cell is empty
    public bool isEmpty = true;

    // Method to place a piece on the cell, setting player ID and emptiness flag
    public void PlacePiece(int playerID)
    {
        this.playerID = playerID;
        isEmpty = false;
    }
}

