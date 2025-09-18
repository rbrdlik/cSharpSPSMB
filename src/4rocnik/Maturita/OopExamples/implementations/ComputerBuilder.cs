using OopExamples.Interfaces;
using OopExamples.Interfaces.Exceptions;

namespace OopExamples.implementations;

public class ComputerBuilder : IComputerBuilder
{
    private IMotherBoard? _motherBoard;
    private ICPU? _cpu;
    private IGPU? _gpu;
    private IRAM? _ram;
    private IPowerSupply? _powerSupply;
    private ICase? _case;

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

    public IComputerBuilder AddMotherBoard(IMotherBoard motherBoard)
    {
        if (_motherBoard != null) throw new ComponentAlreadyConnectedException();
        _motherBoard = motherBoard;
        return this;
    }

    public IComputerBuilder AddCPU(ICPU cpu)
    {
        if (_cpu != null) throw new ComponentAlreadyConnectedException();
        _cpu = cpu;
        return this;
    }

    public IComputerBuilder AddGPU(IGPU gpu)
    {
        if (_gpu != null) throw new ComponentAlreadyConnectedException();
        _gpu = gpu;
        return this;
    }

    public IComputerBuilder AddRam(IRAM ram)
    {
        if (_ram != null) throw new ComponentAlreadyConnectedException();
        _ram = ram;
        return this;
    }

    public IComputerBuilder AddPowerSupply(IPowerSupply powerSupply)
    {
        if (_powerSupply != null) throw new ComponentAlreadyConnectedException();
        _powerSupply = powerSupply;
        return this;
    }

    public IComputerBuilder AddCase(ICase pcCase)
    {
        if (_case != null) throw new ComponentAlreadyConnectedException();
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
            throw new ComponentNotConnectedException();
        }

        return new Computer(_motherBoard, _cpu, _gpu, _ram, _powerSupply, _case);
    }
}
