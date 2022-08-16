
# Math Game Challenge   &nbsp;  ![GitHub issues](https://img.shields.io/github/issues/Codedreamer06/MathGameChallenge)
This repository was created as a part of a competition to showcase a simple math game.

## Getting Started
https://user-images.githubusercontent.com/85114885/184918386-dad460e0-49b6-4290-8011-30d969ccc597.mp4

## Motivation & Features
* This project is a command line-based game that helps you to get better at mental arithmetic.

* It covers addition, subtraction, multiplication, division and square and cube numbers. It uses the **abstract factory design pattern** which makes it easy to add new arithmetic operators into the game.

* You have three levels to choose from: easy, medium and hard. At the end of each session, your score is saved into an SQLite database, which is shown before the start of the game. Your name is saved is saved in a config file, so you won't be pestered by asking that everytime.

* As an added bonus, there's a **freestyle-survival mode**, where you can interleave the practice of different operators together, without worrying about the timer. You get only three chances though!

**It took me a great deal of time to make this happen, including the story lines, complements and not to mention all the other bells and whistles that come along with the game. An upvote would be greatly appreciated. Have fun!  😊**

## Program Flow
```mermaid
classDiagram
  class Program {
    +Main()
  }

  class UserInput {
    +Start()
    -ConductStandardQuiz()
    -ConductFreestyleQuiz()
    -ShowEndScreen(Operation  operation, Level  difficulty, int  score, TimeSpan  duration)
    -RedirectToStart()
    -GetComplement(int score, Level difficulty) string
  }
  
  class QuizManager {
	  +startQuiz(Operation operation, Level level) int
	  +StartFreestyleSurvival() int
  }
    
  Program ..|> UserInput
  UserInput ..|> QuizManager
```
## Factories
```mermaid
classDiagram
  class IArithmeticFactory {
    <<Interface>>
    +GenerateQuestion() Question
  }
  
  class ArithmeticFactory {
	  +GetFactory(Operation operation, Level level) IArithmeticFactory
  }
  
  class AdditionFactory {
	  -Random Random
	  +Level Difficulty
	  +GenerateQuestion() Question
	  -GenerateNumber() int
  }
  
  class SubtractionFactory {
	  -Random Random
	  +Level Difficulty
	  +GenerateQuestion() Question
	  -GenerateNumber(bool isGreater) int
  }
  
  class MultiplicationFactory {
	  -Random Random
	  +Level Difficulty
	  +GenerateQuestion() Question
	  -GenerateNumber() int
  }
  
  class DivisionFactory {
	  -Random Random
	  +Level Difficulty
	  +GenerateQuestion() Question
	  -GenerateNumber(bool isGreater) int
  }
  
  class SquareFactory {
	  -Random Random
	  +Level Difficulty
	  +GenerateQuestion() Question
	  -GenerateNumber() int
  }
  
  class CubeFactory {
	  -Random Random
	  +Level Difficulty
	  +GenerateQuestion() Question
	  -GenerateNumber() int
  }
  AdditionFactory ..|> IArithmeticFactory
  SubtractionFactory ..|> IArithmeticFactory
  MultiplicationFactory ..|> IArithmeticFactory
  DivisionFactory ..|> IArithmeticFactory
  SquareFactory ..|> IArithmeticFactory
  CubeFactory ..|> IArithmeticFactory
```
## Entities
```mermaid
classDiagram
  class Operations {
	<<Enum>>
	+Addition
    +Subtraction
    +Multiplication
    +Division
    +Square
    +FreestyleSurvival
  }

  class Question {
    +string? Title
    +int Answer
  }

  class Level {
    <<Enum>>
    +Easy
    +Medium
    +Hard
  }
  
  class HistoryRecord {
    +int Id
    +DateTime Date
    +int Score
    +Operation GameType
    +GetDeepClone() HistoryRecord
  }
```
## Helpers
```mermaid
classDiagram
  class Helpers {
    +string AddErrorMessage
    +string ReadErrorMessage
    +string NoLogsMessage
    -Dictionary HeaderCharacterMap
    +DisplayTable(List records, string emptyMessage)
    +SaveScore(int score, Operation gameType)
    +ShowHistory()
    +ShowHighScoreMessage(int score)
    +WriteUsingTypeWriter(string message, int delay, int finalsleep)
    +GreetUser()
    +ShowStoryLine()
    +GetRandomEnumValue<T>() T
    +GetRandomOperation() Operation
  }
  
  class HistoryContext {
    +DbSet History
    -OnConfiguring(DbContextOptionsBuilder options)
    -OnModelCreating(ModelBuilder modelBuilder)
  }
  
  class DbService {
	  -HistoryContext _db
	  +Add(HistoryRecord log)
	  +Read()
	  +IsHighScore(int score) bool
  }
```

## Contribution
If you have any ideas,   [open an issue](https://github.com/CodeDreamer06/MathGameChallenge/issues/new)  and tell me what you think. If you'd like to contribute, please fork the repository and make changes as you'd like. Pull requests are warmly welcome.
1. Fork it
2. Create your feature branch (`git checkout -b feature/fooBar`)
3. Commit your changes (`git commit -am 'Add some fooBar'`)
4. Push to the branch (`git push origin feature/fooBar`)
5. Create a new pull request