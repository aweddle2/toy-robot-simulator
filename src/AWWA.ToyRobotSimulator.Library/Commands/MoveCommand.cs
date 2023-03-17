using AWWA.ToyRobotSimulator.Library.Boards;
using AWWA.ToyRobotSimulator.Library.CellContents;
using AWWA.ToyRobotSimulator.Library.Directions;

namespace AWWA.ToyRobotSimulator.Library.Commands
{
    /// <summary>
    /// This command moves an item one cell in the direction it is facing.
    /// </summary>
    public class MoveCommand : ICommand
    {
        /// <summary>
        /// Move the contents of the cell one cell in the direction it is facing.
        /// </summary>
        /// <param name="board">The board that needs to move</param>
        /// <returns></returns>
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
                    newYPosition++;
                    break;
                case AbsoluteDirection.South:
                    newYPosition--;
                    break;
                case AbsoluteDirection.East:
                    newXPosition++;
                    break;
                case AbsoluteDirection.West:
                    newXPosition--;
                    break;
            }

            board.SetCellContents(newXPosition, newYPosition, cellContents);

            CommandResult result = new CommandResult();
            result.Success = true;

            return result;
        }

        /// <summary>
        /// Validate whether this board can make this change
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Determines whether the contents of the cell can move in the direction it wants to move into given the size of the board
        /// </summary>
        /// <param name="board">The board that has the cell that wants to move contents</param>
        /// <param name="cell">The cell containing the item that wants to move</param>
        /// <returns>A boolean on whether the item can move in the cell.</returns>
        /// <exception cref="ArgumentException"></exception>
        private bool CanMove(Board board, Cell cell)
        {
            switch (cell.Contents.Direction)
            {
                case (AbsoluteDirection.North):
                    return (board.Height - 1) > cell.YPosition;
                case (AbsoluteDirection.South):
                    return cell.YPosition > 1;
                case (AbsoluteDirection.East):
                    return (board.Width - 1) > cell.XPosition;
                case (AbsoluteDirection.West):
                    return cell.XPosition > 1;
            }

            throw new ArgumentException("Cell does not have contents or the direction of the contents is not set.", nameof(cell));
        }
    }
}