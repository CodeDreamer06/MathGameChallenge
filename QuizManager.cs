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
}
