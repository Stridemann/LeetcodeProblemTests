public class Words_Within_Two_Edits_of_Dictionary
{
    [Theory]
    [InlineData(
        new string[] { "word", "note", "ants", "wood" },
        new string[] { "wood", "joke", "moat" },
        new string[] { "word", "note", "wood" })]
    [InlineData(
        new string[] { "tsl", "sri", "yyy", "rbc", "dda", "qus", "hyb", "ilu", "ahd" },
        new string[] { "uyj", "bug", "dba", "xbe", "blu", "wuo", "tsf", "tga" },
        new string[] { "tsl", "yyy", "rbc", "dda", "qus", "hyb", "ilu" })]
    [InlineData(
        new string[] { "yes" },
        new string[] { "not" },
        new string[] { })]
    [InlineData(
        new string[] { "t", "i", "m", "i", "p", "s" },
        new string[] { "w", "j", "b", "p", "u", "b", "u", "i", "h", "m" },
        new string[] { "t", "i", "m", "i", "p", "s" })]
    public void Test(
        string[] queries,
        string[] dictionary,
        string[] expected)
    {
        var s = new Solution();
        var result = s.TwoEditWords(queries, dictionary);
        result.ShouldBe(expected, Case.Insensitive);
    }
}

public class Solution
{
    private class WordNode
    {
        public static int Iteration;
        public int CurIteration = -1;
        public int Counter;

        public static void NextIteration()
        {
            Iteration++;
        }

        public int Increment()
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
    private int _wordLen;

    public IList<string> TwoEditWords(string[] queries, string[] dictionary)
    {
        _wordLen = queries[0].Length;

        if (_wordLen <= 2)
        {
            return queries;
        }

        _matrix = new List<WordNode>[_wordLen, 'z' - 'a' + 1];
        var result = new List<string>();

        foreach (var word in dictionary)
        {
            RegisterNode(word);
        }

        foreach (var query in queries)
        {
            WordNode.NextIteration();

            for (var i = 0; i < query.Length; i++)
            {
                var c = query[i];

                var index = c - 'a';
                var list = _matrix[i, index];
                var added = false;

                if (list != null)
                {
                    foreach (var wordNode in list)
                    {
                        var dist = wordNode.Increment();

                        if (dist >= _wordLen - 2)
                        {
                            added = true;
                            result.Add(query);

                            break;
                        }
                    }

                    if (added)
                    {
                        break;
                    }
                }
            }
        }

        return result;
    }

    private WordNode RegisterNode(string word)
    {
        var wordNode = new WordNode();

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
}
