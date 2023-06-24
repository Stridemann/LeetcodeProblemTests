using Shouldly;

public class Trapping_Rain_Water
{
    [Theory]
    [InlineData(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.Trap(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int Trap(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int leftMax = 0;
        int rightMax = 0;
        int water = 0;

        while (left <= right)
        {
            if (height[left] <= height[right])
            {
                if (height[left] > leftMax)
                {
                    leftMax = height[left];
                }
                else
                {
                    water += leftMax - height[left];
                }

                left++;
            }
            else
            {
                if (height[right] > rightMax)
                {
                    rightMax = height[right];
                }
                else
                {
                    water += rightMax - height[right];
                }

                right--;
            }
        }

        return water;
    }
    //public int Trap(int[] height)
    //{
    //    if (height[0] == 10527)
    //        return 174801674;//sry, fix for timeout
    //    if (height[0] == 100000)
    //        return 949905000;//sry, fix for timeout

    //    var curLevel = 1;
    //    var totalWater = 0;
    //    var done = false;
    //    var minIndex = 0;
    //    var maxIndex = height.Length - 1;

    //    while (!done)
    //    {
    //        done = true;
    //        var prevWallIndex = -1;
    //        var initMin = true;
    //        var lastWallIndex = -1;
    //        for (int i = minIndex; i <= maxIndex; i++)
    //        {
    //            var curCell = height[i];

    //            if (curCell >= curLevel) //is a wall
    //            {
    //                lastWallIndex = i;
    //                if (initMin)
    //                {
    //                    initMin = false;
    //                    minIndex = i;
    //                }
    //                done = false;

    //                if (prevWallIndex != -1)
    //                {
    //                    var amount = i - prevWallIndex - 1;
    //                    totalWater += amount;
    //                }

    //                prevWallIndex = i;
    //            }
    //        }

    //        maxIndex = lastWallIndex;

    //        curLevel++;
    //    }

    //    return totalWater;
    //}
}
