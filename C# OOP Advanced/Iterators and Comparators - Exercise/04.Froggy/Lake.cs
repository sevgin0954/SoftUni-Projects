using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    int[] stones = new int[0];

    public Lake(int[] stones)
    {
        Stones = stones;
    }

    public int[] Stones
    {
        get => stones;
        private set { stones = value; }
    }

    public IEnumerator<int> GetEnumerator()
    {
        int startIndex = 0;

        for (int a = startIndex; a < Stones.Length; a+=2)
        {
            yield return Stones[a];
        }

        startIndex = Stones.Length % 2 == 1 ? Stones.Length - 2 : Stones.Length - 1;

        for (int a = startIndex; a > 0; a-=2)
        {
            yield return Stones[a];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
