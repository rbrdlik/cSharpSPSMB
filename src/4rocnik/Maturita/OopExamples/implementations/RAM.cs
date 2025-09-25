using OopExamples.Interfaces;

namespace OopExamples.implementations;

public class RAM : IRAM
{
    public string Name { get; set; }

    public RAM(string name)
    {
        Name = name;
    }
}