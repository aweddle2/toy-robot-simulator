using System;
using AWWA.ToyRobotSimulator.Library.Boards;
namespace AWWA.ToyRobotSimulator.Library.Commands
{
	public interface ICommand
	{
		CommandResult Execute(Board board);
        CommandResult Validate(Board board);
    }
}

