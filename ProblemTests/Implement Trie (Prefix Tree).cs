public class Implement_Trie__Prefix_Tree_
{
    [Theory]
    [InlineData(new[] { -1, 2, 1, -4 }, 2)]
    public void Test(int[] nums, int expected)
    {
        var s = new Trie();
        var result = s.RemoveNthFromEnd(nums);
        result.ShouldBe(expected);
    }
}

public class Trie
{
    private readonly TrieNode _root = new TrieNode();

    public void Insert(string key)
    {
        var pCrawl = _root;

        foreach (var c in key)
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
        var pCrawl = _root;

        foreach (var c in word)
        {
            pCrawl = pCrawl.Children[c - 'a'];

            if (pCrawl == null)
            {
                return false;
            }
        }

        return pCrawl.IsEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        var pCrawl = _root;

        foreach (var c in prefix)
        {
            pCrawl = pCrawl.Children[c - 'a'];

            if (pCrawl == null)
            {
                return false;
            }
        }

        return true;
    }

    private class TrieNode
    {
        public readonly TrieNode?[] Children = new TrieNode?[26];
        public bool IsEndOfWord;
    }
}
