public class LRUCache
{
    private struct LruEntry
    {
        public readonly int Key;
        public readonly bool HasValue;
        public int Value;
        public int Lru;

        public LruEntry(int key, int value, int lru) : this()
        {
            Key = key;
            Value = value;
            Lru = lru;
            HasValue = true;
        }
    }

    private readonly LruEntry[] _cache;
    private int _lru;

    public LRUCache(int capacity)
    {
        _cache = new LruEntry[capacity];
    }

    public int Get(int key)
    {
        for (var i = 0; i < _cache.Length; i++)
        {
            ref LruEntry val = ref _cache[i];

            if (val.HasValue && val.Key == key)
            {
                val.Lru = _lru++;

                return val.Value;
            }
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        var minLru = int.MaxValue;
        var minLruIndex = -1;
        var emptyIndex = -1;

        for (var i = 0; i < _cache.Length; i++)
        {
            ref LruEntry val = ref _cache[i];

            if (!val.HasValue)
            {
                emptyIndex = i;
                continue;
            }

            if (val.Key == key)
            {
                val.Value = value;
                val.Lru = _lru++;

                return;
            }

            if (minLru > val.Lru)
            {
                minLru = val.Lru;
                minLruIndex = i;
            }
        }

        if (emptyIndex != -1)
        {
            _cache[emptyIndex]= new LruEntry(key, value, _lru++);

            return;
        }


        ref LruEntry val2 = ref _cache[minLruIndex];
        val2 = new LruEntry(key, value, _lru++);
    }
}
