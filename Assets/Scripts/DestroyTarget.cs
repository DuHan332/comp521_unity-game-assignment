using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroyTarget : MonoBehaviour
{
    // Unit part for this route(bridge)
    public GameObject brick;
    // An empty parent object for better orginzation of objects
    public GameObject bridgePar;
    public Vector3 defaultRotation = new Vector3(0, 0, 0);
    private void OnCollisionEnter(Collision collision)
    {
        // Destroy target when collide with fireball
        if (collision.gameObject.tag == "FireBall")
        {
            Destroy(this.gameObject);
            Vector3 pos = new Vector3(-39, 10, 100);
            GameObject firstBrick = Instantiate(brick, pos, Quaternion.Euler(defaultRotation));
            int rows = 40;
            int cols = 38;
            // All neighbours of visited nodes
            int[,] frontier = new int[rows, cols];
            // Visited nodes
            int[,] visited = new int[rows, cols];
            frontier[18, 0] = 1;
            frontier[22, 0] = 1;
            frontier[20, 2] = 1;
            visited[20, 0] = 1;
            while (true)
            {
                System.Random random = new System.Random();
                // Find the all frontiers
                List<Tuple<int, int>> nonZeroCoordinates = new List<Tuple<int, int>>();
                for (int i = 0; i < frontier.GetLength(0); i++)
                {
                    for (int j = 0; j < frontier.GetLength(1); j++)
                    {
                        if (frontier[i, j] == 1)
                        {   
                            nonZeroCoordinates.Add(new Tuple<int, int>(i, j));
                        }
                    }
                }
                // Generate a random index within the range of frontiers
                int randomIndex = random.Next(0, nonZeroCoordinates.Count);
                // Use the random index to find a random frontier
                int newX = nonZeroCoordinates[randomIndex].Item1;
                int newZ = nonZeroCoordinates[randomIndex].Item2;
                // Spawn a brick here
                Vector3 position = new Vector3(newX-59, 10, newZ+100);
                GameObject newBrick = Instantiate(brick, position, Quaternion.Euler(defaultRotation));
                // If it reaches the target, stop
                if (newZ >= cols-2)
                {
                    break;
                }
                // Remove it from frontier
                frontier[newX, newZ] = 0;
                // Make it to be visited
                visited[newX, newZ] = 1;
                // Add new frontiers
                if (newX - 2 >= 0 && visited[newX - 2, newZ] == 0)
                {
                    frontier[newX - 2, newZ] = 1;
                }
                if (newX + 2 < 40 && visited[newX + 2, newZ] == 0)
                {
                    frontier[newX + 2, newZ] = 1;
                }
                if (newZ + 2 < cols && visited[newX, newZ + 2] == 0)
                {
                    frontier[newX, newZ + 2] = 1;
                }
                // Remove all frontier backward to avoid going back
                for (int row = 0; row < 40; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (col < newZ)
                        {
                            frontier[row, col] = 0; 
                        }
                    }
                }
            }
            // Organize all bricks into a parent object
            GameObject[] bridge;
            bridge = GameObject.FindGameObjectsWithTag("Brick");
            foreach (GameObject brick in bridge)
            {
                brick.transform.parent = bridgePar.transform;
            }
        }
        
    }
}
