
using System;

using System.Linq;

using System.Collections.Generic;

public static class Test
{

    public static int DpMakeChange(List<int> clist, int amnt, List<int> coinCount, List<int> coinsUsed)
    {
        foreach (int cents in Enumerable.Range(0, amnt + 1))
        {
            int coinQuantity = cents;
            int newCoin = 1;
            foreach (int j in (from c in clist
                               where c <= cents
                               select c).ToList())
            {
                if (coinCount[cents - j] + 1 < coinQuantity)
                {
                    coinQuantity = coinCount[cents - j] + 1;
                    newCoin = j;
                }
            }
            coinCount[cents] = coinQuantity;
            coinsUsed[cents] = newCoin;
        }
        return coinCount[amnt];
    }

    public static void PrintCoins(List<int> coinsUsed, int change)
    {
        int coin = change;
        while (coin > 0)
        {
            int thisCoin = coinsUsed[coin];
            Console.WriteLine(thisCoin);
            coin -= thisCoin;
        }
    }

    static void Main(string[] args)
    {
        int amnt = 63;
        List<int> clist = new List<int> {
            1,
            5,
            10,
            21,
            25
            //1,
            //2,
            //5,
            //10,
            //25
        };

        List<int> coinsUsed = new List<int>();
        for (int i = 0; i <= amnt; i++)
        {
            coinsUsed.Add(0);
        }

        List<int> coinCount = new List<int>();
        for (int i = 0; i <= amnt; i++)
        {
            coinCount.Add(0);
        }

        Console.WriteLine("Making change for", amnt, "requires");
        Console.WriteLine(DpMakeChange(clist, amnt, coinCount, coinsUsed).ToString(), "coins");
        Console.WriteLine("They are:");
        PrintCoins(coinsUsed, amnt);
        Console.WriteLine("The used list is as follows:");

        for (int i = 0; i < coinsUsed.Count; i++)
        {
            Console.Write($"{i} - {coinsUsed[i]}, ");
        }
        Console.ReadLine();
    }
}