using System.Collections;
using Shouldly;

public class Remove_Nth_Node_From_End_of_List
{
    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void Test(ListNode head, int nth)
    {
        var nodeList = new List<int>();
        var iter = head;

        while (iter != null)
        {
            nodeList.Add(iter.val);
            iter = iter.next;
        }

        var s = new Solution();
        var result = s.RemoveNthFromEnd(head, nth);

        nodeList.RemoveAt(nodeList.Count - nth);

        var cur = result;

        for (int i = 0; i < nodeList.Count; i++)
        {
            cur.val.ShouldBe(nodeList[i]);

            if (i == nodeList.Count - 1)
                cur.next.ShouldBeNull();
            else
                cur = cur.next;
        }
    }
}

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            ListNode.GetList(
                1,
                2,
                3,
                4,
                5),
            2
        };

        yield return new object[]
        {
            ListNode.GetList(
                1,
                2),
            1
        };

        yield return new object[]
        {
            ListNode.GetList(
                1,
                2),
            2
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Solution
{
    public ListNode? RemoveNthFromEnd(ListNode? head, int nth)
    {
        nth--;

        if (head?.next == null)
            return null;
        var start = head;
        var cnt = 0;
        ListNode? target = null;

        while (head != null)
        {
            if (target == null)
            {
                target = head;
            }
            else if (cnt > nth + 1)
            {
                target = target.next;
            }

            head = head.next;
            cnt++;
        }

        if (cnt == nth + 1)
        {
            return start.next;
        }

        if (target != null && target.next != null)
            target.next = target.next.next;

        return start;
    }
}
