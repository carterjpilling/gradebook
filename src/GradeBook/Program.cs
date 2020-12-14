using System;
using System.Collections.Generic;

namespace GradeBook
{

  class Program
  {
    static void Main(string[] args)

    {
      var book = new Book("Cj's Grade Book");
      book.AddGrade(59.1);
      book.AddGrade(90.5);


      var grades = new List<double>() { 12.72, 7.53, 1.11 };
      grades.Add(55.14);

      var result = 0.0;
      foreach (var number in grades)
      {
        result += number;
      }

      result /= grades.Count;
      Console.WriteLine($"The average grade is {result:N1}");
    }
  }

}
