using System;
class LCSAlgorithm
{
    public static(int length, string subsequence) LCS(string str1, string str2)
    {
        int m = str1.Length;
        int n = str2.Length;
        int[,] dp = new int[m + 1, n + 1];
        for(int i = 1; i <= m; i++)
        {
            for(int j = 1; j <= n; j++)
            {
                if (str1[i - 1] == str2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }
        string lcs = ReconstructLCS(dp, str1, str2, m, n);
        return(dp[m,n], lcs);
    }
    private static string ReconstructLCS(int[,] dp, string str1, string str2, int i, int j)
    {
        if (i == 0 || j == 0)
            return "";
        if (str1[i - 1] == str2[j - 1])
            return ReconstructLCS(dp, str1, str2, i - 1, j - 1) + str1[i - 1];
        if (dp[i - 1, j] > dp[i, j - 1])
            return ReconstructLCS(dp, str1, str2, i - 1, j);
        return ReconstructLCS(dp, str1, str2, i, j - 1);
    }
    static void Main()
    {
        string str1 = "ABCDGH";
        string str2 = "AEDFHR";
        var result = LCS(str1, str2);
        Console.WriteLine($"Input Strings : \"{str1}\",\"{str2}\"");
        Console.WriteLine($"LCS : \"{result.subsequence}\"");
        Console.WriteLine($"Length : {result.length}");
        Console.WriteLine("\nTime Complexity Analysis :");
        Console.WriteLine("- O(m*n) time and space complexity");
        Console.WriteLine("- Where m and n are lengths of the input strings");
    }
}