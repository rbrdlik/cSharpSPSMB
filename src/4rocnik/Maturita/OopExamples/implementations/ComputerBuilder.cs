using OopExamples.implementations;
using OopExamples.Interfaces;
using OopExamples.Interfaces.Exceptions;

namespace OopExamples.Implemantations;

public class ComputerBuilder : IComputerBuilder
{
    private IMotherBoard _motherBoard;
    private ICPU _cpu;
    private IGPU _gpu;
    private IRAM _ram;
    private IPowerSupply _powerSupply;
    private ICase _case;

    public IComputerBuilder AddMotherBoard(IMotherBoard motherBoard)
    {
        _motherBoard = motherBoard;
        return this;
    }

    public IComputerBuilder AddCPU(ICPU cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IComputerBuilder AddGPU(IGPU gpu)
    {
        _gpu = gpu;
        return this;
    }

    public IComputerBuilder AddRam(IRAM ram)
    {
        _ram = ram;
        return this;
    }

    public IComputerBuilder AddPowerSupply(IPowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public IComputerBuilder AddCase(ICase pcCase)
    {
        _case = pcCase;
        return this;
    }

    public IComputer Build()
    {
        if (_motherBoard == null ||
            _cpu == null ||
            _gpu == null ||
            _ram == null ||
            _powerSupply == null ||
            _case == null)
        {
            throw new ComputerMissingComponentsException();
        }

        return new Computer
        {
            MotherBoard = _motherBoard,
            Cpu = _cpu,
            Gpu = _gpu,
            Ram = _ram,
            PowerSupply = _powerSupply,
            Case = _case,
        };
    }

    public IComputer BuildFromConfiguration(IComputerConfiguration configuration)
    {
        return this
            .AddMotherBoard(configuration.MotherBoard)
            .AddCPU(configuration.Cpu)
            .AddGPU(configuration.Gpu)
            .AddRam(configuration.Ram)
            .AddPowerSupply(configuration.PowerSupply)
            .AddCase(configuration.Case)
            .Build();
    }

}