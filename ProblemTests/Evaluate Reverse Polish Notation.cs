using Shouldly;

public class Evaluate_Reverse_Polish_Notation
{
    [Theory]
    [InlineData(new[] { "2", "1", "+", "3", "*" }, 9)]
    [InlineData(new[] { "4", "13", "5", "/", "+" }, 6)]
    public void Test(string[] nums, int expected)
    {
        var s = new Solution();
        var result = s.EvalRPN(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();

        foreach (var token in tokens)
        {
            switch (token)
            {
                case "+":
                    stack.Push(stack.Pop() + stack.Pop());

                    break;
                case "-":
                {
                    var op1 = stack.Pop();
                    var op2 = stack.Pop();
                    stack.Push(op2 - op1);

                    break;
                }
                case "/":
                {
                    var op1 = stack.Pop();
                    var op2 = stack.Pop();
                    stack.Push(op2 / op1);

                    break;
                }
                case "*":
                    stack.Push(stack.Pop() * stack.Pop());

                    break;
                default:
                    stack.Push(int.Parse(token));

                    break;
            }
        }

        return stack.Pop();
    }
}
