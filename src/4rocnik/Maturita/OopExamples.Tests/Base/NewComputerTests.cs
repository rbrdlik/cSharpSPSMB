using OopExamples.Implemantations;
using OopExamples.implementations;
using OopExamples.Interfaces;
using Monitor = OopExamples.implementations.Monitor;

namespace OopExamples.Tests;

public class NewComputerTests
{
    protected readonly IComputerConfiguration ComputerConfiguration;
    protected readonly IComputer Computer;
    protected readonly IComputerBuilder Builder;
    protected readonly IPerson Person;
    protected readonly ICompany Company;
    protected readonly IEnumerable<IMonitor> Monitors;

    private readonly List<GPUConnector> MonitorConnectors = new List<GPUConnector>()
    {
        GPUConnector.AVG,
        GPUConnector.DVI,
        GPUConnector.HDMI,
    };

    public NewComputerTests()
    {
        // tests
        // Create instance of interfaces, using your implementation
        ComputerConfiguration = new ComputerConfiguration(new MotherBoard("Motherboard"), new CPU("CPU"), new GPU("GPU", new []{GPUConnector.AVG, GPUConnector.HDMI}), new RAM("RAM"), new PowerSupply("PowerSupply"), new Case("Case"));
        Builder = new ComputerBuilder();
        Computer = Builder
            .AddMotherBoard(ComputerConfiguration.MotherBoard)
            .AddCPU(ComputerConfiguration.Cpu)
            .AddGPU(ComputerConfiguration.Gpu)
            .AddRam(ComputerConfiguration.Ram)
            .AddPowerSupply(ComputerConfiguration.PowerSupply)
            .AddCase(ComputerConfiguration.Case)
            .Build();
        Person = new  Person();
        Company = new Company();
        Monitors = MonitorConnectors.Select<GPUConnector, IMonitor>(connector =>
            // new Monitor("name", connector)
            new Monitor("AOC", GPUConnector.HDMI)
        );

        // Do not touch this
        Computer = Computer ?? throw new System.NotImplementedException($"{nameof(Computer)} not implemented");
        Person = Person ?? throw new System.NotImplementedException($"{nameof(Person)} not implemented");
        Company = Company ?? throw new System.NotImplementedException($"{nameof(Company)} not implemented");
    }

    [Fact]
    public void IsValidSetup()
    {
        Assert.NotNull(ComputerConfiguration);
        Assert.NotNull(Builder);
        Assert.NotNull(Computer);
        Assert.NotNull(Person);
        Assert.NotNull(Company);
        Assert.NotNull(Monitors);

        Assert.NotEmpty(Monitors);
        Assert.Equal(MonitorConnectors.Count(), Monitors.Count());
        Assert.All(Monitors, monitor =>
            Assert.Contains(monitor.Connector, MonitorConnectors));
    }

    protected void IsValidComputer(IComputer computer)
    {
        Assert.NotNull(computer.MotherBoard);
        Assert.NotNull(computer.Gpu);
        Assert.NotNull(computer.Ram);
        Assert.NotNull(computer.PowerSupply);
        Assert.NotNull(computer.Case);
    }
}