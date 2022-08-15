# Math Game Challenge   &nbsp;  ![GitHub issues](https://img.shields.io/github/issues/Codedreamer06/MathGameChallenge)
This repository was created as a part of a competition to showcase a simple math game.
## Program Flow UML
```mermaid
classDiagram
  class Program {
    +Main()
  }

  class UserInput {
    +Start()
    -GetCompliment(int score, Level difficulty) string
  }
  
  class QuizManager {
	  +startQuiz(Operation operation, Level level) int
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
  AdditionFactory ..|> IArithmeticFactory
  SubtractionFactory ..|> IArithmeticFactory
  MultiplicationFactory ..|> IArithmeticFactory
  DivisionFactory ..|> IArithmeticFactory
  SquareFactory ..|> IArithmeticFactory
```
## Entities UML
```mermaid
classDiagram
  class Levels {
	<<Enum>>
	+Addition
    +Subtraction
    +Multiplication
    +Division
    +Square
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
## Helpers UML
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
    +WriteUsingTypeWriter(string message)
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
## Motivation & Features
* This project is a command line-based game that helps you to get better at mental arithmetic.

* It covers addition, subtraction, multiplication, division and square numbers. It uses the **abstract factory design pattern** which makes it easy to add new arithmetic operators into the game.

* You have three levels to choose from: easy, medium and hard. At the end of each session, your score is saved into an SQLite database, which is shown before the start of the game.

**Have fun!**
## Contribution
If you have any ideas,   [open an issue](https://github.com/CodeDreamer06/MathGameChallenge/issues/new)  and tell me what you think. If you'd like to contribute, please fork the repository and make changes as you'd like. Pull requests are warmly welcome.
1. Fork it
2. Create your feature branch (`git checkout -b feature/fooBar`)
3. Commit your changes (`git commit -am 'Add some fooBar'`)
4. Push to the branch (`git push origin feature/fooBar`)
5. Create a new pull request