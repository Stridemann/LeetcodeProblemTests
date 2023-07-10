public class Search_a_2D_Matrix
{
    [Theory]
    [InlineData("[[1,3,5,7],[10,11,16,20],[23,30,34,60]]", 3, true)]
    [InlineData("[[1,2],[4,5]]", 2, true)]
    public void Test(string arrStr, int target, bool expected)
    {
        var arr = ArrayUtils.ArrayFromStr(arrStr);
        var s = new Solution();
        s.SearchMatrix(arr, target).ShouldBe(expected);
    }
}

public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var width = matrix[0].Length;
        var maxLen = matrix.Length * width;

        int left = 0;
        int right = maxLen - 1;

        while (left <= right)
        {
            int middle = (left + right) / 2;
            var y = middle / width;
            var x = middle % width;
            var num = matrix[y][x];

            if (num < target)
                left = middle + 1;
            else if (num > target)
                right = middle - 1;
            else
                return true;
        }

        return false;
    }
}
