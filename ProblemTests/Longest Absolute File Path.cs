using Shouldly;
using Xunit;

public class Longest_Absolute_File_Path
{
	[Theory]
	[InlineData("dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext", 20)]
	[InlineData("a.tar.gz", 8)]
	[InlineData("file1.txt\n" +
	            "file2.txt\n" +
	            "longfile.txt", 12)]
	[InlineData("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext", 32)]
	[InlineData("a", 0)]
	public void Test(string a, int expected)
	{
		var s = new Solution();
		s.LengthLongestPath(a).ShouldBe(expected);
	}
}

public class Solution
{
	public int LengthLongestPath(string input)
	{
		var lines = input.Split("\n");
		var lengths = new List<int>();
		var maxPathLen = 0;

		foreach (var line in lines)
		{
			var nameStart = 0;
			while (line[nameStart] == '\t')
			{
				nameStart ++;
			}

			var depth = nameStart;
			var nameLen = line.Length - nameStart;
			var isFile = nameLen > 4 && line.IndexOf('.') != -1;

			if (isFile)
			{
				var curLen = depth + nameLen;

				if (depth > 0)
					curLen += lengths[depth - 1];

				if (maxPathLen < curLen)
				{
					maxPathLen = curLen;
				}
			}
			else
			{
				if (depth - 1 >= 0)
				{
					nameLen += lengths[depth - 1];
				}

			
				if (depth >= lengths.Count)
				{
					lengths.Add(nameLen);
				}
				else
				{
					lengths[depth] = nameLen;
				}
			}
		}

		return maxPathLen;
	}
}