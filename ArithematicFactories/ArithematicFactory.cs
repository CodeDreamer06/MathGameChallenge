namespace MathGameChallenge;

static class ArithematicFactory
{
    public static IArithematicFactory GetFactory(Operation operation, Level level) => operation switch
    {
        Operation.Addition => new AdditionFactory(level),
        Operation.Subtraction => throw new NotImplementedException(),
        Operation.Multiplication => throw new NotImplementedException(),
        Operation.Division => throw new NotImplementedException(),
        Operation.Square => throw new NotImplementedException(),
        _ => throw new NotSupportedException(),
    };
}
