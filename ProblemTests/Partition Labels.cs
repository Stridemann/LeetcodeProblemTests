public class Partition_Labels
{
    [Theory]
    [InlineData("ababcbacadefegdehijhklij", new int[] { 9, 7, 8 })]
    public void Test(string input, int[] expected)
    {
        var s = new Solution();
        var result = s.PartitionLabels(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public IList<int> PartitionLabels(string s)
    {
        var dict = new Dictionary<char, int>();

        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            dict[c] = i;
        }
        var result = new List<int>();
        var start = 0;
        var end = 0;
        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            var last = dict[c];

            if(end < last)
                end = last;

            if (i == end)
            {
                result.Add(end - start + 1);
                start = i + 1;
            }
        }

        return result;
    }
}
