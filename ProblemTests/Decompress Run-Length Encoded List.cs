using Shouldly;

public class Decompress_Run_Length_Encoded_List
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, new[] { 2, 4, 4, 4 })]
    public void Test(int[] nums, int[] expected)
    {
        var s = new Solution();
        var result = s.DecompressRLElist(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int[] DecompressRLElist(int[] nums)
    {
        var list = new List<int>(nums.Length);

        for (int i = 0; i < nums.Length / 2; i++)
        {
            var freq = nums[i * 2];
            var val = nums[i * 2 + 1];

            for (int j = 0; j < freq; j++)
            {
                list.Add(val);
            }
        }

        return list.ToArray();
    }
}
