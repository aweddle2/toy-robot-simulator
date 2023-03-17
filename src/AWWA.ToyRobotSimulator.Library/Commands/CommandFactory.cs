using System;
using AWWA.ToyRobotSimulator.Library.Directions;

namespace AWWA.ToyRobotSimulator.Library.Commands
{
	public class CommandFactory
	{
		/// <summary>
		/// Gets an ICommand from an argument passed in from somewhere (command line, fil etc)
		/// Parses the string to the first space to get the command and identifies a matching command to return
		/// </summary>
		/// <param name="argument"></param>
		/// <returns><c ref="ICommand"></c></returns>
		public ICommand GetCommand(string argument)
		{
			string command = argument.Split(' ')[0].ToUpper();

			switch (command)
			{
				case "PLACE":
					return new PlaceCommand(argument);
				case "MOVE":
					return new MoveCommand();
				case "LEFT":
					return new DirectionCommand(RelativeDirection.Left);
				case "RIGHT":
					return new DirectionCommand(RelativeDirection.Right);
				case "REPORT":
					return new ReportCommand();
				default:
					throw new ArgumentException("Command not valid", nameof(argument));




			}
		}
	}
}

