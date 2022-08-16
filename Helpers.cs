using ConsoleTableExt;

namespace MathGameChallenge;

static class Helpers
{
    public const string AddErrorMessage = @"An unknown error occurred while trying to save your game with a score of {0}.";

    public const string ReadErrorMessage = @"An unknown error occurred while trying to retrieve your previous game scores.";

    public const string NoLogsMessage = @"Looks like you haven't played any games yet. You'll see your previous game scores here.";

    private static readonly Dictionary<HeaderCharMapPositions, char> HeaderCharacterMap = new()
    {
        { HeaderCharMapPositions.TopLeft, '╒' },
        { HeaderCharMapPositions.TopCenter, '╤' },
        { HeaderCharMapPositions.TopRight, '╕' },
        { HeaderCharMapPositions.BottomLeft, '╞' },
        { HeaderCharMapPositions.BottomCenter, '╪' },
        { HeaderCharMapPositions.BottomRight, '╡' },
        { HeaderCharMapPositions.BorderTop, '═' },
        { HeaderCharMapPositions.BorderRight, '│' },
        { HeaderCharMapPositions.BorderBottom, '═' },
        { HeaderCharMapPositions.BorderLeft, '│' },
        { HeaderCharMapPositions.Divider, '│' },
    };

    public static void DisplayTable<T>(List<T> records, string emptyMessage) where T : class
    {
        if (records.Count == 0)
        {
            WriteUsingTypeWriter(emptyMessage);
            return;
        }

        ConsoleTableBuilder.From(records)
            .WithCharMapDefinition(CharMapDefinition.FramePipDefinition, HeaderCharacterMap)
            .ExportAndWriteLine();
    }

    public static void SaveScore(int score, Operation gameType, TimeSpan duration, Level level)
    {
        var db = new DbService();
        var historyRecord = new HistoryRecord()
        {
            Date = DateTime.Now,
            Score = score,
            GameType = gameType,
            Duration = TimeSpan.FromSeconds(Math.Round(duration.TotalSeconds)),
            Difficulty = level
        };

        db.Add(historyRecord);
    }

    public static void ShowHistory()
    {
        Console.WriteLine();
        WriteUsingTypeWriter("Your Statistics");

        var db = new DbService();
        db.Read();

        Console.WriteLine();
    }

    public static void CongratulateUser(int score)
    {
        var db = new DbService();

        if (!db.IsEmpty() && db.IsHighScore(score))
            WriteUsingTypeWriter("Congratulations! You just reached a new high score!");
    }

    public static void WriteUsingTypeWriter(string message, int delay = 30, int finalSleep = 100)
    {
        for(int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            Thread.Sleep(delay);
        }

        Console.WriteLine();
        Thread.Sleep(finalSleep);
    }

    public static void GreetUser()
    {
        try
        {
            using TextReader reader = new StreamReader("gameConfig.txt");

            string? name = reader.ReadLine();
            if (name is null) throw new InvalidOperationException();

            WriteUsingTypeWriter($"Welcome back, {name}!");
        }

        catch {
            ShowStoryLine();
            var name = Sharprompt.Prompt.Input<string>("Hey there, What's your name?");
            using TextWriter writer = new StreamWriter("gameConfig.txt");
            writer.WriteLine(name);
            Console.Clear();
            WriteUsingTypeWriter($"Welcome, {name}!");
        }
    }

    public static void ShowStoryLine()
    {
        WriteUsingTypeWriter("You are the student of the great Indian mathematician, Aryabhata.", finalSleep: 800);
        Console.WriteLine();
        WriteUsingTypeWriter("You learnt a ton of stuff from your master. Just before you have your farewell and bid goodbye to your friends, your mentor decides to put you to the test. ", finalSleep: 2000);
        Console.WriteLine();
        WriteUsingTypeWriter("You are given a magical stone slate, and you have to pass the math test to go home. Get ready for the wild ride...", finalSleep: 2000);
        Console.WriteLine();
        WriteUsingTypeWriter("Press any key to continue...", delay: 100);
        Console.ReadKey();
        Console.Clear();
    }
}
