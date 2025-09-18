using OopExamples.implementations;
using OopExamples.Interfaces;

namespace OopExamples.Tests;

public class IsComputerOn
{
    private readonly IComputer _computer = new Computer(new MotherBoard("MotherBoard"), new CPU("CPU"), new GPU("GPU", [GPUConnector.AVG, GPUConnector.DVI, GPUConnector.HDMI]), new RAM("RAM"), new PowerSupply("PowerSupply"), new Case("Case"));

    public IsComputerOn()
    {
        // Do not touch this
        _computer = _computer ?? throw new System.NotImplementedException($"{nameof(_computer)} not implemented");
    }
    
    [Fact]
    public void IsOnReturns_False()
    {
        Assert.False(_computer.IsOn);
    }
    
    [Fact]
    public void PowerUp_TurnsOnPC()
    {
        _computer.PowerUp();
        Assert.True(_computer.IsOn);
    }
    
    [Fact]
    public void PowerUpAndShutDown_TurnsOffPC()
    {
        _computer.PowerUp();
        _computer.ShutDown();
        Assert.False(_computer.IsOn);
    }
    
    [Fact]
    public void PowerUpTwice_TurnsOnPC()
    {
        _computer.PowerUp();
        _computer.PowerUp();
        Assert.True(_computer.IsOn);
    }
    
    [Fact]
    public void ShutDownTwice_TurnsOnPC()
    {
        _computer.ShutDown();
        _computer.ShutDown();
        Assert.False(_computer.IsOn);
    }
    
    [Fact]
    public void PressPowerButton_TurnsOnPC()
    {
        _computer.PressPowerButton();
        Assert.True(_computer.IsOn);
    }
    
    [Fact]
    public void PressPowerButtonTwice_TurnsOffPC()
    {
        _computer.PressPowerButton();
        _computer.PressPowerButton();
        Assert.False(_computer.IsOn);
    }
    
    [Fact]
    public void PressPowerButtonThreeTimes_TurnsOnPC()
    {
        _computer.PressPowerButton();
        _computer.PressPowerButton();
        _computer.PressPowerButton();
        Assert.True(_computer.IsOn);
    }
}