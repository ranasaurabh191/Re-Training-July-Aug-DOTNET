using System;
using System.Collections.Generic;
using System.Linq;

class Player
{
    public int PlayerId { get; set; }
    public string PlayerName { get; set; }
    public int Level { get; set; }
    public int Wealth { get; set; }
    public int PvPRating { get; set; }
    public string Guild { get; set; }

    public override string ToString()
    {
        return $"Player ID : {PlayerId}\nPlayer    : {PlayerName}\nLevel     : {Level}\nWealth    : {Wealth}\nPvP Rating: {PvPRating}\nGuild     : {Guild}\n";
    }
}

class Program
{
    static Dictionary<int, Player> playerLookup = new Dictionary<int, Player>();

    static SortedDictionary<int, List<Player>> leaderboard =
        new SortedDictionary<int, List<Player>>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

    static SortedList<string, List<Player>> guildMembers =
        new SortedList<string, List<Player>>();

    static List<Player> playerInventory = new List<Player>();

    static void AddPlayer()
    {
        Player player = new Player();

        Console.Write("Player Id : ");
        player.PlayerId = int.Parse(Console.ReadLine());

        Console.Write("Player Name : ");
        player.PlayerName = Console.ReadLine();

        Console.Write("Level : ");
        player.Level = int.Parse(Console.ReadLine());

        Console.Write("Wealth : ");
        player.Wealth = int.Parse(Console.ReadLine());

        Console.Write("PvP Rating : ");
        player.PvPRating = int.Parse(Console.ReadLine());

        Console.Write("Guild : ");
        player.Guild = Console.ReadLine();

        playerLookup[player.PlayerId] = player;

        if (!leaderboard.ContainsKey(player.Level))
            leaderboard.Add(player.Level, new List<Player>());

        leaderboard[player.Level].Add(player);

        if (!guildMembers.ContainsKey(player.Guild))
            guildMembers.Add(player.Guild, new List<Player>());

        guildMembers[player.Guild].Add(player);

        guildMembers[player.Guild] = guildMembers[player.Guild]
            .OrderByDescending(x => x.Level)
            .ThenByDescending(x => x.PvPRating)
            .ToList();

        playerInventory.Add(player);

        Console.WriteLine("Player Added Successfully");
    }

    static void SearchPlayer()
    {
        Console.Write("Player Id : ");
        int id = int.Parse(Console.ReadLine());

        if (playerLookup.ContainsKey(id))
            Console.WriteLine(playerLookup[id]);
        else
            Console.WriteLine("Player Not Found");
    }

    static void UpdateLevel()
    {
        Console.Write("Player Id : ");
        int id = int.Parse(Console.ReadLine());

        if (!playerLookup.ContainsKey(id))
        {
            Console.WriteLine("Player Not Found");
            return;
        }

        Player player = playerLookup[id];

        leaderboard[player.Level].Remove(player);

        Console.Write("New Level : ");
        player.Level = int.Parse(Console.ReadLine());

        if (!leaderboard.ContainsKey(player.Level))
            leaderboard.Add(player.Level, new List<Player>());

        leaderboard[player.Level].Add(player);

        guildMembers[player.Guild] = guildMembers[player.Guild]
            .OrderByDescending(x => x.Level)
            .ThenByDescending(x => x.PvPRating)
            .ToList();

        Console.WriteLine("Level Updated");
    }

    static void DisplayLeaderboard()
    {
        Console.WriteLine("\n===== GLOBAL LEADERBOARD =====");

        foreach (var item in leaderboard)
        {
            Console.WriteLine("\nLevel : " + item.Key);

            foreach (var player in item.Value.OrderByDescending(x => x.PvPRating))
                Console.WriteLine(player);
        }
    }

    static void DisplayGuildMembers()
    {
        foreach (var item in guildMembers)
        {
            Console.WriteLine("\nGuild : " + item.Key);

            foreach (var player in item.Value)
                Console.WriteLine(player);
        }
    }

    static void DisplayInventoryOrder()
    {
        foreach (var player in playerInventory)
            Console.WriteLine(player);
    }

    static void MatchPlayers()
    {
        Console.Write("Enter PvP Rating : ");
        int rating = int.Parse(Console.ReadLine());

        var players = playerLookup.Values
            .Where(x => Math.Abs(x.PvPRating - rating) <= 100)
            .OrderByDescending(x => x.PvPRating);

        Console.WriteLine("\nMatched Players");

        foreach (var player in players)
            Console.WriteLine(player);
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== MULTI-PLAYER GAME SERVER =====");
            Console.WriteLine("1. Add Player");
            Console.WriteLine("2. Search Player");
            Console.WriteLine("3. Update Level");
            Console.WriteLine("4. Display Leaderboard");
            Console.WriteLine("5. Display Guild Members");
            Console.WriteLine("6. Display Inventory Order");
            Console.WriteLine("7. Match Players");
            Console.WriteLine("8. Exit");

            Console.Write("Enter Choice : ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddPlayer();
                    break;

                case 2:
                    SearchPlayer();
                    break;

                case 3:
                    UpdateLevel();
                    break;

                case 4:
                    DisplayLeaderboard();
                    break;

                case 5:
                    DisplayGuildMembers();
                    break;

                case 6:
                    DisplayInventoryOrder();
                    break;

                case 7:
                    MatchPlayers();
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