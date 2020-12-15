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
      book.AddGrade(80.5);

      var stats = book.GetStatistics();

      Console.WriteLine($"The average grade is {stats.Average:N1}. The highest is {stats.High} and the lowest is {stats.Low}.");

    }
  }

}
