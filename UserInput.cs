using Sharprompt;

namespace MathGameChallenge;

class UserInput
{
    public static void Start()
    {
        Helpers.GreetUser();
        Helpers.ShowHistory();

        Helpers.WriteUsingTypeWriter("Use arrow keys to navigate through the menu.");
        Console.WriteLine();
        var operation = Prompt.Select<Operation>("Pick the poison of your choice");
        var difficulty = Prompt.Select<Level>("Now, select your dose");
        Console.Clear();

        var startTime = DateTime.Now;
        var score = QuizManager.StartQuiz(operation, difficulty);
        var endTime = DateTime.Now;
        Console.Clear();

        Helpers.CongratulateUser(score);
        Helpers.WriteUsingTypeWriter($"You scored {score}! " + GetComplement(score, difficulty));
        Helpers.SaveScore(score, operation, endTime - startTime, difficulty);

        Helpers.WriteUsingTypeWriter("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        Start();
    }

    static string GetComplement(int score, Level difficulty) => score switch
    {
        10 => "Genius! Keep it up. " + (difficulty != Level.Hard ? "Why not try a harder level next time?" : ""),
        > 9 => "Splendid! You're almost there.",
        > 8 => "Brilliant! That's a really good score.",
        > 6 => "Awesome! You can do better.",
        > 4 => "Good. Practice harder!",
        _ => "Try to get a better score next time!",
    };
}