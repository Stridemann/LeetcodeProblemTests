using System.Drawing;

public class Surrounded_Regions
{
    [Theory]
    [InlineData("[[\"X\",\"O\",\"X\",\"O\",\"X\",\"O\"],[\"O\",\"X\",\"O\",\"X\",\"O\",\"X\"],[\"X\",\"O\",\"X\",\"O\",\"X\",\"O\"],[\"O\",\"X\",\"O\",\"X\",\"O\",\"X\"]]", 2)]
    public void Test(string arrStr, int expected)
    {
        var arr = ArrayUtils.CharArrayFromStr(arrStr);
        var s = new Solution();
        s.Solve(arr);
    }
}

public class Solution
{
    private readonly HashSet<System.Drawing.Point> _checked = new HashSet<System.Drawing.Point>();
    private readonly Queue<System.Drawing.Point> _currentRegion = new Queue<System.Drawing.Point>();
    private int _height;
    private int _width;
    private bool _hitBorder;
    private char[][] _board;

    public void Solve(char[][] board)
    {
        _board = board;
        _height = board.Length;
        _width = board[0].Length;

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                if (board[y][x] == 'O')
                {
                    _hitBorder = false;
                    Iterate(x, y);

                    if (_hitBorder)
                    {
                        while (_currentRegion.TryDequeue(out var point))
                        {
                            board[point.Y][point.X] = 'O';
                        }
                    }
                    else
                    {
                        _currentRegion.Clear();
                    }
                }
            }
        }
    }

    private void Iterate(int x, int y)
    {
        if (x >= _width || y >= _height || x < 0 || y < 0)
        {
            return;
        }

        if (_board[y][x] != 'O')
        {
            return;
        }

        var point = new System.Drawing.Point(x, y);

        if (_checked.Contains(point))
            return;

        if (x == 0 || y == 0 || x == _width - 1 || y == _height - 1)
            _hitBorder = true;
        _checked.Add(point);
        _board[y][x] = 'X';

        _currentRegion.Enqueue(point);

        Iterate(x + 1, y);
        Iterate(x, y + 1);
        Iterate(x - 1, y);
        Iterate(x, y - 1);
    }
}
