public class Majority_Element
{
    [Theory]
    [InlineData(new int[] { 3, 2, 3 }, 3)]
    [InlineData(new int[] { 2, 2, 1, 1, 1, 2, 2 }, 2)]
    public void Test(int[] input, int expected)
    {
        var s = new Solution();
        var result = s.MajorityElement(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int MajorityElement(int[] nums)
    {
        var candidate = int.MinValue;
        var count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (count <= 0)
            {
                candidate = nums[i];
                count = 0;
            }

            if (nums[i] == candidate)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        return candidate;
    }
}
