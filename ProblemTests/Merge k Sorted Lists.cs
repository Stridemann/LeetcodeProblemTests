using Shouldly;

public class Merge_k_Sorted_Lists
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 3, 4, 5 }, 5)]
    public void Test(int[] nums, int unique)
    {
        var s = new Solution();

        //var result = s.MergeKLists(
        //    new[]
        //    {
        //        new ListNode(1, new ListNode(2, new ListNode(4, new ListNode(6)))),
        //        new ListNode(1, new ListNode(2, new ListNode(4))),
        //        new ListNode(1, new ListNode(3, new ListNode(4, new ListNode(5))))
        //    }

        //s.MergeKLists(new ListNode[0]);
        //s.MergeKLists(new ListNode[1] { null });

        var result = s.MergeKLists(
            new[]
            {
                ListNode.GetList(1, 4, 5),
                null,
                ListNode.GetList(2, 3, 4),
                null,
                ListNode.GetList(3, 6)
            }
        );
    }
}

public class Solution
{
    public ListNode? MergeKLists(ListNode?[]? lists)
    {
        if (lists == null || lists.Length == 0)
            return null;
        var head = lists[0];
        var headShiftIndex = 0;

        for (var i = 1; i < lists.Length; i++)
        {
            if (lists[i] != null && (head == null || head.val > lists[i].val))
            {
                head = lists[i];
                headShiftIndex = i;
            }
        }

        if (head == null)
            return null;

        lists[headShiftIndex] = lists[headShiftIndex].next;

        var result = head;
        var maxLists = 0;

        for (int i = 0; i < lists.Length; i++)
        {
            if (lists[i] != null)
            {
                lists[maxLists] = lists[i];

                if (maxLists < i)
                {
                    lists[i] = null;
                }

                maxLists++;
            }
        }

        while (true)
        {
            ListNode min = null;
            var minIndex = 0;
            var done = true;

            for (var i = 0; i < maxLists; i++)
            {
                var cur = lists[i];
                if (min == null || min.val >= cur.val)
                {
                    min = cur;
                    minIndex = i;
                    done = false;
                }
            }

            if (done)
                break;

            lists[minIndex] = lists[minIndex].next;

            if (lists[minIndex] == null)
            {
                for (int i = minIndex; i < lists.Length - 1; i++)
                {
                    lists[i] = lists[i + 1];
                }

                maxLists--;
            }

            head.next = min;
            head = min;
        }

        head.next = null;

        return result;
    }
}
