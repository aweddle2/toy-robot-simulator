namespace AWWA.ToyRobotSimulator.Library.Commands
{
    public class CommandResult
    {
        public bool Success;
        public IList<string> Messages;

        public CommandResult()
        {
            Messages = new List<string>();
        }
    }
}