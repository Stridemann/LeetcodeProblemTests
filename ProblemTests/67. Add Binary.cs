using System.Text;
using Newtonsoft.Json.Linq;
using Shouldly;

public class Add_Binary
{
    [Theory]
    [InlineData("11", "1", "100")]
    [InlineData("1010", "1011", "10101")]
    [InlineData("1111", "1111", "11110")]
    public void Test(string a, string b, string expected)
    {
        var s = new Solution();
        s.AddBinary(a, b).ShouldBe(expected);
    }
}

public class Solution
{
    public string AddBinary(string a, string b)
    {
        var reminder = 0;
        string bigString;
        string smallString;

        if (a.Length > b.Length)
        {
            bigString = a;
            smallString = b;
        }
        else
        {
            bigString = b;
            smallString = a;
        }

        var sb = new StringBuilder(bigString.Length);

        for (int i = 0; i < bigString.Length; i++)
        {
            var ia = bigString[bigString.Length - i - 1] - '0';
            int ib = i < smallString.Length ? smallString[smallString.Length - i - 1] - '0' : 0;
            
            var sum = ia + ib + reminder;
            reminder = 0;

            switch (sum)
            {
                case 0:
                    sb.Insert(0, '0');

                    break;
                case 1:
                    sb.Insert(0, '1');

                    break;
                case 2:
                    sb.Insert(0, '0');
                    reminder = 1;

                    break;
                case 3:
                    sb.Insert(0, '1');
                    reminder = 1;

                    break;
            }
        }

        if (reminder > 0)
            sb.Insert(0, '1');

        return sb.ToString();
    }
}
