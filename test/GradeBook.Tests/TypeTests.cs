using System;
using Xunit;

namespace GradeBook.Tests
{
  public class TypeTests
  {
    //Fact is an attribute. A piece of a date attached to the method Test1, or the methods following it. 
    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
      /*
      Three Sections
      1. Arrange
      2. Act 
      3. Assert
      */


      //Arrange
      var book1 = GetBook("Book 1");
      var book2 = GetBook("Book 2");

      //Act


      //Assert API and Assert
      Assert.Equal("Book 1", book1.Name);
      Assert.Equal("Book 2", book2.Name);
      Assert.NotSame(book1, book2);


    }
    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {

      var book1 = GetBook("Book 1");
      //This is not a copy. This take the value of book1 (the reference) and copy it into book2. Its just a pointer. They have the same pointer and are the same reference. 
      var book2 = book1;

      Assert.Same(book1, book2);
      Assert.True(Object.ReferenceEquals(book1, book2));


    }
    [Fact]
    public void CSharpCanPassByRef()
    {

      var book1 = GetBook("Book 1");
      GetBookSetName(ref book1, "New Name");

      Assert.Equal("New Name", book1.Name);

    }
    // ref book means that its passed by reference and not by value. 
    private void GetBookSetName(ref Book book, string name)
    {
      book = new Book(name);
    }



    [Fact]
    public void CSharpIsPassByValue()
    {

      var book1 = GetBook("Book 1");
      GetBookSetName(book1, "New Name");

      Assert.Equal("Book 1", book1.Name);

    }

    private void GetBookSetName(Book book, string name)
    {
      book = new Book(name);
    }


    [Fact]
    public void CanSetNameFromReference()
    {

      var book1 = GetBook("Book 1");
      SetName(book1, "New Name");

      Assert.Equal("New Name", book1.Name);

    }

    private void SetName(Book book, string name)
    {
      book.Name = name;
    }

    Book GetBook(string name)
    {
      return new Book(name);
    }

    [Fact]
    public void Test1()
    {
      var x = GetInt();
      SetInt(ref x);

      Assert.Equal(x, 42);
    }

    private void SetInt(ref int z)
    {
      z = 42;
    }

    private int GetInt()
    {
      return 3;
    }

    [Fact]
    public void StringsBehaveLikeValueTypes()
    {
      string name = "Cj";
      var upper = MakeUppercase(name);

      Assert.Equal("Cj", name);
      Assert.Equal("CJ", upper);
    }

    private string MakeUppercase(string parameter)
    {
      return parameter.ToUpper();
    }
  }
}
