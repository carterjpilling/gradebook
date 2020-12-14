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
      book.ShowStatistics();

    }
  }

}
