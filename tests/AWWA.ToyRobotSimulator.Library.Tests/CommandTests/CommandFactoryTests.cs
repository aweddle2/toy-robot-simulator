using System;
using Xunit;
using AWWA.ToyRobotSimulator.Library.Commands;
namespace AWWA.ToyRobotSimulator.Library.Tests.CommandTests
{
    public class CommandFactoryTests
    {
        [Theory]
        [InlineData("PLACE 0,0,NORTH", typeof(PlaceCommand))]
        [InlineData("MOVE", typeof(MoveCommand))]
        [InlineData("LEFT", typeof(DirectionCommand))]
        [InlineData("RIGHT", typeof(DirectionCommand))]
        [InlineData("REPORT", typeof(ReportCommand))]
        [InlineData("place 0,0,north", typeof(PlaceCommand))]
        [InlineData("move", typeof(MoveCommand))]
        [InlineData("left", typeof(DirectionCommand))]
        [InlineData("right", typeof(DirectionCommand))]
        [InlineData("report", typeof(ReportCommand))]

        public void Given_A_Valid_Input_When_That_Command_Is_Parsed_Return_An_ICommand(string command, Type expectedCommandType)
        {
            CommandFactory commandFactory = new CommandFactory();

            ICommand result = commandFactory.GetCommand(command);

            Assert.IsType(expectedCommandType, result);
        }

        [Fact]
        public void Given_An_Invalid_Input_When_That_Command_Is_Parsed_AnExceptionShouldBeThrown()
        {
            CommandFactory commandFactory = new CommandFactory();

            Assert.Throws<ArgumentException>(() => commandFactory.GetCommand("InValIdComMaNd"));
        }
    }
}

