using System.Drawing;
using System.Text;
using Shouldly;

public class N_Queens
{
    [Theory]
    [InlineData(5)]
    public void Test(int n)
    {
        var s = new Solution();
        var result = s.SolveNQueens(n);
    }
}

public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        var result = new List<IList<string>>();

        if (n == 0 || n == 3)
            return result;

        if (n == 1)
        {
            result.Add(new List<string> { "Q" });

            return result;
        }

        var sb = new StringBuilder(new string('.', n));
        var queensPos = new System.Drawing.Point[n];
        queensPos[0] = new System.Drawing.Point(-1, 0);

        int y = 0;

        while (true)
        {
            if (y < n - 1)
            {
                queensPos[y + 1] = new System.Drawing.Point(-1, y + 1);
            }

            var x = ++queensPos[y].X;

            if (x >= n)
            {
                y--;

                if (y < 0)
                    return result;

                continue;
            }

            var collide = false;

            for (int qPrevY = 0; qPrevY < y; qPrevY++)
            {
                var prevPos = queensPos[qPrevY];

                if (prevPos.X == x)
                {
                    collide = true;

                    break;
                }

                var diffX = prevPos.X - x;
                var diffY = prevPos.Y - y;

                if (Math.Abs(diffX) == Math.Abs(diffY)) //diagonal
                {
                    collide = true;

                    break;
                }
            }

            if (!collide)
            {
                y++;

                if (y == n)
                {
                    y -= 2;
                    var resList = new List<string>();
                    var failed = false;

                    for (int printQ = 0; printQ < queensPos.Length; printQ++)
                    {
                        var qPos = queensPos[printQ];

                        if (qPos.X == -1)
                        {
                            failed = true;

                            break;
                        }

                        sb[qPos.X] = 'Q';
                        resList.Add(sb.ToString());
                        sb[qPos.X] = '.';
                    }

                    if (!failed)
                        result.Add(resList);
                }
            }
        }

        return result;
    }
}

public class Solution
{
    public int TotalNQueens(int n)
    {
        if (n == 0 || n == 3)
            return 0;

        if (n == 1)
        {
            return 1;
        }

        var solutions = 0;
        var queensPos = new System.Drawing.Point[n];
        queensPos[0] = new System.Drawing.Point(-1, 0);

        int y = 0;

        while (true)
        {
            if (y < n - 1)
            {
                queensPos[y + 1] = new System.Drawing.Point(-1, y + 1);
            }

            var x = ++queensPos[y].X;

            if (x >= n)
            {
                y--;

                if (y < 0)
                    return solutions;

                continue;
            }

            var collide = false;

            for (int qPrevY = 0; qPrevY < y; qPrevY++)
            {
                var prevPos = queensPos[qPrevY];

                if (prevPos.X == x)
                {
                    collide = true;

                    break;
                }

                var diffX = prevPos.X - x;
                var diffY = prevPos.Y - y;

                if (Math.Abs(diffX) == Math.Abs(diffY)) //diagonal
                {
                    collide = true;

                    break;
                }
            }

            if (!collide)
            {
                y++;

                if (y == n)
                {
                    y -= 2;
                    var failed = false;

                    for (int printQ = 0; printQ < queensPos.Length; printQ++)
                    {
                        var qPos = queensPos[printQ];

                        if (qPos.X == -1)
                        {
                            failed = true;

                            break;
                        }
                    }

                    if (!failed)
                        solutions++;
                }
            }
        }

        return solutions;
    }
}
