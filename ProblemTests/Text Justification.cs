using System.Text;
using Shouldly;

public class Text_Justification
{
    [Theory]
    [InlineData(
        new[] { "Thi", "is", "an", "example", "of", "text", "justification." },
        16,
        new[] { "Thi     is    an", "example  of text", "justification.  " })]
    [InlineData(
        new[] { "What", "must", "be", "acknowledgment", "shall", "be" },
        16,
        new[] { "What   must   be", "acknowledgment  ", "shall be        " })]
    [InlineData(
        new[]
        {
            "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything",
            "else", "we", "do"
        },
        20,
        new[]
        {
            "Science  is  what we",
            "understand      well",
            "enough to explain to",
            "a  computer.  Art is",
            "everything  else  we",
            "do                  "
        })]
    public void Test(string[] words, int maxWidth, string[] expected)
    {
        var s = new Solution();
        var result = s.FullJustify(words, maxWidth);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        var res = new List<string>();

        for (int q = 0; q < words.Length; )
        {
            var p = q;
            var sw = maxWidth;

            for (; q < words.Length && sw >= words[q].Length; )
            {
                sw -= words[q++].Length + 1;
            }
            
            int sp = (q >= words.Length || q - p == 1) ? q - p - 1 : sw + q - p;
            res.Add(words[q - 1] + new string(' ', sw + q - p - sp));

            for (int i = q - 2; p <= i; sp -= sp / (i - p + 1), --i)
            {
                res[^1] = words[i] + new string(' ', sp / (i - p + 1)) + res[^1];
            }
        }

        return res;
    }

    //public IList<string> FullJustify(string[] words, int maxWidth)
    //{
    //    var result = new List<string>();
    //    var sb = new StringBuilder(maxWidth);

    //    var startInsertWordInd = 0;
    //    var wordsSum = words[0].Length;

    //    for (int i = 1; i < words.Length; i++)
    //    {
    //        var wordsCount = i - startInsertWordInd;
    //        var splitsCount = wordsCount;
    //        var curWord = words[i];
    //        var newLen = wordsSum + curWord.Length + splitsCount;

    //        if (newLen <= maxWidth)
    //        {
    //            wordsSum += curWord.Length;

    //            continue;
    //        }

    //        if (wordsCount == 1)
    //        {
    //            sb.Append(words[startInsertWordInd]);

    //            if (sb.Length < maxWidth)
    //                sb.Append(' ', maxWidth - sb.Length);
    //        }
    //        else
    //        {
    //            var wordsLeft = wordsCount - 1;
    //            var spacesInsertLeft = maxWidth - wordsSum;

    //            for (int j = startInsertWordInd; j < i; j++)
    //            {
    //                sb.Append(words[j]);

    //                var endInd = i - 1;

    //                if (j < endInd || endInd == startInsertWordInd)
    //                {
    //                    var curSpace = (int)Math.Ceiling((float)spacesInsertLeft / wordsLeft);
    //                    spacesInsertLeft -= curSpace;
    //                    wordsLeft--;

    //                    if (curSpace > 0)
    //                        sb.Append(' ', curSpace);
    //                }
    //            }
    //        }

    //        startInsertWordInd = i;
    //        wordsSum = curWord.Length;
    //        result.Add(sb.ToString());
    //        sb.Clear();
    //    }

    //    for (int i = startInsertWordInd; i < words.Length; i++)
    //    {
    //        if (i > startInsertWordInd)
    //            sb.Append(' ');
    //        sb.Append(words[i]);
    //    }

    //    if (sb.Length < maxWidth)
    //        sb.Append(' ', maxWidth - sb.Length);

    //    result.Add(sb.ToString());

    //    return result;
    //}
}
