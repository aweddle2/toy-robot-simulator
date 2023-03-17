using System;
using AWWA.ToyRobotSimulator.Library.Boards;
using AWWA.ToyRobotSimulator.Library.CellContents;
using AWWA.ToyRobotSimulator.Library.Commands;

namespace AWWA.ToyRobotSimulator.Library
{
	public class ToyRobotSimulatorClient
	{
		private Board _board;
		private Robot _robot;
		private CommandFactory _factory;

        /// <summary>
        /// This constructor will create a new board with a 6 x 6 grid
        /// </summary>
        public ToyRobotSimulatorClient()
		{
			_board = new Board(6, 6);
			_robot = new Robot();
            _factory = new CommandFactory();
		}

		public CommandResult ExecuteCommand(string argument)
		{
			ICommand command = _factory.GetCommand(argument);

			CommandResult validationResult = command.Validate(_board);

            if (!validationResult.Success)
			{
				return validationResult;
			}

			return command.Execute(_board);
		}
	}
}

