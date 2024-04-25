public class AWS_Code1
{
    [Theory]
    [InlineData("[2,5,4,3,5]", "[5,4,3]")]
    [InlineData("[4,1,1,2,2]", "[4,1,1]")]
    [InlineData("[4,1]", "[4,1]")]
    [InlineData("[1,4]", "[1]")]
    [InlineData("[2]", "[2]")]
    public void Test(string headStr, string expected)
    {
        var s = new Solution();
        var head = SinglyLinkedListNode.FromString(headStr);
        var result = s.locateLongestList(head);
        result.PrintMe.ShouldBe(expected);
    }
}

public class Solution
{
    public SinglyLinkedListNode locateLongestList(SinglyLinkedListNode head)
    {
        SinglyLinkedListNode maxFoundStart = head;
        SinglyLinkedListNode maxFoundEnd = null;
        var maxFoundLength = 0;

        var curSegmentLength = 1;
        var curSegmentStart = head;
        SinglyLinkedListNode last = head;

        for (var iter = head; iter != null; iter = iter.next)
        {
            if (iter.next == null || iter.next.data > iter.data)
            {
                if (curSegmentLength > maxFoundLength)
                {
                    maxFoundStart = curSegmentStart;
                    maxFoundEnd = iter;
                    maxFoundLength = curSegmentLength;
                }

                curSegmentStart = iter.next;
                curSegmentLength = 0;
            }

            curSegmentLength++;
            last = iter;
        }

        maxFoundEnd ??= last;
        maxFoundEnd.next = null;

        return maxFoundStart;
    }
}
