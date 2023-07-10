using Shouldly;

public class Largest_Rectangle_in_Histogram
{
    [Theory]
    [InlineData(new[] { 2, 1, 5, 6, 2, 3 }, 10)]
    [InlineData(new[] { 2, 4 }, 4)]
    [InlineData(new[] { 0, 9 }, 9)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.LargestRectangleArea(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        if (heights.Length == 0)
            return 0;

        if (heights.Length == 1)
            return heights[0];
        var maxArea = 0;

        for (int x = 0; x < heights.Length; x++)
        {
            var maxHeight = heights[x];

            if (maxArea < maxHeight)
                maxArea = maxHeight;

            for (int xInc = x + 1; xInc < heights.Length; xInc++)
            {
                var curHeight = heights[xInc];

                if (curHeight == 0)
                    break;

                if (maxHeight > curHeight)
                    maxHeight = curHeight;

                var curWidth = xInc - x + 1;
                var curArea = curWidth * maxHeight;

                if (maxArea < curArea)
                    maxArea = curArea;
            }
        }

        return maxArea;
    }
}
