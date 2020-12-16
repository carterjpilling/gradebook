using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
  public delegate void GradeAddedDelegate(object sender, EventArgs args);

  public class NamedObject
  {
    public NamedObject(string name)
    {
      Name = name;
    }

    public string Name
    {
      get;
      set;
    }
  }


  //interfaces begin with uppercase I. More common than abstract classes. 
  public interface IBook
  {
    void AddGrade(double grade);
    Statistics GetStatistics();
    string Name { get; }
    event GradeAddedDelegate GradeAdded;
  }

  public abstract class Book : NamedObject, IBook
  {
    protected Book(string name) : base(name)
    {
    }

    public abstract event GradeAddedDelegate GradeAdded;
    public abstract void AddGrade(double grade);
    public abstract Statistics GetStatistics();
  }

  public class DiscBook : Book
  {
    public DiscBook(string name) : base(name)
    {
    }

    public override event GradeAddedDelegate GradeAdded;

    public override void AddGrade(double grade)
    {
      using (var writer = File.AppendText($"{Name}.txt"))
      {
        writer.WriteLine(grade);
        if (GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }
      }
      //Garbage disposal. Same as writer.Close();
      // writer.Dispose(); Taken care of inside of using. 
    }

    public override Statistics GetStatistics()
    {
      var result = new Statistics();

      using (var reader = File.OpenText($"{Name}.txt"))
      {
        var line = reader.ReadLine();
        while (line != null)
        {
          var number = double.Parse(line);
          result.Add(number);
          line = reader.ReadLine();
        }
      }
      return result;
    }
  }

  //Book is a named object. 
  public class InMemoryBook : Book
  {
    //Explicit constructor, same name, no returnt type. (String name) is a constructor parameter. 
    //Base, accessing a constrcutor on the base class. 
    public InMemoryBook(string name) : base(name)
    {
      grades = new List<double>();
      //This is an implicit variable that can be used inside variables and constructors. You use it when you want to define the object that is currently being operated on. Had to use this because we used the name word twice. 
      Name = name;
    }

    public void AddGrade(char letter)
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

    //Overrides method inherited from a baseclass. Can only override virtual and abstract methods. 
    public override void AddGrade(double grade)
    {
      if (grade <= 100 && grade >= 0)
      {
        grades.Add(grade);
        if (GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }
      }
      else
      {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }
    }

    public override event GradeAddedDelegate GradeAdded;

    public override Statistics GetStatistics()
    {
      var result = new Statistics();


      for (var index = 0; index < grades.Count; index++)
      {
        result.Add(grades[index]);
      };

      return result;
    }
    //Reason that this list is not public is because we want to user to use AddGrade so we can check their numbers before it touches our List. 
    private List<double> grades;



    //Assignable only from constructor. (readonly) 
    public const string CATEGORY = "Science";
  }
}