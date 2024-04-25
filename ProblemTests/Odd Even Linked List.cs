public class Odd_Even_Linked_List
{
    [Theory]
    [InlineData("[1,2,3,4,5]", "[1,3,5,2,4]")]
    [InlineData("[2,1,3,5,6,4,7]", "[2,3,6,7,1,5,4]")]
    [InlineData("[1,2,3,4,5,6,7,8]", "[1,3,5,7,2,4,6,8]")]
    public void Test(string headStr, string expected)
    {
        var s = new Solution();
        var head = ListNode.FromString(headStr);
        var result = s.OddEvenList(head);
        result.PrintMe.ShouldBe(expected);
    }
}

public class Solution
{
    public ListNode OddEvenList(ListNode head)
    {
        if (head == null)
            return null;

        if (head.next?.next == null)
            return head;

        ListNode curIter = head;
        ListNode endHeadEven = null;
        ListNode endEvenIter = null;

        while (true)
        {
            var nextEven = curIter.next;

            if (nextEven == null)
            {
                curIter.next = endHeadEven;
                endEvenIter.next = null;

                break;
            }

            endHeadEven ??= nextEven;
            var nextOdd = nextEven.next;

            if (nextOdd == null)
            {
                curIter.next = endHeadEven;
                endEvenIter.next = nextEven;
                nextEven.next = null;

                break;
            }

            curIter.next = nextOdd;

            if (endEvenIter != null)
            {
                endEvenIter.next = nextEven;
            }

            endEvenIter = nextEven;
            curIter = nextOdd;
        }

        return head;
    }
}
