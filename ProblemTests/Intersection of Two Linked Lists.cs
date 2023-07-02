using System.Collections;

public class Intersection_of_Two_Linked_Lists
{
    [Theory]
    [InlineData("[5]", "[5]", "[0,1]")]
    public void Test(string headStr, string expected)
    {
        var s = new Solution();
        var head = ListNode.FromString(headStr);
        var result = s.RemoveNthFromEnd(head);
        result.PrintMe.ShouldBe(expected);
    }
}

public class Solution
{
    public ListNode GetIntersectionNode(ListNode? headA, ListNode? headB)
    {
        var dict = new Dictionary<int, List<ListNode>>();

        while (headA != null || headB != null)
        {
            if (headA != null)
            {
                if (!dict.TryGetValue(headA.val, out var list))
                {
                    list = new List<ListNode>();
                    dict.Add(headA.val, list);
                }
                else
                {
                    if (list.Contains(headA))
                        return headA;
                }

                list.Add(headA);
                headA = headA.next;
            }

            if (headB != null)
            {
                if (!dict.TryGetValue(headB.val, out var list))
                {
                    list = new List<ListNode>();
                    dict.Add(headB.val, list);
                }
                else
                {
                    if (list.Contains(headB))
                        return headB;
                }

                list.Add(headB);
                headB = headB.next;
            }
        }

        return null;
    }
}
