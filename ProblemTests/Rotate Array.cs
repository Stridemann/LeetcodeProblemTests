public class Rotate_Array
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4 })]
    [InlineData(new int[] { -1, -100, 3, 99 }, 2, new int[] { 3, 99, -1, -100 })]
    public void Test(int[] input, int k, int[] expected)
    {
        var s = new Solution();
        s.Rotate(input, k);
        input.ShouldBe(expected);
    }
}

public class Solution
{
    public void Rotate(int[] nums, int k)
    {
        var shift = k % nums.Length;

        if (shift == 0)
            return;

        var ptr1 = nums.Length - 1;
        var ptr2 = nums.Length - shift - 1;

        for (int i = 0; i < nums.Length; i++)
        {
            (nums[ptr1], nums[ptr2]) = (nums[ptr2], nums[ptr1]);
            ptr1--;
            ptr2--;

            if (ptr1 < 0)
                ptr1 = nums.Length - 1;

            if (ptr2 < 0)
                ptr2 = nums.Length - 1;
        }
    }
}
