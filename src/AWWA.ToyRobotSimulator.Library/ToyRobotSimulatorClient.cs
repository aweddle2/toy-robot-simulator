using System;
using AWWA.ToyRobotSimulator.Library.Boards;
using AWWA.ToyRobotSimulator.Library.CellContents;
using AWWA.ToyRobotSimulator.Library.Commands;

namespace AWWA.ToyRobotSimulator.Library
{
	public class ToyRobotSimulatorClient
	{
		private Board _board;
		private CommandFactory _factory;

        /// <summary>
        /// This constructor will create a new board with a 6 x 6 grid
        /// </summary>
        public ToyRobotSimulatorClient()
		{
			_board = new Board(6, 6);
            _factory = new CommandFactory();
		}

		/// <summary>
		/// Executes a command provided
		/// </summary>
		/// <param name="argument">a command to run</param>
		/// <returns>The result and any feedback messages for the user who created the command.</returns>
		public CommandResult ExecuteCommand(string argument)
		{
			//Get the command from the factory
			ICommand command;

            try
			{
				command = _factory.GetCommand(argument);
			}
			catch (ArgumentException ae)
			{
				CommandResult errorResult = new CommandResult();
				errorResult.Success = false;
				errorResult.Messages.Add(ae.Message);
				return errorResult;
			}

			//Validate the command
			CommandResult validationResult = command.Validate(_board);

            if (!validationResult.Success)
			{
				return validationResult;
			}

			//Execute the command
			return command.Execute(_board);
		}
	}
}

