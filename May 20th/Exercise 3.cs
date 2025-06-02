using System;
using System.Collections.Generic;
class DijkstraAlgorithm
{
    private static readonly int NO_PARENT = -1;
    public static void Dijkstra(int[,] adjacencyMatrix, int startVertex)
    {
        int nVertices = adjacencyMatrix.GetLength(0);
        int[] shortestDistances = new int[nVertices];
        bool[] added = new bool[nVertices];
        for(int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
        {
            shortestDistances[vertexIndex] = int.MaxValue;
            added[vertexIndex] = false;
        }
        shortestDistances[startVertex] = 0;
        int[] parents = new int[nVertices];
        parents[startVertex] = NO_PARENT;
        for(int i = 1; i < nVertices; i++)
        {
            int nearestVertex = -1;
            int shortestDistance = int.MaxValue;
            for(int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
            {
                if (!added[vertexIndex] && shortestDistances[vertexIndex] < shortestDistance)
                {
                    nearestVertex = vertexIndex;
                    shortestDistance = shortestDistances[vertexIndex];
                }
            }
            added[nearestVertex] = true;
            for(int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
            {
                int edgeDistance = adjacencyMatrix[nearestVertex, vertexIndex];
                if(edgeDistance > 0 && ((shortestDistance + edgeDistance)) < shortestDistances[vertexIndex])
                {
                    parents[vertexIndex] = nearestVertex;
                    shortestDistances[vertexIndex] = shortestDistance + edgeDistance;
                }
            }
        }
        PrintSolution(startVertex, shortestDistances, parents);
    }
    private static void PrintSolution(int startVertex, int[]distances, int[]parents)
    {
        int nVertices = distances.Length;
        Console.WriteLine("Vertex\t Distance\t Path");
        for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
        {
            if(vertexIndex != startVertex)
            {
                Console.Write($"\n{startVertex} -> {vertexIndex} \t {distances[vertexIndex]}\t\t");
                PrintPath(vertexIndex, parents);
            }
        }
    }
    private static void PrintPath(int currentVertex, int[] parents)
    {
        if(currentVertex == NO_PARENT)
        {
            return;
        }
        PrintPath(parents[currentVertex], parents);
        Console.Write(currentVertex + " ");
    }
    static void Main()
    {
        int[,] adjacencyMatrix =
        {
             /* 0 */ {0, 6, 0, 1, 0 },
             /* 1 */ {6, 0, 5, 2, 2 },
             /* 2 */ {0, 5, 0, 0, 5 },
             /* 3 */ {1, 2, 0, 0, 1 },
             /* 4 */ {0, 2, 5, 1, 0 }
        };
        Console.WriteLine("Dijkstra's  Algorithm - Shortest Path from Node 0 :");
        Dijkstra(adjacencyMatrix, 0);
    }
}