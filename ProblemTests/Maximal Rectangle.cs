using Shouldly;

public class Maximal_Rectangle
{
    [Theory]
    [InlineData("[['1','0','1','0','0'],['1','0','1','1','1'],['1','1','1','1','1'],['1','0','0','1','0']]", 6)]
    public void Test(string input, int expected)
    {
        var s = new Solution();
        var mat = ArrayUtils.CharArrayFromStr(input);
        var result = s.MaximalRectangle(mat);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int MaximalRectangle(char[][] matrix)
    {
        var width = matrix[0].Length;
        var height = matrix.Length;

        if (width == 1 && height == 1)
        {
            return matrix[0][0] - '0';
        }

        for (int y = 1; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                ref char c = ref matrix[y][x];

                if (c != '0')
                    c = (char)(matrix[y - 1][x] + 1);
            }
        }

        var maxSize = 0;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var maxHeight = matrix[y][x] - '0';

                if (maxSize < maxHeight)
                    maxSize = maxHeight;

                for (var xInc = x + 1; xInc < width; xInc++)
                {
                    var curHeight = matrix[y][xInc] - '0';

                    if (curHeight < maxHeight)
                        maxHeight = curHeight;

                    var curWidth = xInc - x + 1;
                    var curRectSize = maxHeight * curWidth;

                    if (maxSize < curRectSize)
                        maxSize = curRectSize;
                }
            }
        }

        return maxSize;
    }
}
