public class Sort_Colors
{
    [Theory]
    [InlineData(new[] { 2, 0, 2, 1, 1, 0 }, new[] { 0, 0, 1, 1, 2, 2 })]
    [InlineData(new[] { 2, 0, 1 }, new[] { 0, 1, 2 })]
    public void Test(int[] nums, int[] expected)
    {
        var s = new Solution();
        var result = s.SortColors(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int[] SortColors(int[] nums)
    {
        int lo = 0, mid = 0, hi = nums.Length - 1;

        while (mid <= hi)
        {
            var num = nums[mid];

            switch (num)
            {
                case 0:
                    (nums[lo], nums[mid]) = (nums[mid], nums[lo]);
                    lo++;
                    mid++;

                    break;
                case 1:

                    mid++;

                    break;
                case 2:

                    (nums[mid], nums[hi]) = (nums[hi], nums[mid]);

                    hi--;

                    break;
            }
        }

        return nums;
    }
}
