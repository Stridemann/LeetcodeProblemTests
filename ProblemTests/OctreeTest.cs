using SE;
using TestingTask.Octree;
using TestingTaskFramework;
using VRageMath;

namespace DefaultNamespace
{
	public class OctreeTest
	{
		private List<WorldObject> _allObj;

		[Fact]
		public void Test()
		{
			var size = 10000;
			var halfSize = size / 2;

			var octree = new MyOctree(size);
			var testPos = new Vector3D(-231.9013671875, 407.95263671875, -1744.992919921875);
			var worldObject = new WorldObject(testPos);
			octree.Add(worldObject);

			var min = new Vector3(-1990.2444, -1990.2444, -1990.2444);
			var max = new Vector3(4752.6084, 4752.6084, 4752.6084);
			var worldObjects = octree.Query(new BoundingBox(min, max));
		}

		[Fact]
		public void TestRandom()
		{
			var size = 10000;
			var halfSize = size / 2;
			var octree = new MyOctree(size);
			var rnd = new Random(0);
			_allObj = new List<WorldObject>();

			for (var i = 0; i < 1000; i++)
			{
				var testPos = new Vector3D(
					rnd.NextFloat(-halfSize, halfSize),
					rnd.NextFloat(-halfSize, halfSize),
					rnd.NextFloat(-halfSize, halfSize));
				var worldObject = new WorldObject(testPos);
				_allObj.Add(worldObject);
				octree.Add(worldObject);
			}

			var fine = 0;
			var notFine = 0;
			for (var i = 0; i < 1000; i++)
			{
				var fromPoints = BoundingBox.CreateFromPoints(
					new Vector3[4]
					{
						new(rnd.NextFloat(-halfSize, halfSize)), new(rnd.NextFloat(-halfSize, halfSize)),
						new(rnd.NextFloat(-halfSize, halfSize)), new(rnd.NextFloat(-halfSize, halfSize))
					});

				var testPos = new Vector3D(-231.9013671875, 407.95263671875, -1744.992919921875);
				var worldObjects = octree.Query(new BoundingBox(testPos, testPos + Vector3.One));



				var q1 = octree.Query(fromPoints);

				var q2 = new List<WorldObject>();
				QueryAll(fromPoints, q2);

				var excessive = q1.Except(q2).ToList();
				var missing = q2.Except(q1).ToList();

				if (excessive.Count > 0)
				{

				}
				if (q1.Count != q2.Count)
				{
					notFine++;
				}
				else
				{
					fine++;
				}
			}
		}

		private void QueryAll(BoundingBox box, List<WorldObject> resultList)
		{
			foreach (WorldObject worldObject in _allObj)
			{
				if (worldObject.BoundingBox.Contains(box) != ContainmentType.Disjoint)
					resultList.Add(worldObject);
			}
		}
	}
}

namespace TestingTaskFramework
{
	public class WorldObject
	{
		public WorldObject(Vector3D pos)
		{
			BoundingBox = new BoundingBox(pos - Vector3.One * 100, pos + Vector3.One * 100);
			Position = pos;
		}

		public BoundingBox BoundingBox { get; }
		public Vector3D Position { get; }
	}
}