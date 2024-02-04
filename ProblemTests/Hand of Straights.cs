public class Hand_of_Straights
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 6, 2, 3, 4, 7, 8 }, 3, true)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, false)]
    [InlineData(new int[] { 8, 8, 9, 7, 7, 7, 6, 7, 10, 6 }, 2, true)]
    public void Test(int[] input, int groupSize, bool expected)
    {
        var s = new Solution();
        var result = s.IsNStraightHand(input, groupSize);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        if (hand.Length % groupSize != 0)
            return false;
        var dict = new Dictionary<int, int>();

        foreach (var i in hand)
        {
            dict.TryGetValue(i, out var cnt);
            dict[i] = cnt + 1;
        }

        while (dict.Count > 0)
        {
            var first = dict.First();
            int currentGroup = 1;

            var minKey = first.Key;

            while (dict.TryGetValue(minKey - 1, out var iterVal))
            {
                minKey--;
                currentGroup++;
            }

            var maxKey = first.Key;

            while (currentGroup < groupSize && dict.TryGetValue(maxKey + 1, out var iterVal))
            {
                maxKey++;
                currentGroup++;
            }

            if (currentGroup < groupSize)
                return false;

            for (int j = 0; j < groupSize; j++)
            {
                var removeKey = minKey + j;

                dict.TryGetValue(removeKey, out var iterVal);

                if (iterVal == 1)
                    dict.Remove(removeKey);
                else
                    dict[removeKey] = iterVal - 1;
            }
        }

        return dict.Count == 0;
    }
}