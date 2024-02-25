using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Reference to the grid object
    public Grid grid;

    // Current player ID (1 for player, 2 for AI)
    public int currentPlayer = 1;

    // Boolean flag indicating game over state
    public bool gameOver = false;

    // Update method handles game logic and user input
    void Update()
    {
        if (!gameOver)
        {
            // Handle player input (e.g., mouse click)
            if (Input.GetMouseButtonDown(0))
            {
                PlacePlayerPiece(GetClickedCell());
            }
            // Handle AI turn (if implemented)
            else if (currentPlayer == 2)
            {
                PlaceAIPiece();
            }
        }
    }

    // Place a piece on the grid based on player input and cell position
    void PlacePlayerPiece(Cell cell)
    {
        if (cell.isEmpty)
        {
            grid.PlacePiece(cell.transform.position.x, cell.transform.position.y, currentPlayer);
            CheckWin();
            SwitchTurn();
        }
    }

    // Implement AI logic to place a piece and handle its turn
    void PlaceAIPiece()
    {
        // Implement AI logic here (e.g., minimax algorithm)
        // Choose the best cell and place the piece using grid.PlacePiece
        // Check win and switch turns
    }

    // Check if any player has achieved a winning condition
    void CheckWin()
    {
        // Implement logic to check for horizontal, vertical, and diagonal lines of four
        // Update gameOver and winner variables if a win condition is met
    }

    // Switch turns between players and AI
    void SwitchTurn()
    {
        currentPlayer = (currentPlayer == 1) ? 2 : 1;
    }
}

