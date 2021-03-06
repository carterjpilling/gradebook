using System;
using Xunit;

namespace GradeBook.Tests
{
  public class BookTests
  {
    //Fact is an attribute. A piece of a date attached to the method Test1, or the methods following it. 
    [Fact]
    public void BookCalculatesAnAverageGrade()
    {
      /*
      Three Sections
      1. Arrange
      2. Act 
      3. Assert
      */

      //Arrange
      var book = new InMemoryBook("");
      book.AddGrade(89.1);
      book.AddGrade(90.5);
      book.AddGrade(77.3);


      //Act
      var result = book.GetStatistics();

      //Assert API and Assert
      Assert.Equal(85.6, result.Average, 1);
      Assert.Equal(90.5, result.High, 1);
      Assert.Equal(77.3, result.Low, 1);
      Assert.Equal('B', result.Letter);
    }
  }
}
