using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Book
  {
    //Explicit constructor, same name, no returnt type. (String name) is a constructor parameter. 
    public Book(string name)
    {
      grades = new List<double>();
      //This is an implicit variable that can be used inside variables and constructors. You use it when you want to define the object that is currently being operated on. Had to use this because we used the name word twice. 
      this.name = name;
    }



    public void AddGrade(double grade)
    {
      grades.Add(grade);
    }

    public void ShowStatistics()
    {
      var result = 0.0;
      var highGrade = double.MinValue;
      var lowGrade = double.MaxValue;

      foreach (var number in grades)
      {
        lowGrade = Math.Min(number, lowGrade);
        highGrade = Math.Max(number, highGrade);
        result += number;
      }

      result /= grades.Count;
      Console.WriteLine($"The average grade is {result:N1}. The highest is {highGrade} and the lowest is {lowGrade}.");
    }
    //Reason that this list is not public is because we want to user to use AddGrade so we can check their numbers before it touches our List. 
    private List<double> grades;
    private string name;
  }
}