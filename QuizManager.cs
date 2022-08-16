using Sharprompt;

namespace MathGameChallenge;

class QuizManager
{
    public static int StartQuiz(Operation operation, Level level)
    {
        var factory = ArithematicFactory.GetFactory(operation, level)!;
        int score = 0;

        for (int i = 0; i < 10; i++)
        {
            var question = factory.GenerateQuestion();
            var userInput = Prompt.Input<int>(question.Title);

            if (userInput == question.Answer) score++;
        }

        return score;
    }

    public static int StartFreestyleSurvival()
    {
        int hearts = 3;
        int score = 0;

        while (hearts > 0)
        {
            Console.Clear();            
            Console.WriteLine($"Lives: {hearts}");
            Console.WriteLine();

            var randomOperation = Helpers.GetRandomOperation();
            var factory = ArithematicFactory.GetFactory(randomOperation, Level.Hard);

            var question = factory.GenerateQuestion();
            var userInput = Prompt.Input<int>(question.Title);

            if (userInput == question.Answer) score++;
            else hearts--;
        }

        return score;
    }
}
