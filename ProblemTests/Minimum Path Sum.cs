public class Minimum_Path_Sum
{
    [Theory]
    [InlineData("[[1,3,1],[1,5,1],[4,2,1]]", 7)]
    [InlineData("[[1,2,3],[4,5,6]]", 12)]
    public void Test(string arrStr, int expected)
    {
        var arr = ArrayUtils.ArrayFromStr(arrStr);
        var s = new Solution();
        s.MinPathSum(arr).ShouldBe(expected);
    }
}

public class Solution
{
    public int MinPathSum(int[][] matrix)
    {
        var width = matrix[0].Length;
        var height = matrix.Length;
        var sumMatrix = new int[height][];

        for (int y = 0; y < height; y++)
        {
            sumMatrix[y] = new int[width];
        }

        for (int y = 0; y < height; y++)
        {
            var srcRow = matrix[y];
            var sumRow = sumMatrix[y];

            for (int x = 0; x < width; x++)
            {
                var cell = srcRow[x];

                if (x == 0 && y == 0)
                {
                    sumRow[x] = cell;
                }

                var curSum = sumRow[x];

                if (x < width - 1)
                {
                    var right = matrix[y][x + 1];
                    var newRight = right + curSum;
                    var rightSum = sumRow[x + 1];

                    if (rightSum == 0 || rightSum > newRight)
                    {
                        sumRow[x + 1] = newRight;
                    }
                }

                if (y < height - 1)
                {
                    sumMatrix[y + 1][x] = curSum + matrix[y + 1][x];
                }
            }
        }

        return sumMatrix[height - 1][width - 1];
    }
}
