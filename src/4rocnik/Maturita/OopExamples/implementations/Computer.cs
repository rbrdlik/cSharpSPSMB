using System.Text.RegularExpressions;
using OopExamples.Interfaces;

namespace OopExamples.implementations;

public class Computer : IComputer
{
    public  IEntity Owner { get; init; }
    public IMotherBoard MotherBoard { get; init; }
    public ICPU Cpu { get; init; }
    public IGPU Gpu { get; init; }
    public IRAM Ram { get; init; }
    public IPowerSupply PowerSupply { get; init; }
    public ICase Case { get; init; }
    public bool IsOn { get; set; }
    public bool IsPersonalPC { get; }
    public bool IsCompanyPC { get; }
    
    public void PowerUp()
    {
        IsOn = true;
    }

    public void ShutDown()
    {
        IsOn = false;
    }

    public void PressPowerButton()
    {
        if (IsOn)
        {
            ShutDown();
            
        }
        else
        {
            PowerUp();
        }
    }

    public void Print(string text)
    {
        Console.WriteLine($"[COMPUTER]: {text}");
    }
    

    public float Compute(string equation)
    {
        equation.Replace(".", ",");
            
        string[] splitProblem = Regex.Split(equation, @"\s+");
        double finished = 0;
            
        double firstNumber = Double.Parse(splitProblem[0].Replace(".", ","));
        double secondNumber = Double.Parse(splitProblem[2].Replace(".", ","));

        if (secondNumber == 0)
        {
            return 0;
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

        return (float)finished;
    }

    public IComputer BuildNewComputer(IComputerConfiguration configuration)
    {
        return new Computer
        {
            MotherBoard = configuration.MotherBoard,
            Cpu = configuration.Cpu,
            Gpu = configuration.Gpu,
            Ram = configuration.Ram,
            PowerSupply = configuration.PowerSupply,
            Case = configuration.Case,
        };
    }
}