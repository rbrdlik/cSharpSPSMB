using System;
using System.Text.RegularExpressions;

namespace setup
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // FIZZBUZZ
            /*
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine("fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("buzz");
                }
                else if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("fizzbuzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            */
            
            // HADANI CISLA
            /*
            bool gameRunning = true;
            int numberOfTries = 1;
            
            Random rnd = new Random();
            int generatedNumber = rnd.Next(1, 100);
            
            while (gameRunning)
            {
                Console.WriteLine("Write a number between 1 and 100.");
                int userNumber = Convert.ToInt32(Console.ReadLine());
                if (userNumber == generatedNumber)
                {
                    Console.WriteLine($"You are the same number! On {numberOfTries}. try!");
                    gameRunning = false;
                }
                else if(userNumber < 0 || userNumber > 100)
                {
                    Console.WriteLine("You don't have a number between 1 and 100!");
                }
                else
                {
                    if (generatedNumber > userNumber)
                    {
                        Console.WriteLine("Your guessed number is smaller than the number!");
                        numberOfTries++;
                    }
                    else if (generatedNumber < userNumber)
                    {
                        Console.WriteLine("Your guessed number is larger than the number!");
                        numberOfTries++;
                    }
                }
            }
            */
            
            // KALKULACKA
        }
        
    }

    public class Calculator
    {
        public string Solve(string mathProblem)
        {
            mathProblem.Replace(".", ",");
            
            string[] splitProblem = Regex.Split(mathProblem, @"\s+");
            double finished = 0;
            
            double firstNumber = Double.Parse(splitProblem[0].Replace(".", ","));
            double secondNumber = Double.Parse(splitProblem[2].Replace(".", ","));

            if (secondNumber == 0)
            {
                return "You cant divide by zero";
            }
            
            switch (splitProblem[1])
            {
                case "+":
                    finished = firstNumber +  secondNumber; 
                    break;
                case "-":
                    finished = firstNumber - secondNumber;
                    break;
                case "*":
                    finished = firstNumber *secondNumber;
                    break;
                case "/":
                    finished = firstNumber / secondNumber;
                    break;
                case "**":
                    finished = Math.Pow(firstNumber, secondNumber);
                    break;
                default: 
                    Console.WriteLine("Wrong user input!");
                    break;
            }

            return $"{splitProblem[0]} {splitProblem[1]} {splitProblem[2]} = {finished}";
        }
    }
}