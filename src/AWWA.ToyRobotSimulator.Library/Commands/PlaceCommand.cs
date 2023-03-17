using System;
using AWWA.ToyRobotSimulator.Library.Boards;

namespace AWWA.ToyRobotSimulator.Library.Commands
{
	public class PlaceCommand : ICommand
	{
		public PlaceCommand(string command)
		{
		}

        public CommandResult Execute(IBoard board)
        {
            throw new NotImplementedException();
        }

        public CommandResult Validate(IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}

