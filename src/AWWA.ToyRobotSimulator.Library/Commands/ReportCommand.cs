using AWWA.ToyRobotSimulator.Library.Boards;

namespace AWWA.ToyRobotSimulator.Library.Commands
{
    public class ReportCommand : ICommand
    {
        public CommandResult Execute(Board board)
        {
            CommandResult result = new CommandResult();

            //Get the robots from the board
            IList<Cell> cellsWithContents = board.GetCellsWithContents();
            if (cellsWithContents.Count > 0)
            {
                result.Success = true;
                result.Messages.Add($"Output: {cellsWithContents[0].XPosition},{cellsWithContents[0].YPosition},{cellsWithContents[0].Contents.Direction.ToString().ToUpper()}");
            }
            else
            {
                result.Messages.Add($"Output: There are no Robots on the board.");
            }

            return result;
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
    }
}