public class Design_Add_and_Search_Words_Data_Structure
{
    [Theory]
    [InlineData(new[] { -1, 2, 1, -4 }, 2)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.RemoveNthFromEnd(nums);
        result.ShouldBe(expected);
    }
}

public class WordDictionary
{
    private readonly TrieNode _root = new TrieNode();

    public void AddWord(string word)
    {
        var pCrawl = _root;

        foreach (var c in word)
        {
            ref TrieNode crPtr = ref pCrawl.Children[c - 'a'];

            if (crPtr == null)
            {
                crPtr = new TrieNode();
            }

            pCrawl = crPtr;
        }

        pCrawl.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        return Search(_root, word, 0);
    }

    private bool Search(TrieNode parent, string word, int index)
    {
        var ch = word[index];

        if (ch == '.')
        {
            if (index == word.Length - 1)
                return parent.Children.Any(x => x is { IsEndOfWord: true });

            return parent.Children.Any(x => x != null && Search(x, word, index + 1));
        }

        var curNode = parent.Children[ch - 'a'];

        if (curNode == null)
            return false;

        if (index == word.Length - 1)
        {
            return curNode.IsEndOfWord;
        }

        return Search(curNode, word, index + 1);
    }

    private class TrieNode
    {
        public readonly TrieNode?[] Children = new TrieNode?[26];
        public bool IsEndOfWord;
    }
}
