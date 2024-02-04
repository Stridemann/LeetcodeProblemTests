public class Design_Twitter
{
    [Fact]
    public void Test()
    {
        Twitter twitter = new Twitter();
        twitter.PostTweet(1, 5); // User 1 posts a new tweet (id = 5).
        var tw = twitter.GetNewsFeed(1); // User 1's news feed should return a list with 1 tweet id -> [5]. return [5]
        twitter.Follow(1, 2); // User 1 follows user 2.
        twitter.PostTweet(2, 6); // User 2 posts a new tweet (id = 6).

        twitter.GetNewsFeed(
            1); // User 1's news feed should return a list with 2 tweet ids -> [6, 5]. Tweet id 6 should precede tweet id 5 because it is posted after tweet id 5.
        twitter.Unfollow(1, 2); // User 1 unfollows user 2.
        twitter.GetNewsFeed(1); // User 1's news feed should return a list with 1 tweet id -> [5], since user 1 is no longer following user 2.
    }

    [Fact]
    public void Test2()
    {
        Twitter twitter = new Twitter();
        twitter.PostTweet(1, 5); // User 1 posts a new tweet (id = 5).
        twitter.PostTweet(1, 3); // User 1 posts a new tweet (id = 5).
        var tw = twitter.GetNewsFeed(1); // User 1's news feed should return a list with 1 tweet id -> [5]. return [5]
    }

    [Fact]
    public void Test3()
    {
        Twitter twitter = new Twitter();
        twitter.PostTweet(1, 5);
        twitter.PostTweet(1, 3);
        twitter.PostTweet(1, 101);
        twitter.PostTweet(1, 13);
        twitter.PostTweet(1, 10);
        twitter.PostTweet(1, 2);
        twitter.PostTweet(1, 94);
        twitter.PostTweet(1, 505);
        twitter.PostTweet(1, 333);
        twitter.PostTweet(1, 22);
        twitter.PostTweet(1, 11);
        twitter.PostTweet(1, 1);
        var tw = twitter.GetNewsFeed(1); // User 1's news feed should return a list with 1 tweet id -> [5]. return [5]
    }
}

public class Twitter
{
    private readonly Dictionary<int, List<ValueTuple<int, int>>> _usersTweets = new Dictionary<int, List<(int, int)>>();
    private readonly Dictionary<int, HashSet<int>> _follows = new Dictionary<int, HashSet<int>>();
    private int _uniqIdCounter;
    public void PostTweet(int userId, int tweetId)
    {
        if (!_usersTweets.TryGetValue(userId, out var twList))
        {
            twList = new List<ValueTuple<int, int>>();
            _usersTweets[userId] = twList;
        }

        twList.Add(new ValueTuple<int, int>(tweetId, _uniqIdCounter++));
    }

    public IList<int> GetNewsFeed(int userId)
    {
        var result = new List<int>();
        var pq = new PriorityQueue<int, int>();

        if (_usersTweets.TryGetValue(userId, out var posts))
        {
            foreach (var post in posts)
            {
                pq.Enqueue(post.Item1, -post.Item2);
            }
        }

        if (_follows.TryGetValue(userId, out var twList))
        {
            foreach (var user in twList)
            {
                if (_usersTweets.TryGetValue(user, out posts))
                {
                    foreach (var post in posts)
                    {
                        pq.Enqueue(post.Item1, -post.Item2);
                    }
                }
            }
        }

        while (pq.TryDequeue(out var item, out _))
        {
            if (result.Count == 10)
                break;
            result.Add(item);
        }

        return result;
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!_follows.TryGetValue(followerId, out var twList))
        {
            twList = new HashSet<int>();
            _follows[followerId] = twList;
        }

        twList.Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (!_follows.TryGetValue(followerId, out var twList))
        {
            return;
        }

        twList.Remove(followeeId);
    }
}
