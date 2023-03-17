using System;
using AWWA.ToyRobotSimulator.Library.Boards;
using AWWA.ToyRobotSimulator.Library.CellContents;
using AWWA.ToyRobotSimulator.Library.Directions;

namespace AWWA.ToyRobotSimulator.Library.Commands
{
	public class PlaceCommand : ICommand
	{
        private int _xPosition;
        private int _yPosition;
        private ICellContents _cellContents;

		public PlaceCommand(string command)
        {
            //Maybe in the future this command will support more Cell Content Types, but for now it's all robots
            _cellContents = new Robot();

            ValidateCommand(command);
		}

        private void ValidateCommand(string command)
        {
            //First split the command by space to get the parts we are interested in
            string[] commandParts = command.Split(' ');
            if (!commandParts.Length.Equals(2))
            {
                throw new ArgumentException($"Command '{command}' is not a valid PLACE command.  Usage 'PLACE X,Y,DIRECTION'.", nameof(command));
            }

            //and then by comma to get the 3 remaining parts
            commandParts = commandParts[1].Split(',');
            if (commandParts.Length < 2)
            {
                throw new ArgumentException($"Command '{command}' is not a valid PLACE command.  Usage 'PLACE X,Y,DIRECTION'.", nameof(command));
            }

            int x;
            if (int.TryParse(commandParts[0], out x))
            {
                _xPosition = x;
            }
            else
            {
                throw new ArgumentException($"Command '{command}' is not a valid PLACE command.  X Coordinate not a number.", nameof(command));
            }

            int y;
            if (int.TryParse(commandParts[1], out y))
            {
                _yPosition = y;
            }
            else
            {
                throw new ArgumentException($"Command '{command}' is not a valid PLACE command.  Y Coordinate not a number.", nameof(command));
            }


            //This does not need to throw, because
            //"Once the robot is on the table, subsequent PLACE commands could leave out the direction and only provide the coordinates"
            AbsoluteDirection dir;
            if (commandParts.Length == 3 && Enum.TryParse(commandParts[2], true, out dir))
            {

                _cellContents.Direction = dir;
            }
        }


        public CommandResult Execute(Board board)
        {
            CommandResult result = new CommandResult();
            result.Success = true;

            //Get any existing Robot from the board.  
            IList<Cell> cellsWithContents = board.GetCellsWithContents();

            ICellContents? cellContents;

            //If there is a robot on the board clear it
            if (cellsWithContents.Count > 0)
            {
                Cell cell = cellsWithContents[0];
                cellContents = cell.Contents;

                //Grab the Direction from the robot already on the board if this command has no direction
                if (_cellContents.Direction == null)
                {
                    _cellContents.Direction = cell.Contents?.Direction;
                }

                bool clearCellResult = board.ClearCellContents(cell.XPosition, cell.YPosition);
                if (!clearCellResult)
                {
                    result.Success = false;
                    result.Messages.Add("Could not move the robot from it's old cell.");
                }
            }
            else if (_cellContents.Direction == null)
            {
                //Can't set the direction so fail
                result.Success = false;
                result.Messages.Add("Could not set the robots direction.");

            }

            //Move the Robot to the new Cell
            bool setCellResult = board.SetCellContents(_xPosition, _yPosition, _cellContents);
            if (!setCellResult)
            {
                result.Success = false;
                result.Messages.Add("Could not move the robot from it's new cell.");
            }

            return result; 
        }

        public CommandResult Validate(Board board)
        {

            CommandResult result = new CommandResult();
            result.Success = true;

            //The robot is free to roam around the surface of the table, but must be prevented from falling to destruction
            //Any movement that would result in this must be prevented, however further valid movement commands must still be allowed.
            bool isCellInRange = board.IsCellValid(_xPosition, _yPosition);
            if (!isCellInRange)
            {
                result.Success = false;
                result.Messages.Add("Cell is outside of the board.");
            }

            //If the PLACE command has not specified a DIRECTION then we need to ensure there is a robot on the board to get the direction from
            if (_cellContents.Direction == null)
            {
                //Get the robots from the board
                IList<Cell> cellsWithContents = board.GetCellsWithContents();
                if (cellsWithContents.Count == 0)
                {
                    result.Success = false;
                    result.Messages.Add("Command Invalid.  Must specify the direction for the first PLACE command.");
                }
            }

            return result;
        }
    }
}

