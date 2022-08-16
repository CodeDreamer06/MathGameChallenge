using System.ComponentModel.DataAnnotations;

public enum Operation
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Square,
    Cube,
    [Display(Name = "Freestyle survival")]
    FreestyleSurvival
}