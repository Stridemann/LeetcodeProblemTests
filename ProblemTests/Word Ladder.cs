using System.Net;

public class Word_Ladder
{
    [Theory]
    [InlineData("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log" }, 0)]
    [InlineData("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" }, 5)]
    [InlineData("a", "c", new string[] { "a", "b", "c" }, 2)]
    public void Test(
        string beginWord,
        string endWord,
        string[] input,
        int expected)
    {
        var s = new Solution();
        var result = s.LadderLength(beginWord, endWord, input.ToList());
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private class WordNode
    {
        public string Word;
        public static int Iteration;
        public int CurIteration = -1;
        public int Counter;
        public bool IsFinalWord;
        public bool IsUsed;

        public WordNode(string word)
        {
            Word = word;
        }

        public static void NextIteration()
        {
            Iteration++;
        }

        public int Count()
        {
            if (CurIteration == Iteration)
            {
                Counter++;
            }
            else
            {
                CurIteration = Iteration;
                Counter = 1;
            }

            return Counter;
        }
    }

    private List<WordNode>?[,] _matrix;
    private int _minSteps = int.MaxValue;
    private int _wordLen;

    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        _wordLen = beginWord.Length;
        _matrix = new List<WordNode>[_wordLen, 'z' - 'a' + 1];

        var foundLast = false;

        foreach (var word in wordList)
        {
            var node = RegisterNode(word);

            if (word == endWord)
            {
                node.IsFinalWord = true;
                foundLast = true;
            }
        }

        if (!foundLast)
        {
            return 0;
        }

        Dfs(beginWord, 0);

        return _minSteps;
    }

    private WordNode RegisterNode(string word)
    {
        var wordNode = new WordNode(word);

        for (var i = 0; i < word.Length; i++)
        {
            var c = word[i];
            var index = c - 'a';
            ref List<WordNode>? list = ref _matrix[i, index];

            if (list == null)
            {
                list = new List<WordNode>();
            }

            list.Add(wordNode);
        }

        return wordNode;
    }

    private void Dfs(string word, int steps)
    {
        var nextNodes = new List<WordNode>();
        WordNode.NextIteration();

        for (var i = 0; i < word.Length; i++)
        {
            var c = word[i];

            var index = c - 'a';
            var list = _matrix[i, index];

            if (list != null)
            {
                foreach (var wordNode in list)
                {
                    var dist = wordNode.Count();

                    if (dist == _wordLen && wordNode.IsFinalWord)
                    {
                        _minSteps = Math.Min(_minSteps, steps + 1);
                    }
                    else if (dist == _wordLen - 1 && !wordNode.IsUsed)
                    {
                        nextNodes.Add(wordNode);
                    }
                }
            }
        }

        foreach (var nextNode in nextNodes)
        {
            nextNode.IsUsed = true;
            Dfs(nextNode.Word, steps + 1);
            nextNode.IsUsed = false;
        }
    }
}
