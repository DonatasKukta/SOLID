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
