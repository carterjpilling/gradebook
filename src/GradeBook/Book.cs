using System;
using System.Collections.Generic;

namespace GradeBook
{
  public class Book
  {
    //Explicit constructor, same name, no returnt type. (String name) is a constructor parameter. 
    public Book(string name)
    {
      grades = new List<double>();
      //This is an implicit variable that can be used inside variables and constructors. You use it when you want to define the object that is currently being operated on. Had to use this because we used the name word twice. 
      Name = name;
    }

    public void AddLetterGrade(char letter)
    {
      switch (letter)
      {
        case 'A':
          AddGrade(90);
          break;
        case 'B':
          AddGrade(80);
          break;
        case 'C':
          AddGrade(70);
          break;

        default:
          AddGrade(0);
          break;
      }
    }

    public void AddGrade(double grade)
    {
      if (grade <= 100 && grade >= 0)
      {
        grades.Add(grade);
      }
      else
      {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }
    }

    public Statistics GetStatistics()
    {
      var result = new Statistics();
      result.Average = 0.0;

      result.High = double.MinValue;
      result.Low = double.MaxValue;

      for (var index = 0; index < grades.Count; index++)
      {
        result.Low = Math.Min(grades[index], result.Low);
        result.High = Math.Max(grades[index], result.High);
        result.Average += grades[index];
      };

      result.Average /= grades.Count;

      switch (result.Average)
      {
        case var d when d >= 90.0:
          result.Letter = 'A';
          break;
        case var d when d >= 80.0:
          result.Letter = 'B';
          break;
        case var d when d >= 70.0:
          result.Letter = 'C';
          break;
        case var d when d >= 60.0:
          result.Letter = 'D';
          break;
        default:
          result.Letter = 'F';
          break;
      }

      return result;
    }
    //Reason that this list is not public is because we want to user to use AddGrade so we can check their numbers before it touches our List. 
    private List<double> grades;
    public string Name;
  }
}