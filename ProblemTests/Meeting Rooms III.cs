﻿using System.Text;

public class Meeting_Rooms_III
{
    [Theory]
    [InlineData("[[0,10],[1,5],[2,7],[3,4]]", 2, 0)]
    [InlineData("[[1,20],[2,10],[3,5],[4,9],[6,8]]", 3, 1)]
    [InlineData("[[0,1]]", 100, 0)]
    [InlineData("[[19,20],[14,15],[13,14],[11,20]]", 4, 1)]
    [InlineData("[[48,49],[22,30],[13,31],[31,46],[37,46],[32,36],[25,36],[49,50],[24,34],[6,41]]", 4, 0)]
    [InlineData(
        100,
        15)]
    public void Test(string arrStr, int n, int expected)
    {
        var arr = ArrayUtils.ArrayFromStr(arrStr);
        var s = new Solution();
        s.MostBooked(n, arr).ShouldBe(expected);
    }
}

public class Solution
{
    public int MostBooked(int n, int[][] meetings)
    {
        checked
        {
            Array.Sort(meetings, (x, y) => x[0].CompareTo(y[0]));

            var roomsEndTimePq = new PriorityQueue<int, long>();
            var freeRoomsPq = new PriorityQueue<int, long>();
            var meetingsCnt = new int[n];

            for (int i = 0; i < n; i++)
            {
                freeRoomsPq.Enqueue(i, i);
            }

            for (int mi = 0; mi < meetings.Length; mi++)
            {
                var meeting = meetings[mi];
                var meetingStart = meeting[0];
                var meetingEnd = meeting[1];

                while (roomsEndTimePq.TryPeek(out _, out var testTime) && testTime <= meetingStart)
                {
                    roomsEndTimePq.TryDequeue(out var room, out _);
                    freeRoomsPq.Enqueue(room, room);
                }

                if (freeRoomsPq.TryDequeue(out var roomNb, out _))
                {
                    roomsEndTimePq.Enqueue(roomNb, meetingEnd);
                    meetingsCnt[roomNb]++;
                }
                else if (roomsEndTimePq.TryDequeue(out var roomNb2, out var time))
                {
                    long meetingDuration = meetingEnd - meetingStart;
                    roomsEndTimePq.Enqueue(roomNb2, time + meetingDuration);
                    meetingsCnt[roomNb2]++;
                }
                else
                {
                    throw new Exception();
                }
            }

            long maxVal = -1;
            int index = -1;

            for (int i = 0; i < meetingsCnt.Length; i++)
            {
                var room = meetingsCnt[i];

                if (room > maxVal)
                {
                    maxVal = room;
                    index = i;
                }
            }

            return index;
        }
    }
}