using AWWA.ToyRobotSimulator.Library.Boards;

namespace AWWA.ToyRobotSimulator.Library.Commands
{
    /// <summary>
    /// This command gets the board to report on the item it contains.
    /// </summary>
    public class ReportCommand : ICommand
    {
        /// <summary>
        /// Run the report on the item on the board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public CommandResult Execute(Board board)
        {
            CommandResult result = new CommandResult();

            //Get the robots from the board
            Cell? cellWithContents = board.GetCellWithContents();
            if (cellWithContents != null)
            {
                result.Success = true;
                result.Messages.Add($"Output: {cellWithContents.XPosition},{cellWithContents.YPosition},{cellWithContents.Contents?.Direction?.ToString().ToUpper()}");
            }
            else
            {
                result.Messages.Add($"Output: There are no Robots on the board.");
            }

            return result;
        }

        /// <summary>
        /// Validate whether the board actually has any items on it to report on.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public CommandResult Validate(Board board)
        {
            CommandResult result = new CommandResult();
            result.Success = true;

            //Get the robots from the board
            Cell? cellWithContents = board.GetCellWithContents();
            if (cellWithContents == null)
            {
                result.Success = false;
                result.Messages.Add("Command Invalid.  Robot does not exist on the board.");
            }

            return result;
        }
    }
}