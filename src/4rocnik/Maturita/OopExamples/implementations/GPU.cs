using OopExamples.Interfaces;
using OopExamples.Interfaces.Exceptions;

namespace OopExamples.implementations;

public class GPU : IGPU
{
    public string Name { get; set; } = string.Empty;
    public GPUConnector[] Connectors { get; init; } = Array.Empty<GPUConnector>();
    public IComputer? Computer { get; private set; }
    public GPUConnector[] AvailableConnectors => _availableConnectors.ToArray();
    public IMonitor[] ConnectedMonitors => _connectedMonitors.ToArray();
    public bool IsUsed => Computer != null;

    private readonly List<GPUConnector> _availableConnectors = new();
    private readonly List<IMonitor> _connectedMonitors = new();

    public GPU(string name, GPUConnector[] connectors)
    {
        Name = name;
        Connectors = connectors;
        _availableConnectors.AddRange(connectors);
    }

    public void Connect(IComputer computer)
    {
        if (IsUsed) throw new ComponentAlreadyConnectedException();
        Computer = computer;
    }

    public void Disconnect()
    {
        if (!IsUsed) throw new ComponentNotConnectedException();
        Computer = null;
        _connectedMonitors.Clear();
        _availableConnectors.Clear();
        _availableConnectors.AddRange(Connectors);
    }

    public void ConnectMonitor(IMonitor monitor)
    {
        if (_availableConnectors.Count == 0)
            throw new InvalidConnectorException();

        _connectedMonitors.Add(monitor);
        _availableConnectors.RemoveAt(0);
    }

    public void DisconnectMonitor(IMonitor monitor)
    {
        if (!_connectedMonitors.Contains(monitor))
            throw new ComponentNotConnectedException();

        _connectedMonitors.Remove(monitor);
        _availableConnectors.Add(Connectors[_connectedMonitors.Count]);
    }
}