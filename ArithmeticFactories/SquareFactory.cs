namespace MathGameChallenge;

class SquareFactory : IArithmeticFactory
{
    readonly Random Random = new();

    Level Difficulty { get; set; }

    public SquareFactory(Level level) => Difficulty = level;

    public Question GenerateQuestion()
    {
        int number = GenerateNumber();

        return new Question()
        {
            Title = $"{number}^2",
            Answer = number * number,
        };
    }

    int GenerateNumber() => Difficulty switch
    {
        Level.Easy => Random.Next(2, 30),
        Level.Medium => Random.Next(30, 100),
        Level.Hard => Random.Next(100, 200),
        _ => throw new NotSupportedException(),
    };
}
