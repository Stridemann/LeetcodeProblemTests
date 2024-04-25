public class AWS_Q2
{
    [Theory]
    [InlineData(new int[] { 2, 2, 3, 1 }, new int[] { 4, 2, 1, 0 })]
    public void Test(int[] input, int[] expected)
    {
        var result = Solution.findRequestsInQueue(input.ToList());
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public static List<int> findRequestsInQueue(List<int> wait)
    {
        var timeArray = new int[100001];
        var result = new List<int>(wait.Count);

        foreach (var time in wait)
        {
            timeArray[time]++;
        }

        var totalSegments = wait.Count;
        var waitPointer = 0;

        result.Add(totalSegments);

        for (int i = 1; i < 100001; i++)
        {
            while (waitPointer < wait.Count && wait[waitPointer] < i)
            {
                waitPointer++;
            }

            if (waitPointer >= wait.Count)
            {
                result.Add(0);
                return result;
            }

            var toRemove = wait[waitPointer];
            timeArray[toRemove]--;
            totalSegments--;

            if (timeArray[i] > 0)
            {
                totalSegments -= timeArray[i];
            }

            result.Add(totalSegments);

            if (totalSegments == 0)
            {
                return result;
            }
        }

        return result;
    }
}
