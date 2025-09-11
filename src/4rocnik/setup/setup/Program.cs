using System;

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
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                } else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                } else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            */
            
            // HADANI CISLA
            bool gameRunning = true;
            int numberOfTries = 1;
            
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 101);

            while (gameRunning)
            {
                Console.WriteLine("Napiš číšlo 0-100: ");
                
                int input = Convert.ToInt32(Console.ReadLine());

                if (randomNumber == input)
                {
                    Console.WriteLine($"Uhádl jsi správně číslo {randomNumber}! Na {numberOfTries}. pokus!");
                    gameRunning = false;
                }
                else
                {
                    if (randomNumber > input)
                    {
                        Console.WriteLine("Číslo které jsi napsal je menší než číslo které hádáš!");
                    }
                    else if (randomNumber < input)
                    {
                        Console.WriteLine("Číslo které jsi napsal je větší než číslo které hádáš!");
                    }
                    
                    numberOfTries++;
                }
            }
        }
    }
}