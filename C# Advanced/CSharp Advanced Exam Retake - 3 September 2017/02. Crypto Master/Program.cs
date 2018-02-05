using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine()
            .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int bestLenIncreasingSeq = 1;
        int jumpCount = 1;

        while (jumpCount < arr.Length)
        {   
            for (int startIndex = 0; startIndex < arr.Length; startIndex++)
            {
                int currentIndex = startIndex;
                int nextIndex = currentIndex + jumpCount;
                int currentIncreasingSeqLen = 1;

                while (true)
                {
                    if (nextIndex >= arr.Length)
                    {
                        nextIndex -= arr.Length;
                    }
                    if (arr[currentIndex] < arr[nextIndex])
                    {
                        currentIncreasingSeqLen++;
                        if (currentIncreasingSeqLen > bestLenIncreasingSeq)
                        {
                            bestLenIncreasingSeq = currentIncreasingSeqLen;
                        }
                    }
                    else
                    {
                        break;
                    }

                    currentIndex = nextIndex;
                    nextIndex += jumpCount;
                }
            }

            jumpCount++;
        }

        Console.WriteLine(bestLenIncreasingSeq);
    }
}