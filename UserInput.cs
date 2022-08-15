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
        Console.Clear();

        var score = QuizManager.StartQuiz(operation, difficulty);
        Console.Clear();

        Console.Write($"You scored {score}! ");
        Console.WriteLine(GetCompliment(score, difficulty));
    }

    public static string GetCompliment(int score, Level difficulty) => score switch
    {
        10 => "Genius! Keep it up. " + (difficulty != Level.Hard ? "Why not try a harder level next time?" : ""),
        > 9 => "Splendid! You're almost there.",
        > 8 => "Brilliant! That's a really good score.",
        > 6 => "Awesome! You can do better.",
        > 4 => "Good. Practice harder!",
        _ => "Try to get a better score next time!",
    };
}
