using System.Collections.Specialized;

public class Task_Scheduler
{
    [Theory]
    [InlineData(new[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 2, 8)]
    [InlineData(new[] { 'A','A','A','B','B','B' }, 0, 6)]
    [InlineData(new[] { 'A','A','A','A','A','A','B','C','D','E','F','G' }, 2, 16)]
    public void Test(char[] tasks, int n, int expected)
    {
        var s = new Solution();
        var result = s.LeastInterval(tasks, n);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int LeastInterval(char[] tasks, int n)
    {
        var nextTimeNoCooldown = new int['Z' - 'A' + 1];
        var prQueue = new PriorityQueue<char, int>();
        
        foreach (var task in tasks)
        {
            ref int nextTime = ref nextTimeNoCooldown[task - 'A'];
            prQueue.Enqueue(task, nextTime);
            nextTime += n + 1;
        }

        var totalTime = 0;

        while (prQueue.TryDequeue(out var element, out int priority))
        {
            var cooldown = priority - totalTime;

            if (cooldown < 0)
                cooldown = 0;

            totalTime += cooldown;
            totalTime++;
        }

        return totalTime;
    }
}
