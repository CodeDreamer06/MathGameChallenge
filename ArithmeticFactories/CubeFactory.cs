namespace MathGameChallenge;

class CubeFactory : IArithmeticFactory
{
    readonly Random Random = new();

    Level Difficulty { get; set; }

    public CubeFactory(Level level) => Difficulty = level;

    public Question GenerateQuestion()
    {
        int number = GenerateNumber();

        return new Question()
        {
            Title = $"{number}^3",
            Answer = number * number * number,
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
