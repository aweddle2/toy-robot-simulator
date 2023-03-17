using AWWA.ToyRobotSimulator.Library.Boards;
using AWWA.ToyRobotSimulator.Library.Directions;

namespace AWWA.ToyRobotSimulator.Library.Commands
{
    public class DirectionCommand : ICommand
    {
        private RelativeDirection _relativeDirection;

        public DirectionCommand(RelativeDirection direction)
        {
            _relativeDirection = direction;
        }

        public CommandResult Execute(Board board)
        {
            throw new NotImplementedException();
        }
    }
}