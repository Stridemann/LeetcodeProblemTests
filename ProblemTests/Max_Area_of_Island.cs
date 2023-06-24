using Shouldly;

public class Max_Area_of_Island
{
    [Theory]
    [InlineData(
        "[[0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,1,0,0,0,0,0,0,0,0],[0,1,0,0,1,1,0,0,1,0,1,0,0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,1,1,0,0,0,0]]",
        6)]
    [InlineData(
        "["
        + "[1,1,0,0,0],"
        + "[1,1,0,0,0],"
        + "[0,0,0,1,1],"
        + "[0,0,0,1,1]]",
        4)]
    public void Test(string input, int expected)
    {
        var s = new Solution();
        var array = ArrayUtils.ArrayFromStr(input);
        var result = s.MaxAreaOfIsland(array);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private int[][] _grid;
    private int _height;
    private int _width;

    public int MaxAreaOfIsland(int[][] grid)
    {
        _grid = grid;
        _height = _grid.Length;

        if (_height < 1)
            return 0;
        _width = _grid[0].Length;

        if (_width < 1)
            return 0;

        if (_height == 1 && _width == 1)
        {
            return _grid[0][0];
        }

        var max = 0;

        for (int y = 0; y < _height; y++)
        {
            var row = _grid[y];

            for (int x = 0; x < _width; x++)
            {
                var cellVal = row[x];

                if (cellVal == 0)
                    continue;
                var result = Check(x, y);
                max = Math.Max(max, result);
            }
        }

        return max;
    }

    private int Check(int x, int y)
    {
        if (x < 0 || y < 0 || x == _width || y == _height)
            return 0;

        var nodeVal = _grid[y][x];

        if (nodeVal == 0)
            return 0;
        _grid[y][x] = 0;
        var sum = 1;

        var result = Check(x + 1, y);

        if (result == -1)
            return -1;
        sum += result;

        result = Check(x, y + 1);

        if (result == -1)
            return -1;
        sum += result;

        result = Check(x - 1, y);

        if (result == -1)
            return -1;
        sum += result;

        result = Check(x, y - 1);

        if (result == -1)
            return -1;
        sum += result;

        return sum;
    }
}
