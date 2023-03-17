using AWWA.ToyRobotSimulator.Library.Boards;
using AWWA.ToyRobotSimulator.Library.CellContents;
using AWWA.ToyRobotSimulator.Library.Directions;

namespace AWWA.ToyRobotSimulator.Library.Commands
{
    public class MoveCommand : ICommand
    {
        public CommandResult Execute(Board board)
        {
            //Get the robots from the board and the contents of the cell
            IList<Cell> cellsWithContents = board.GetCellsWithContents();

            Cell cell = cellsWithContents[0];
            ICellContents cellContents = cell.Contents;

            //Clear the contents of the cell
            board.ClearCellContents(cell.XPosition, cell.YPosition);

            int newXPosition = cell.XPosition;
            int newYPosition = cell.YPosition;


            switch (cellContents.Direction) {
                case AbsoluteDirection.North:
                    newXPosition++;
                    break;
                case AbsoluteDirection.South:
                    newXPosition--;
                    break;
                case AbsoluteDirection.East:
                    newYPosition++;
                    break;
                case AbsoluteDirection.West:
                    newYPosition--;
                    break;

            }


            board.SetCellContents(newXPosition, newYPosition, cellContents);

            CommandResult result = new CommandResult();
            result.Success = true;

            return result;
        }

        public CommandResult Validate(Board board)
        {
            CommandResult result = new CommandResult();
            result.Success = true;

            //Get the robots from the board.  Can't execute this command if there is not a robot
            IList<Cell> cellsWithContents = board.GetCellsWithContents();
            if (cellsWithContents.Count == 0)
            {
                result.Success = false;
                result.Messages.Add("Command Invalid.  Robot does not exist on the board.");
                return result;
            }

            if (!CanMove(board, cellsWithContents[0])) {
                result.Success = false;
                result.Messages.Add($"Can't move {cellsWithContents[0].Contents.Direction}");
            }

            return result;

        }

        private bool CanMove(Board board, Cell cell)
        {
            //These calcs are -2 to account for the zero indexes and also the fact we need one more cell to allow the robot to move
            switch (cell.Contents.Direction)
            {
                case (AbsoluteDirection.North):
                    return (board.Height - 2) > cell.YPosition;
                case (AbsoluteDirection.South):
                    return cell.YPosition > 1;
                case (AbsoluteDirection.East):
                    return (board.Width - 2) > cell.XPosition;
                case (AbsoluteDirection.West):
                    return cell.XPosition > 1;
            }

            throw new ArgumentException("Cell does not have contents or the direction of the contents is not set.", nameof(cell));

        }

    }
}