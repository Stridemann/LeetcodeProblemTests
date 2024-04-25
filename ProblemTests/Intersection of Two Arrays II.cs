public class Intersection_of_Two_Arrays_II
{
    [Theory]
    [InlineData(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 }, new int[] { 2, 2 })]
    public void Test(int[] input1, int[] input2, int[] expected)
    {
        var s = new Solution();
        var result = s.Intersect(input1, input2);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        var countArray = new int[1001];

        foreach (var i in nums1)
        {
            countArray[i]++;
        }

        foreach (var i in nums2)
        {
            countArray[i] += (1 << 16);
        }

        var result = new List<int>();

        for (var i = 0; i < countArray.Length; i++)
        {
            var val = countArray[i];
            var v2 = val & 0xFFFF;
            var v1 = val >> 16;

            var min = Math.Min(v1, v2);

            for (int j = 0; j < min; j++)
            {
                result.Add(i);
            }
        }

        return result.ToArray();
    }
}
