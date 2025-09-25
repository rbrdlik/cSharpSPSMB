﻿using OopExamples.Interfaces;

namespace OopExamples.implementations;

public class CPU : ICPU
{
    public string Name { get; set; }

    public CPU(string name)
    {
        Name = name;
    }
}