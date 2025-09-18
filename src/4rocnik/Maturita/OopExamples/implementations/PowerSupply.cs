using OopExamples.Interfaces;

namespace OopExamples.implementations;

public class PowerSupply : IPowerSupply
{
    public string Name { get; set; }

    public PowerSupply(string name)
    {
        Name = name;
    }
}