public class Pacific_Atlantic_Water_Flow
{
    [Theory]
    [InlineData("[[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]", 7)]
    public void Test(string arrStr, int expected)
    {
        var arr = ArrayUtils.ArrayFromStr(arrStr);
        var s = new Solution();
        s.PacificAtlantic(arr).Count.ShouldBe(expected);
    }
}

public class Solution
{
    private int _height;
    private int _width;
    private Flags[][] _flags;
    private Ocean _curOcean;
    private List<IList<int>> _result;

    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        _height = heights.Length;
        _width = heights[0].Length;
        _flags = new Flags[_height][];
        _result = new List<IList<int>>();

        for (int y = 0; y < _height; y++)
        {
            var flagsRow = new Flags[_width];
            _flags[y] = flagsRow;
            var row = heights[y];

            for (int x = 0; x < _width; x++)
            {
                flagsRow[x].Value = row[x];
            }
        }

        //Process Pacific
        _curOcean = Ocean.Pacific;

        for (int x = 0; x < _width; x++)
        {
            DoSpread(x, 0, 0);
        }

        for (int y = 1; y < _height; y++)
        {
            DoSpread(0, y, 0);
        }

        //Process Atlantic
        _curOcean = Ocean.Atlantic;

        for (int x = 0; x < _width; x++)
        {
            DoSpread(x, _height - 1, 0);
        }

        for (int y = 0; y < _height - 1; y++)
        {
            DoSpread(_width - 1, y, 0);
        }

        return _result;
    }

    private void DoSpread(int x, int y, int srcVal)
    {
        var flagsY = _flags[y];
        ref Flags flags = ref flagsY[x];

        if (flags.Value < srcVal)
            return;

        if ((flags.Ocean & _curOcean) == _curOcean)
            return;
        flags.Ocean |= _curOcean;

        if (flags.Ocean == Ocean.Both)
        {
            _result.Add(new List<int> { y, x });
        }

        if (x < _width - 1)
        {
            DoSpread(x + 1, y, flags.Value);
        }

        if (x > 0)
        {
            DoSpread(x - 1, y, flags.Value);
        }

        if (y < _height - 1)
        {
            DoSpread(x, y + 1, flags.Value);
        }

        if (y > 0)
        {
            DoSpread(x, y - 1, flags.Value);
        }
    }

    private struct Flags
    {
        public int Value;
        public Ocean Ocean;
        public Ocean HitOcean;
    }

    [Flags]
    private enum Ocean
    {
        None = 0,
        Pacific = 1,
        Atlantic = 2,
        Both = 3
    }
}
