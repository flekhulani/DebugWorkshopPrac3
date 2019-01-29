using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data;

namespace debugws3
{
  public struct Result
  {
    public double result;
    public string err;

    public Result(double _result, string _err)
    {
      result = _result;
      err = _err;
    }
  }

  public class Calc
  {
    private static void WelcomeMessage()
    {
      Console.WriteLine(
          "\n\n  --------------------------- Welcome to Calculator.NET! --------------------------" +
          "\n\n Enter any calculation you would like to perform using any of the four operators" +
          "\n\n\n\t\t\t\t `+` `-` `*` `/`                                      " +
          "\n" +
          "\n\tExamples: 45 + 16" +
          "\n\t          65 * 4 / 531" +
          "\n\t          49 - 2 + 134 * 648" +
          "\n\n" +
          "\t\t\t\t You can type `EXIT` any time to leave the application." +
          "\n\n");
    }

    //Method invoked as long as the user is running the calculator
    private static bool CalculatorOn()
    {
      var userInput = Console.ReadLine();

      if (String.IsNullOrEmpty(userInput))
      {
        const string message = "Type something! :)";
        Console.WriteLine(message);
        return true;
      }

      if (userInput.ToLower() == "exit")
        return false;

      var result = Calculate(userInput);

      if (result.err != "")
      {
        Console.WriteLine("Error: {0}", result.err);
      }
      else
      {
        Console.WriteLine("Result: {0}", result.result);
        Console.WriteLine("\nType 'Exit' to leave :( Or try another calculation :)\n");
      }

      return true;
    }

    public static Result Calculate(string input)
    {
      if (input == null)
      {
        return new Result(0, "Wrong entry. Try again using one or more operations");
      }

      DataTable data = new DataTable();
      var result = Convert.ToDouble(data.Compute(input, null));
      return new Result(result, "");
    }

    public static void ExitAndThankYouMessage()
    {
      Console.Clear();
      Console.WriteLine("\n\n\n\n");
      Console.WriteLine(@"
                         _____  _   _  _____  _   _  _   _     _     _  _____  _   _
                        (_   _)( ) ( )(  _  )( ) ( )( ) ( )   ( )   ( )(  _  )( ) ( )
                          | |  | |_| || (_) || `\| || |/'/'   `\`\_/'/'| ( ) || | | |
                          | |  |  _  ||  _  || , ` || , <       `\ /'  | | | || | | |
                          | |  | | | || | | || |`\ || |\`\       | |   | (_) || (_) |
                          (_)  (_) (_)(_) (_)(_) (_)(_) (_)      (_)   (_____)(_____)
                                    |\
                            /    /\/o\_
                           (.-.__.(   __o
                        /\_(      .----'
                         .' \____/
                        /   /  / \
                    ___:____\__\__\__________________________________________________________");
    }

    private static void Main(string[] args)
    {
      WelcomeMessage();

      Console.WriteLine("-> Calculate ");

      bool calculatorOn = true;
      while (calculatorOn)
      {
        calculatorOn = CalculatorOn();
      }

      ExitAndThankYouMessage();
    }

  }
}