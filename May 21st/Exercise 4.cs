using System;
class NQueensSolver
{
    public static void SolveNQueens(int n)
    {
        int[,] board = new int[n, n];
        Console.WriteLine($"All solutions for {n}-Queens problem :");
        SolveNQueensUtil(board, 0, n);
    }
    private static void SolveNQueensUtil(int[,] board ,int col, int n)
    {
        if(col >= n)
        {
            PrintSolution(board, n);
                return;
        }
        for(int i = 0; i < n; i++)
        {
            if(IsSafe(board, i, col, n))
            {
                board[i, col] = 1;
                SolveNQueensUtil(board, col + 1, n);
                board[i, col] = 0;
            }
        }
    }
    private static bool IsSafe(int[,] board, int row, int col, int n)
    {
        for(int i = 0; i < col; i++)
            if (board[row, i] == 1)
                return false;
        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            if (board[i, j] == 1)
                return false;
        for (int i = row, j = col; j >= 0 && i < n; i++, j--)
            if (board[i, j] == 1)
                return false;
        return true;
    }
    private static void PrintSolution(int[,] board, int n)
    {
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                Console.Write(board[i, j] == 1 ? "Q" : " _");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    static void Main()
    {
        int n = 4;
        SolveNQueens(n);
    }
}