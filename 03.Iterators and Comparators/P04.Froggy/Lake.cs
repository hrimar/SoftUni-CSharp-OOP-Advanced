using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Lake : IEnumerable<int>
{
    private int[] stones;

    public Lake(int[] items)
    {
        this.stones = items;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < stones.Length; i = i + 2)
        {
            yield return stones[i];
        }
        var lastOddIndex = this.stones.Length % 2 == 0 ? this.stones.Length - 1 : this.stones.Length - 2;
        for (int i = lastOddIndex; i >= 0; i -= 2)
        {
            yield return stones[i];
        }

        //if (stones.Length % 2 != 0)
        //{
        //    for (int i = stones.Length - 2; i >= 0; i -= 2)
        //    {
        //        yield return stones[i];
        //    }
        //}
        //else
        //{
        //    for (int i = stones.Length - 1; i >= 0; i -= 2)
        //    {
        //        yield return stones[i];
        //    }
        //}

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

