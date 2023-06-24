public class Group_Anagrams
{
    [Theory]
    [InlineData(new[] { "eat", "tea", "tan", "ate", "nat", "bat" }, 2)]
    public void Test(string[] input)
    {
        var s = new Solution();
        var result = s.GroupAnagrams(input);
    }
}

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var dict = new Dictionary<string, IList<string>>();

        foreach (var str in strs)
        {
            var arr = str.ToCharArray();
            Array.Sort(arr);
            var orderedStr = new string(arr);

            if (!dict.TryGetValue(orderedStr, out var list))
            {
                list = new List<string>();
                dict[orderedStr] = list;
            }

            list.Add(str);
        }

        return dict.Values.ToList();
    }
}
