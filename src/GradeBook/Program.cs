using System;
using System.Collections.Generic;

namespace GradeBook
{

  class Program
  {
    static void Main(string[] args)

    {
      var book = new Book("Cj's Grade Book");


      while (true)
      {
        Console.WriteLine("Enter a grade or 'q' to quite");
        var input = Console.ReadLine();
        if (input == "q")
        {
          break;
        }

        //Catching an exception
        try
        {
          var grade = double.Parse(input);
          book.AddGrade(grade);
        }
        catch (ArgumentException ex)
        {
          Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
          Console.WriteLine(ex.Message);
        }
        finally
        {
          //Always executes
          Console.WriteLine("**");
        }
      }
      //Loop, enter new grade. 

      var stats = book.GetStatistics();

      Console.WriteLine($"The average grade is {stats.Average:N1}. The highest is {stats.High} and the lowest is {stats.Low}.");
      Console.WriteLine($"The letter grade is {stats.Letter}");

    }
  }

}
