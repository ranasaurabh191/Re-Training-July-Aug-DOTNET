using System;
using System.Collections.Generic;
using System.Linq;

class Post
{
    public int PostId { get; set; }
    public string UserName { get; set; }
    public string Topic { get; set; }
    public string Hashtag { get; set; }
    public int Engagement { get; set; }
    public DateTime PostedTime { get; set; }

    public override string ToString()
    {
        return $"Post ID    : {PostId}\nUser       : {UserName}\nTopic      : {Topic}\nHashtag    : {Hashtag}\nEngagement : {Engagement}\nPosted Time: {PostedTime}\n";
    }
}

class Program
{
    static Dictionary<int, Post> postLookup = new Dictionary<int, Post>();

    static Dictionary<string, List<Post>> userPosts = new Dictionary<string, List<Post>>();

    static SortedDictionary<int, List<Post>> trendingPosts =
        new SortedDictionary<int, List<Post>>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

    static SortedList<string, List<Post>> topicPosts =
        new SortedList<string, List<Post>>();

    static List<Post> timeline = new List<Post>();

    static void AddPost()
    {
        Post post = new Post();

        Console.Write("Post Id : ");
        post.PostId = int.Parse(Console.ReadLine());

        Console.Write("User Name : ");
        post.UserName = Console.ReadLine();

        Console.Write("Topic : ");
        post.Topic = Console.ReadLine();

        Console.Write("Hashtag : ");
        post.Hashtag = Console.ReadLine();

        Console.Write("Engagement : ");
        post.Engagement = int.Parse(Console.ReadLine());

        post.PostedTime = DateTime.Now;

        postLookup[post.PostId] = post;

        if (!userPosts.ContainsKey(post.UserName))
            userPosts.Add(post.UserName, new List<Post>());

        userPosts[post.UserName].Add(post);

        if (!trendingPosts.ContainsKey(post.Engagement))
            trendingPosts.Add(post.Engagement, new List<Post>());

        trendingPosts[post.Engagement].Add(post);

        if (!topicPosts.ContainsKey(post.Topic))
            topicPosts.Add(post.Topic, new List<Post>());

        topicPosts[post.Topic].Add(post);

        topicPosts[post.Topic] = topicPosts[post.Topic]
            .OrderByDescending(x => x.Engagement)
            .ToList();

        timeline.Add(post);

        Console.WriteLine("Post Added Successfully");
    }

    static void SearchPost()
    {
        Console.Write("Post Id : ");
        int id = int.Parse(Console.ReadLine());

        if (postLookup.ContainsKey(id))
            Console.WriteLine(postLookup[id]);
        else
            Console.WriteLine("Post Not Found");
    }

    static void UpdateEngagement()
    {
        Console.Write("Post Id : ");
        int id = int.Parse(Console.ReadLine());

        if (!postLookup.ContainsKey(id))
        {
            Console.WriteLine("Post Not Found");
            return;
        }

        Post post = postLookup[id];

        trendingPosts[post.Engagement].Remove(post);

        Console.Write("New Engagement : ");
        post.Engagement = int.Parse(Console.ReadLine());

        if (!trendingPosts.ContainsKey(post.Engagement))
            trendingPosts.Add(post.Engagement, new List<Post>());

        trendingPosts[post.Engagement].Add(post);

        Console.WriteLine("Engagement Updated");
    }

    static void DisplayTrendingPosts()
    {
        foreach (var item in trendingPosts)
        {
            Console.WriteLine("\nEngagement : " + item.Key);

            foreach (var post in item.Value)
                Console.WriteLine(post);
        }
    }

    static void DisplayTopicWise()
    {
        foreach (var item in topicPosts)
        {
            Console.WriteLine("\nTopic : " + item.Key);

            foreach (var post in item.Value)
                Console.WriteLine(post);
        }
    }

    static void DisplayTimeline()
    {
        foreach (var post in timeline.OrderBy(x => x.PostedTime))
            Console.WriteLine(post);
    }

    static void DisplayInfluencers()
    {
        var influencers = userPosts
            .Select(x => new
            {
                User = x.Key,
                Total = x.Value.Sum(y => y.Engagement)
            })
            .OrderByDescending(x => x.Total);

        Console.WriteLine();

        foreach (var user in influencers)
        {
            Console.WriteLine($"{user.User} - {user.Total}");
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== SOCIAL MEDIA ANALYTICS PLATFORM =====");
            Console.WriteLine("1. Add Post");
            Console.WriteLine("2. Search Post");
            Console.WriteLine("3. Update Engagement");
            Console.WriteLine("4. Display Trending Posts");
            Console.WriteLine("5. Display Topic Wise");
            Console.WriteLine("6. Display Timeline");
            Console.WriteLine("7. Display Influencers");
            Console.WriteLine("8. Exit");

            Console.Write("Enter Choice : ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddPost();
                    break;
                case 2:
                    SearchPost();
                    break;
                case 3:
                    UpdateEngagement();
                    break;
                case 4:
                    DisplayTrendingPosts();
                    break;
                case 5:
                    DisplayTopicWise();
                    break;
                case 6:
                    DisplayTimeline();
                    break;
                case 7:
                    DisplayInfluencers();
                    break;
                case 8:
                    return;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}