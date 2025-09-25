using OopExamples.Interfaces;

namespace OopExamples.implementations;

public class MotherBoard : IMotherBoard
{
    public string Name { get; set; }

    public MotherBoard(string name)
    {
        Name = name;
    }
}