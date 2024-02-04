public class Triangle
{
    [Theory]
    [InlineData("[[2],[3,4],[6,5,7],[4,1,8,3]]", 11)]
    [InlineData("[[-10]]", -10)]
    [InlineData("[[-1],[2,3],[1,-1,-3]]", -1)]
    public void Test(string arrStr, int expected)
    {
        var arr = ArrayUtils.ListOfListFromStr(arrStr);
        var s = new Solution();
        s.MinimumTotal(arr).ShouldBe(expected);
    }
}

public class Solution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        if (triangle.Count == 1)
            return triangle[0][0];

        var n = triangle.Count;
        var buffer = new int[n];
        var minCountLoop = buffer.Length - 1;

        for (int i = 0; i < n; i++)
        {
            buffer[i] = triangle[^1][i];
        }

        for (int i = triangle.Count - 2; i >= 0; i--)
        {
            var row = triangle[i];

            for (int j = 0; j < minCountLoop; j++)
            {
                var rowVal = row[j];
                var b0 = buffer[j];
                var b1 = buffer[j + 1];
                buffer[j] = rowVal + Math.Min(b0, b1);
            }

            minCountLoop--;
        }

        return buffer[0];
    }
}
