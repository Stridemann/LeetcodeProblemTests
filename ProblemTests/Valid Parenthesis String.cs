public class Valid_Parenthesis_String
{
    [Theory]
    [InlineData("()", true)]
    [InlineData("(*)", true)]
    [InlineData("(*))", true)]
    [InlineData("(", false)]
    [InlineData("*(", false)]
    [InlineData(")", false)]
    [InlineData(")*", false)]
    [InlineData("(((((*(()((((*((**(((()()*)()()()*((((**)())*)*)))))))(())(()))())((*()()(((()((()*(())*(()**)()(())", false)]
    [InlineData("((((()(()()()*()(((((*)()*(**(())))))(())()())(((())())())))))))(((((())*)))()))(()((*()*(*)))(*)()", true)]
    [InlineData("(((((*(((((*)*(**)))))))))))((((*)))))(((**(*)))(*)", true)]
    public void Test(string input, bool expected)
    {
        var s = new Solution();
        var result = s.CheckValidString(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public bool CheckValidString(string s)
    {
        var leftMin = 0;
        var leftMax = 0;

        foreach (var c in s)
        {
            switch (c)
            {
                case '(':
                    leftMax++;
                    leftMin++;

                    break;
                case ')':
                    leftMax--;
                    leftMin--;

                    break;
                case '*':
                    leftMax++;
                    leftMin--;

                    break;
            }

            if (leftMin < 0)
                leftMin = 0;

            if (leftMax < 0)
                return false;
        }

        return leftMin == 0;
    }
}
