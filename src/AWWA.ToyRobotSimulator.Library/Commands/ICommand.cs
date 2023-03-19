using System;
using AWWA.ToyRobotSimulator.Library.Boards;
namespace AWWA.ToyRobotSimulator.Library.Commands
{
	/// <summary>
	/// This interface must be implemented for any new command for the robot.
	/// </summary>
	public interface ICommand
	{
		CommandResult Execute(Board board);
        CommandResult Validate(Board board);
    }
}

