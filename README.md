# Toy Robot Simulator

Toy Robot Simulator is a C# library for moving Items around a Board.

Build Status : ![Build Status](https://github.com/aweddle2/toy-robot-simulator/actions/workflows/dotnet-desktop.yml/badge.svg)

Code Coverage : ![Code Coverage](https://img.shields.io/badge/Code%20Coverage-89%25-success?style=flat)

## Installation

Clone this git repository then run

```bash
dotnet run --project src/AWWA.ToyRobotSimulator.Console/AWWA.ToyRobotSimulator.Console.cspro
```
Or open the sln file and compile and run the console application in Visual Studio.

## Console Application Usage

```bash
PLACE X,Y,DIRECTION
MOVE
LEFT
RIGHT
REPORT
```
## Library Usage
Reference the library from your own application, or preferable reference the nuget from [here](https://www.youtube.com/watch?v=dQw4w9WgXcQ).

```csharp
//Instantiate the client
ToyRobotSimulatorClient toyRobotSimulatorClient = new ToyRobotSimulatorClient();

//Get a command
string console = "PLACE 0,0,NORTH";

//Execute the command
CommandResult result = toyRobotSimulatorClient.ExecuteCommand(console);

```

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)