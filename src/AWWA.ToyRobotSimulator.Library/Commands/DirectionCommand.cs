using AWWA.ToyRobotSimulator.Library.Boards;
using AWWA.ToyRobotSimulator.Library.CellContents;
using AWWA.ToyRobotSimulator.Library.Directions;

namespace AWWA.ToyRobotSimulator.Library.Commands
{
    /// <summary>
    /// LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
    /// </summary>
    public class DirectionCommand : ICommand
    {
        private RelativeDirection _relativeDirection;

        public DirectionCommand(RelativeDirection direction)
        {
            _relativeDirection = direction;
        }

        public CommandResult Validate(Board board)
        {
            CommandResult result = new CommandResult();
            result.Success = true;

            //Get the robots from the board
            IList<Cell> cellsWithContents = board.GetCellsWithContents();
            if (cellsWithContents.Count == 0)
            {
                result.Success = false;
                result.Messages.Add("Command Invalid.  Robot does not exist on the board.");
            }

            return result;
        }


        public CommandResult Execute(Board board)
        {
            //Get the robots from the board
            IList<Cell> cellsWithContents = board.GetCellsWithContents();

            Cell cell = cellsWithContents[0];
            ICellContents cellContents = cell.Contents;
            cellContents.Direction = cellContents.Direction?.Rotate(_relativeDirection);

            board.SetCellContents(cell.XPosition, cell.YPosition, cellContents);

            CommandResult result = new CommandResult();
            result.Success = true;

            return result;
        }

    }
}