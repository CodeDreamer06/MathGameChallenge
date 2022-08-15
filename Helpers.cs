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

    public static void SaveScore(int score, Operation gameType)
    {
        var db = new DbService();
        var historyRecord = new HistoryRecord()
        {
            Date = DateTime.Now,
            Score = score,
            GameType = gameType,
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

    public static void ShowHighScoreMessage(int score)
    {
        var db = new DbService();

        if (db.IsHighScore(score))
            WriteUsingTypeWriter("Congratulations! You just reached a new high score!");
    }

    public static void WriteUsingTypeWriter(string message)
    {
        for(int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            Thread.Sleep(30);
        }

        Console.WriteLine();
        Thread.Sleep(100);
    }
}
