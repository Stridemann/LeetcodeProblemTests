using Shouldly;

public class Container_With_Most_Water
{
    [Theory]
    [InlineData(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
    public void Test(int[] heights, int expectedArea)
    {
        var s = new Solution();
        s.MaxArea(heights).ShouldBe(expectedArea);
    }
}

public class Solution
{
    public int MaxArea(int[] height)
    {
        int maxArea = 0;
        int left = 0;
        int right = height.Length - 1;

        while (left < right)
        {
            int currentHeight = Math.Min(height[left], height[right]);
            int currentWidth = right - left;
            int currentArea = currentHeight * currentWidth;

            maxArea = Math.Max(maxArea, currentArea);

            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }
}
