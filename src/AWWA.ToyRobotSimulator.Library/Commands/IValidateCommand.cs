using System;
using AWWA.ToyRobotSimulator.Library.Boards;

namespace AWWA.ToyRobotSimulator.Library.Commands
{
	public interface IValidateCommand : ICommand
    {
        CommandResult Validate(Board board);
    }
}

