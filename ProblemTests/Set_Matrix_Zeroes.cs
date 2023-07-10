public class Set_Matrix_Zeroes
{
    [Theory]
    [InlineData("[[1,1,1],[1,0,1],[1,1,1]]", "[[1,0,1],[0,0,0],[1,0,1]]")]
    [InlineData("[[0,1,2,0],[3,4,5,2],[1,3,1,5]]", "[[0,0,0,0],[0,4,5,0],[0,3,1,0]]")]
    [InlineData("["
                + "[0,0,0,5],"
                + "[4,3,1,4],"
                + "[0,1,1,4],"
                + "[1,2,1,3],"
                + "[0,0,1,1]]", 
                "["
                + "[0,0,0,0],"
                + "[0,0,0,4],"
                + "[0,0,0,0],"
                + "[0,0,0,3],"
                + "[0,0,0,0]"
                + "]")]
    public void Test(string arrStr, string expected)
    {
        var arr = ArrayUtils.ArrayFromStr(arrStr);
        var s = new Solution();
        s.SetZeroes(arr);
        ArrayUtils.ArrayToStr(arr).ShouldBe(expected);
    }
}

public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        var width = matrix[0].Length;
        var height = matrix.Length;

        var colToClear = new bool[width];

        var clearXMin = int.MaxValue;
        var clearXMax = int.MinValue;
        

        for (int y = 0; y < height; y++)
        {
            var row = matrix[y];
            var clear = false;

            for (int x = 0; x < width; x++)
            {
                if (row[x] == 0)
                {
                    colToClear[x] = true;

                    if (clearXMin > x)
                        clearXMin = x;

                    if (clearXMax < x)
                        clearXMax = x;
                    
                    clear = true;
                }
            }

            if (clear)
            {
                Array.Fill(row, 0);
            }
        }

        for (int y = 0; y < height; y++)
        {
            var row = matrix[y];

            for (int x = clearXMin; x <= clearXMax; x++)
            {
                if (colToClear[x])
                {
                    row[x] = 0;
                }
            }
        }
    }
}
