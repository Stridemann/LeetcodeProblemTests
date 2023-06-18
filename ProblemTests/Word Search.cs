using System.Collections;

public class Word_Search
{
    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void Test(char[][] head, string word, bool expected)
    {
        var s = new Solution();
        var result = s.Exist(head, word);
    }
}

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new char[][]
            {
                new[] { 'A', 'B', 'C', 'E' },
                new[] { 'S', 'F', 'C', 'S' },
                new[] { 'A', 'D', 'E', 'E' }
            },
            "SEE",
            true
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Solution
{
    private string _word;
    private char[][] _matrix;
    private int _width;
    private int _height;

    public bool Exist(char[][] board, string word)
    {
        _matrix = board;
        _word = word;
        _width = board[0].Length;
        _height = board.Length;
        var ch = word[0];

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                var cur = board[y][x];

                if (cur == ch)
                {
                    if (CheckWord(0, x, y))
                        return true;
                }
            }
        }

        return false;
    }

    private bool CheckWord(int charIndex, int x, int y)
    {
        var curVal = _matrix[y][x];

        if (curVal != _word[charIndex])
            return false;

        if (curVal == '+')
            return false;

        if (charIndex == _word.Length - 1)
            return true;

        _matrix[y][x] = '+';

        if (x > 0 && CheckWord(charIndex + 1, x - 1, y))
        {
            return true;
        }

        if (x < _width - 1 && CheckWord(charIndex + 1, x + 1, y))
        {
            return true;
        }

        if (y > 0 && CheckWord(charIndex + 1, x, y - 1))
        {
            return true;
        }

        if (y < _height - 1 && CheckWord(charIndex + 1, x, y + 1))
        {
            return true;
        }

        _matrix[y][x] = curVal;

        return false;
    }
}
