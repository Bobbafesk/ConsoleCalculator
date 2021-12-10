using System;
using static System.Console;


namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isAlive = true;

            while (isAlive)
            {
                Console.WriteLine("Welcome to Anders Calculator!" +
                    "\n Please, first select one of the following operators:" +
                    "\n +: Add" +
                    "\n -: Subtract" +
                    "\n *: Multiply" +
                    "\n /: Divide" +
                    "\n 0: Exit calculator" +
                    "\r\n ");
                
                // This is the menu of the program. Inputs from the user will select operator.
                switch (ReadLine())
                {
                    case "0":
                        WriteLine("Do you really want to exit? Press y");

                        // if (ReadLine().ToLower == "y") Varför fungerar inte det att skriva som på denna raden?
                        // If user press Y or y then exit
                        if (ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
                        {
                            isAlive = false;
                            Environment.Exit(0);                            
                        }
                        break;
                    case "+":
                        Clear();
                        Add();
                        break;
                    case "-":
                        Clear();
                        Subtract();
                        break;
                    case "*":
                        Clear();
                        Multiply();
                        break;
                    case "/":
                        Clear();
                        Divide();
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid menu option, please write one of following operators + - * /\r\n");
                        break;
                }

            }

        }

        // This will write the name of the variable number and return a decimal
        static double GetDecimalFromUser(string nameVariable)
        {
            double userInput = 0;
            bool succeeded = false;
            WriteLine("Enter a decimal number " + nameVariable);
            while (!succeeded)
            {
                succeeded = double.TryParse(ReadLine(), out userInput);
                if (!succeeded)
                {
                    WriteLine("The number must be in decimal form");
                }
            }
            return userInput;
        }

        // This will chek if input is 0 (it is not possible to divide by zero) and if 0, ask for a new number that it will return
        static double NotDivideByZero(double userInputB)
        {
            if (userInputB != 0)
            {
                return userInputB;
            }
            else
            {
                while (userInputB == 0)
                {
                    userInputB = GetDecimalFromUser("two, Not Zero");
                }
                return userInputB;
            }
        }

        // This will write the two numbers with the operator between and result. Example 1 + 2 = 3
        static void WriteResult(double userInputA, double userInputB, double result, string aOperator)
        {
            WriteLine("\r\nThe result for {0} {1} {2} = {3}\r\n", userInputA, aOperator, userInputB, result);
        }

        // Here are the methods for the 4 operations
        static void Add()
        {
            double userInputA = 0, userInputB = 0, result = 0;
            userInputA = GetDecimalFromUser("One:");
            userInputB = GetDecimalFromUser("Two:");
            result = userInputA + userInputB;
            WriteResult(userInputA, userInputB, result, "+");
        }

        static void Subtract()
        {
            double userInputA = 0, userInputB = 0, result = 0;
            userInputA = GetDecimalFromUser("One:");
            userInputB = GetDecimalFromUser("Two:");
            result = userInputA - userInputB;
            WriteResult(userInputA, userInputB, result, "-");
        }

        static void Multiply()
        {
            double userInputA = 0, userInputB = 0, result =0;
            userInputA = GetDecimalFromUser("One:");
            userInputB = GetDecimalFromUser("Two:");
            result = userInputA * userInputB;
            WriteResult(userInputA, userInputB, result, "*");
        }

        static void Divide()
        {
            double userInputA = 0, userInputB = 0, result = 0;
            userInputA = GetDecimalFromUser("One:");
            userInputB = GetDecimalFromUser("Two:");
            // Sheck for userInput B != 0
            userInputB = NotDivideByZero(userInputB);
            result = userInputA / userInputB;
            WriteResult(userInputA, userInputB, result, "/");
        }
    }
}