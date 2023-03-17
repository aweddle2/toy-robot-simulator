namespace AWWA.ToyRobotSimulator.Library.Commands
{
    /// <summary>
    /// Resulting object from all commands
    /// </summary>
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