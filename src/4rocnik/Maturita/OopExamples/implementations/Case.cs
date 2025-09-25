using OopExamples.Interfaces;

namespace OopExamples.implementations;

public class Case : ICase
{
    public string Name { get; set; }

    public Case(string name)
    {
        Name = name;
    }
}