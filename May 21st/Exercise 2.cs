using System;
using System.Collections.Generic;
class CoinChange
{
    public static void MakeChange(int amount)
    {
        int[] denominations = {1000, 500, 200, 100, 50, 20, 10, 5, 2, 1};
        List<int> coinsUsed = new List<int>();
        int remaining = amount;
        foreach(int coin in denominations)
        {
            while(remaining >= coin)
            {
                coinsUsed.Add(coin);
                remaining -= coin;

            }
        }
        Console.WriteLine($"Amount : {amount}");
        Console.WriteLine($"Total Coins Used :" + string.Join(",", coinsUsed));
        Console.WriteLine($"Total Coins : {coinsUsed.Count}");

    }
    static void Main()
    {
        int amount = 880;
        MakeChange(amount);
    }
}