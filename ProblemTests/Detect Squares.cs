public class Detect_Squares
{
	[Fact]
	public void Test_11_10_1()
	{
		var ds = new DetectSquares();
		ds.Add(new[] { 3, 10 });
		ds.Add(new[] { 11, 2 });
		ds.Add(new[] { 3, 2 });
		ds.Count(new[] { 11, 10 }).ShouldBe(1);
	}

	[Fact]
	public void Test_14_8()
	{
		var ds = new DetectSquares();
		ds.Add(new[] { 3, 10 });
		ds.Add(new[] { 11, 2 });
		ds.Add(new[] { 3, 2 });
		ds.Count(new[] { 14, 8 }).ShouldBe(0);
	}

	[Fact]
	public void Test_11_10_2()
	{
		var ds = new DetectSquares();
		ds.Add(new[] { 3, 10 });
		ds.Add(new[] { 11, 2 });
		ds.Add(new[] { 3, 2 });
		ds.Add(new[] { 11, 2 });
		ds.Count(new[] { 11, 10 }).ShouldBe(2);
	}
}

public class DetectSquares
{
	private const int SIZE = 1001;
	private readonly Dictionary<int, int[]> _rows = new Dictionary<int, int[]>();
	private readonly Dictionary<int, int[]> _cols = new Dictionary<int, int[]>();

	public void Add(int[] point)
	{
		var x = point[0];
		var y = point[1];

		if (!_rows.TryGetValue(y, out var yRow))
		{
			yRow = new int[SIZE];
			_rows[y] = yRow;
		}

		if (!_cols.TryGetValue(x, out var xCol))
		{
			xCol = new int[SIZE];
			_cols[x] = xCol;
		}

		yRow[x]++;
		xCol[y]++;
	}

	public int Count(int[] point)
	{
		var x = point[0];
		var y = point[1];
		if (!_rows.TryGetValue(y, out var yRow))
		{
			return 0;
		}

		if (!_cols.TryGetValue(x, out var xCol))
		{
			return 0;
		}

		var result = 0;

		result += CountDir(
			x,
			y,
			1,
			1,
			yRow,
			xCol);

		result += CountDir(
			x,
			y,
			-1,
			1,
			yRow,
			xCol);


		result += CountDir(
			x,
			y,
			1,
			-1,
			yRow,
			xCol);

		result += CountDir(
			x,
			y,
			-1,
			-1,
			yRow,
			xCol);

		return result;
	}

	private int CountDir(
		int startX,
		int startY,
		int dirX,
		int dirY,
		int[] yRow,
		int[] xCol)
	{
		var result = 0;
		for (int offs = 0; offs < SIZE; offs++)
		{
			var finalX = startX + offs * dirX;
			var finalY = startY + offs * dirY;
			if (finalX < 0 || finalY < 0 || finalX >= SIZE || finalY >= SIZE)
			{
				return result;
			}

			if (!_rows.TryGetValue(finalY, out var finalYRow))
			{
				continue;
			}

			var finalCell = finalYRow[finalX];

			if (finalCell > 0)
			{
				var xCell = xCol[finalY];
				if (xCell == 0)
					continue;
				var yCell = yRow[finalX];
				if (yCell == 0)
					continue;

				result += finalCell;
				result += xCell - 1;
				result += yCell - 1;
			}
		}

		return result;
	}
}