using System;

namespace OpenClosedCodeSnippets
{

  static class CodeSnippet1
  {
    public static decimal CalculateTax(this Order order, decimal taxRate)
      => order.totalSum * taxRate;

    void BillClient(Order order, decimal taxRate)
    {
      var tax = order.CalculateTax(taxRate);
      // ...
    }
  }

  class CodeSnippet2
  {
    class Order
    {
      public decimal TotalSum;
    }

    interface ITaxCalculator { decimal CalculateTax(Order order); }
    class LithuaniaTaxCalculator : ITaxCalculator
    {
      public decimal CalculateTax(Order order) => order.TotalSum * 0.21;
    }
    class PolandTaxCalcualtor : ITaxCalculator
    {
      public decimal CalculateTax(Order order) => order.TotalSum * 0.23;
    }
    ;
    void BillClient(Order order, ITaxCalculator taxCalculator)
    {
      var tax = taxCalculator.CalculateTax(order);
      // ...
    }
  }

  class CodeSnippet3
  {
    abstract class Order
    {
      protected decimal TotalSum;
      public abstract decimal CalculateTax();
    }
    class OrderInLithuania : Order
    {
      public override decimal CalculateTax() => TotalSum * 0.21;
    }
    class OrderInPoland : Order
    {
      public override decimal CalculateTax() => TotalSum * 0.23;
    }
    void BillClient(Order order)
    {
      var tax = order.CalculateTax();
      // ...
    }
  }

  class CodeSnippet4
  {
    record Order(decimal totalSum);
    void BillClient(Order order, Func<decimal, decimal> calculateTax)
    {
      var tax = calculateTax(order.totalSum);
      // ...
    }
  }
}

namespace LiskovSubstitutionCodeSnippets
{
  class CodeSnippet1
  {
    dynamic File;
    dynamic Database;

    interface ILogger { void Log(string message); }
    class SqlLogger : ILogger
    {
      public void Log(string message)
      { // What's wrong here?
        Database.Execute($"INSERT INTO Logs VALUES({message})");
      }
    }
    class FileLogger : ILogger
    {
      public void Log(string message)
      {
        File.Open();
        File.Append(message);
        File.Close();
      }
    }
    class ConsoleLogger : ILogger
    {
      public void Log(string message)
      {
      }

    }
  }

  class CodeSnippet1
  {
    abstract class Bird
    {
      public void LayEgg() { }
      public void Fly() { }
    }
    class Duck : Bird { }
    class Eagle : Bird { }
    class Penguin : Bird { }
    class Ostrich : Bird { }

  }

  class CodeSnippet2
  {
    abstract class Bird
    {
      public void LayEgg() { }
    }
    abstract class FlyingBird : Bird
    {
      public void Fly() { }
    }

    class Duck : FlyingBird { }
    class Eagle : FlyingBird { }
    class Penguin : Bird { }
    class Ostrich : Bird { }
  }
}

namespace InterfaceSegregationCodeSnippters
{
  class CodeSnippet1
  {
    interface IVehicle
    {
      void Drive();
      void Fly();
      void FillTank();
      void Charge();
    }

    class Car : IVehicle
    {
      public void Drive()
      {
        // ...
      }
      public void FillTank()
      {
        // ...
      }
      public void Fly()
      {
        throw new InvalidOperationException("Car cannot fly");
      }
      public void Charge()
      {
        throw new InvalidOperationException("This car has fuel engine");
      }
    }
    class Airplane : IVehicle
    {
      public void Drive()
      {
        throw new InvalidOperationException("Airplane cannot drive");
      }
      public void FillTank()
      {
        // ...
      }
      public void Fly()
      {
        // ...
      }
      public void Charge()
      {
        throw new InvalidOperationException("This airplane has fuel engine");
      }
    }
  }

  class CodeSnippet2
  {
    interface ICar
    {
      void Honk();
      void Drive();
    }
    interface IAirplane
    {
      void Fly();
    }
    interface IFuelEngine
    {
      void FillTank();
    }
    interface IElectricEngine
    {
      void Charge();
    }

    class Airplane : IAirplane, IFuelEngine { }
    class Car : ICar, IFuelEngine { }
    class Tesla : ICar, IElectricEngine { }
  }
}