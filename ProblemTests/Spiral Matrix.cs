using Shouldly;

public class Spiral_Matrix
{
    [Theory]
    [InlineData("[[1,2,3],[4,5,6],[7,8,9]]", new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 })]
    [InlineData("[[1,2,3,4],[5,6,7,8],[9,10,11,12]]", new int[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 })]
    public void Test(string arr, int[] expected)
    {
        var input = ArrayUtils.ArrayFromStr(arr);
        var s = new Solution();
        var result = s.SpiralOrder(input);
        result.ToArray().ShouldBe(expected);
    }
}

public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var width = matrix[0].Length;
        var height = matrix.Length;

        var left = 0;
        var right = width - 1;
        var top = 0;
        var bottom = height - 1;
        var result = new List<int>();

        while (bottom >= top && right >= left)
        {
            for (int x = left; x <= right; x++)
            {
                result.Add(matrix[top][x]);
            }

            top++;

            if (top > bottom)
                break;

            for (int y = top; y <= bottom; y++)
            {
                result.Add(matrix[y][right]);
            }

            right--;

            if (left > right)
                break;

            for (int x = right; x >= left; x--)
            {
                result.Add(matrix[bottom][x]);
            }

            bottom--;

            for (int y = bottom; y >= top; y--)
            {
                result.Add(matrix[y][left]);
            }

            left++;
        }

        return result;
    }
}
