using AWWA.ToyRobotSimulator.Library;
using AWWA.ToyRobotSimulator.Library.Commands;

Console.WriteLine("Welcome to the Toy Robot Simulator.  Please enter a command.");


ToyRobotSimulatorClient toyRobotSimulatorClient = new ToyRobotSimulatorClient();

while (true)
{
    string console = Console.ReadLine();

    CommandResult result = toyRobotSimulatorClient.ExecuteCommand(console);

    foreach (string message in result.Messages)
    {
        Console.WriteLine(message);
    }
}
