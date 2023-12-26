namespace DefaultNamespace;

public class Time_Based_Key_Value_Store
{
	[Theory]
	[InlineData(new[] { 1, 2, 1 }, new[] { 1, 2, 1, 1, 2, 1 })]
	public void Test(int[] nums, int[] expected)
	{
		var s = new TimeMap();
		s.Set("foo", "bar", 1);
		s.Get("foo", 1);
		s.Get("foo", 3);
		s.Set("foo", "bar2", 4);
		s.Get("foo", 4);
		s.Get("foo", 5);
	}
}

public class TimeMap
{
	private readonly Dictionary<string, List<ValueTuple<string, int>>> _dictionary =
		new Dictionary<string, List<(string, int)>>();

	public void Set(
		string key,
		string value,
		int timestamp)
	{
		if (!_dictionary.TryGetValue(key, out var list))
		{
			list = new List<ValueTuple<string, int>>();
			_dictionary[key] = list;
		}

		list.Add(new(value, timestamp));
	}

	public string Get(string key, int timestamp)
	{
		if (!_dictionary.TryGetValue(key, out var value))
			return "";

		var left = 0;
		var right = value.Count;
		var result = "";

		while (left < right)
		{
			var mid = (left + right) / 2;
			if (value[mid].Item2 == timestamp)
			{
				result = value[mid].Item1;
				return result;
			}
			else if (value[mid].Item2 < timestamp)
			{
				left = mid + 1;
				result = value[mid].Item1;
			}
			else
			{
				right = mid;
			}

		}

		return result;
	}
}