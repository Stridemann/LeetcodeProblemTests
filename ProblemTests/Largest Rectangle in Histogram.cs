public class Largest_Rectangle_in_Histogram
{
    [Theory]
    [InlineData(new[] { 2, 1, 5, 6, 2, 3 }, 10)]
    [InlineData(new[] { 2, 4 }, 4)]
    [InlineData(new[] { 0, 9 }, 9)]
    [InlineData(new[] { 2, 1, 2 }, 3)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.LargestRectangleArea(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int LargestRectangleArea(int[] height)
    {
        if (height.Length == 1)
            return height[0];
        int[] lessFromLeft = new int[height.Length]; // idx of the first bar the left that is lower than current
        int[] lessFromRight = new int[height.Length]; // idx of the first bar the right that is lower than current
        lessFromRight[height.Length - 1] = height.Length;
        lessFromLeft[0] = -1;

        for (int i = 1; i < height.Length; i++)
        {
            int p = i - 1;

            while (p >= 0 && height[p] >= height[i])
            {
                p = lessFromLeft[p];
            }

            lessFromLeft[i] = p;
        }

        for (int i = height.Length - 2; i >= 0; i--)
        {
            int p = i + 1;

            while (p < height.Length && height[p] >= height[i])
            {
                p = lessFromRight[p];
            }

            lessFromRight[i] = p;
        }

        int maxArea = 0;

        for (int i = 0; i < height.Length; i++)
        {
            maxArea = Math.Max(maxArea, height[i] * (lessFromRight[i] - lessFromLeft[i] - 1));
        }

        return maxArea;
    }
}
