using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)

    {
      IBook book = new DiscBook("Cj's Grade Book");
      //Handle event
      book.GradeAdded += OnGradeAdded;



      // book.GradeAdded = null; NOT ALLOWED
      EnterGrades(book);
      //Loop, enter new grade. 

      var stats = book.GetStatistics();

      Console.WriteLine($"For the book named {book.Name}");
      Console.WriteLine($"The average grade is {stats.Average:N1}. The highest is {stats.High} and the lowest is {stats.Low}.");
      Console.WriteLine($"The letter grade is {stats.Letter}");

    }

    private static void EnterGrades(IBook book)
    {
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
    }

    static void OnGradeAdded(object sender, EventArgs e)
    {
      Console.WriteLine("A grade was added.");
    }


  }

}
