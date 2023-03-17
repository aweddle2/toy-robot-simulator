using System;
using AWWA.ToyRobotSimulator.Library.Boards;
namespace AWWA.ToyRobotSimulator.Library.Commands
{
	public interface ICommand
	{
		public CommandResult Validate(IBoard board);
		public CommandResult Execute(IBoard board);
	}
}

