public class Word_Search_II
{
    [Theory]
    [InlineData(new[] { -1, 2, 1, -4 }, 2)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.FindWords(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private readonly TrieNode _root = new TrieNode();
    private char[][] _board;
    private int _width;
    private int _height;
    private HashSet<string> _result;
    private int _maxWordlength;

    public IList<string> FindWords(char[][] board, string[] words)
    {
        _board = board;
        _width = board[0].Length;
        _height = board.Length;
        _result = new HashSet<string>();
        _maxWordlength = 0;

        foreach (var word in words)
        {
            Insert(word);

            if (_maxWordlength < word.Length)
            {
                _maxWordlength = word.Length;
            }
        }

        for (var y = 0; y < _height; y++)
        {
            for (var x = 0; x < _width; x++)
            {
                Check(_root, x, y, 0);
            }
        }

        return _result.ToList();
    }

    private void Check(
        TrieNode node,
        int x,
        int y,
        int depth)
    {
        if (x < 0 || y < 0 || x == _width || y == _height || depth > _maxWordlength)
        {
            return;
        }

        var c = _board[y][x];

        if (c == '.')
        {
            return;
        }

        var next = node.Children[c - 'a'];

        if (next == null)
        {
            return;
        }

        if (next.IsEndOfWord)
        {
            _result.Add(next.Word);
        }

        _board[y][x] = '.';
        Check(next, x + 1, y, depth + 1);
        Check(next, x, y + 1, depth + 1);
        Check(next, x - 1, y, depth + 1);
        Check(next, x, y - 1, depth + 1);
        _board[y][x] = c;
    }

    private void Insert(string word)
    {
        var pCrawl = _root;

        foreach (var c in word)
        {
            pCrawl = pCrawl.Children[c - 'a'] ??= new TrieNode();
        }

        pCrawl.IsEndOfWord = true;
        pCrawl.Word = word;
    }

    private class TrieNode
    {
        public readonly TrieNode?[] Children = new TrieNode?[26];
        public bool IsEndOfWord;
        public string Word;
    }
}
