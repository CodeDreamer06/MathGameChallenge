using Sharprompt;

namespace MathGameChallenge;

class UserInput
{
    public static void Start()
    {
        Console.WriteLine("Welcome back, Abhinav!");
        Console.WriteLine("Use arrow keys to navigate through the menu.");

        var operation = Prompt.Select<Operation>("Pick the poison of your choice");
        var difficulty = Prompt.Select<Level>("Now, select your dose");
        Console.WriteLine(operation);
        Console.WriteLine(difficulty);
    }
}
