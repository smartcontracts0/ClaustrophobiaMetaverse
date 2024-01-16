using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField] MazeGenerator mazeGenerator;
    [SerializeField] GameObject MazeCellPrefab;
    [SerializeField] GameObject endpointPrefab; // Add the endpoint prefab here

    public float CellSize = 1f;

    private void Start()
    {
        mazeGenerator.GenerateMaze();

        MazeCell[,] maze = mazeGenerator.GetMaze();

        for (int x = 0; x < mazeGenerator.mazeWidth; x++)
        {
            for (int y = 0; y < mazeGenerator.mazeHeight; y++)
            {
                GameObject newCell = Instantiate(MazeCellPrefab, new Vector3((float)x * CellSize, 0f, (float)y * CellSize), Quaternion.identity, transform);
                MazeCellObject mazeCell = newCell.GetComponent<MazeCellObject>();

                bool top = maze[x, y].topWall;
                bool left = maze[x, y].leftWall;

                bool right = false;
                bool bottom = false;
                if (x == mazeGenerator.mazeWidth - 1) right = true;
                if (y == 0) bottom = true;

                mazeCell.Init(top, bottom, right, left);
            }
        }

        // Instantiate endpoint at the last cell
        int lastCellX = mazeGenerator.mazeWidth - 1;
        int lastCellY = mazeGenerator.mazeHeight - 1;
        Instantiate(endpointPrefab, new Vector3((float)lastCellX * CellSize, 0f, (float)lastCellY * CellSize), Quaternion.identity);
    }
}
