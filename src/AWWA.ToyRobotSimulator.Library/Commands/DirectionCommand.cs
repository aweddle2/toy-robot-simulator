using AWWA.ToyRobotSimulator.Library.Boards;

namespace AWWA.ToyRobotSimulator.Library.Commands
{
    public class DirectionCommand : ICommand
    {
        public DirectionCommand(string direction)
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