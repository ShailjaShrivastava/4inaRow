using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour, IPointerClickHandler
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
        /*  if (!gameOver)
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
        } */


        if (!gameOver)
    {
        // Check for left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Perform a raycast from the camera towards the mouse click position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the raycast hits the grid object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject == grid.gameObject)
                {
                    // Convert the hit point to a grid position
                    Vector2 gridPosition = hit.point - grid.transform.position;
                    int x = Mathf.FloorToInt(gridPosition.x);
                    int y = Mathf.FloorToInt(gridPosition.y);

                    // Get the cell at the calculated position
                    Cell clickedCell = grid.cells[x, y];

                    // Place the player piece and continue game logic
                    PlacePlayerPiece(clickedCell);
                }
            }
        }
        // Handle AI turn (if implemented)
        else if (currentPlayer == 2)
        {
            PlaceAIPiece();
        }
    }



    }





        public void OnPointerClick(PointerEventData eventData)
    {
        if (!gameOver && eventData.pointerEnter.tag == "Grid") // Assuming grid object has a tag "Grid"
        {
            Vector2 gridPosition = eventData.pointerEnter.transform.position - grid.transform.position;
            int x = Mathf.FloorToInt(gridPosition.x);
            int y = Mathf.FloorToInt(gridPosition.y);

            Cell clickedCell = grid.cells[x, y];
            PlacePlayerPiece(clickedCell);
        }
    }

    // Place a piece on the grid based on player input and cell position
    void PlacePlayerPiece(Cell cell)
    {
        if (cell.isEmpty)
        {
          //  grid.PlacePiece(cell.transform.position.x, cell.transform.position.y, currentPlayer);
          grid.PlacePiece(Mathf.FloorToInt(cell.transform.position.x), Mathf.FloorToInt(cell.transform.position.y), currentPlayer);

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

