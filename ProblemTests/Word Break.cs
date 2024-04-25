public class Word_Break
{
    [Theory]
    [InlineData("leetcode", new string[] { "leet", "code" }, true)]
    //[InlineData("leetcode", new string[] { "leet", "cod", "code" }, true)]
    [InlineData("applepenapple", new string[] { "apple", "pen" }, true)]
    [InlineData("catsandog", new string[] { "cats", "dog", "sand", "and", "cat" }, false)]
    public void Test(string input, string[] wordsDict, bool expected)
    {
        var s = new Solution();
        var result = s.WordBreak(input, wordsDict.ToList());
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private string _s;
    private TieNode _tree;

    public bool WordBreak(string s, IList<string> wordDict)
    {
        _s = s;
        _tree = new TieNode();

        foreach (var s1 in wordDict)
        {
            _tree.Register(s1, 0);
        }

        var initialNode = _tree.GetNode(s[0]);

        if (initialNode == null)
            return false;

        return Bt(0, initialNode);
    }

    private bool Bt(int index, TieNode? node)
    {
        var nextIndex = index + 1;

        if (nextIndex == _s.Length)
            return node?.IsEndOfWord ?? false;

        if (node == null)
            return false;

        if (node.IsEndOfWord)
        {
            var nextFromStart = _tree.GetNode(_s[nextIndex]);

            if (Bt(nextIndex, nextFromStart))
                return true;
        }

        var nextNode = node.GetNode(_s[nextIndex]);

        return Bt(nextIndex, nextNode);
    }

    private class TieNode
    {
        public readonly TieNode?[] ChildNodes = new TieNode['z' - 'a' + 1];
        public bool IsEndOfWord;

        public void Register(string word, int index)
        {
            if (index == word.Length)
            {
                IsEndOfWord = true;

                return;
            }

            var childIndex = word[index] - 'a';
            ref TieNode? node = ref ChildNodes[childIndex];

            if (node == null)
                node = new TieNode();
            node.Register(word, index + 1);
        }

        public TieNode? GetNode(char ch)
        {
            return ChildNodes[ch - 'a'];
        }
    }
}
