using Shouldly;

public class Rotate_Image

{
    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 2)]
    public void Test(int[] nums, int expected)
    {
        var matrix1 = new int[][]
        {
            new[] { 5, 1, 9, 11 },
            new[] { 2, 4, 8, 10 },
            new[] { 13, 3, 6, 7 },
            new[] { 15, 14, 12, 16 },
        };

        var matrix2 = new int[][]
        {
            new[] { 1, 2, 3 },
            new[] { 4, 5, 6 },
            new[] { 7, 8, 9 },
        };
        var s = new Solution();
        s.Rotate(matrix2);
    }
}

public class Solution
{
    public void Rotate(int[][] matrix)
    {
        var size = matrix.Length;

        for (int y = 0; y <= size / 2; y++)
        {
            for (int x = y; x < size - y - 1; x++)
            {
                var ind2X = size - y - 1;
                var ind3X = size - x - 1;
                var ind3Y = size - y - 1;
                var ind4Y = size - x - 1;
                var tmp = matrix[y][x];
                matrix[y][x] = matrix[ind4Y][y];
                matrix[ind4Y][y] = matrix[ind3Y][ind3X];
                matrix[ind3Y][ind3X] = matrix[x][ind2X];
                matrix[x][ind2X] = tmp;
            }
        }
    }
}
