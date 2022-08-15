namespace MathGameChallenge;

class DbService
{
    private readonly HistoryContext _db;

    public DbService() => _db = new HistoryContext();

    public void Add(HistoryRecord log)
    {
        try
        {
            _db.History.Add(log);
            _db.SaveChanges();
        }

        catch
        {
            Helpers.WriteUsingTypeWriter(string.Format(Helpers.AddErrorMessage, log.Score));
        }
    }

    public void Read()
    {
        try
        {
            var logs = _db.History
                .OrderBy(log => log.Date)
                .ToList();

            var logsClone = logs.ConvertAll(log => log.GetDeepClone());

            for (int i = 0; i < logsClone.Count; i++) logsClone[i].Id = i + 1;

            Helpers.DisplayTable(logsClone, Helpers.NoLogsMessage);
        }

        catch
        {
            Helpers.WriteUsingTypeWriter(Helpers.ReadErrorMessage);
        }
    }

    public bool IsHighScore(int score) => score > _db.History.Max(log => log.Score);

    public bool IsEmpty() => _db.History.Count() == 0;
}