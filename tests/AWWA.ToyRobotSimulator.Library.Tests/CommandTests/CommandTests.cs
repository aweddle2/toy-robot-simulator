using System;
using Xunit;
using AWWA.ToyRobotSimulator.Library.Commands;
namespace AWWA.ToyRobotSimulator.Library.Tests.CommandTests
{
	public class CommandTests
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

        public void Given_A_Valid_Command_When_That_Command_Is_Parsed_Return_An_I_Command(string command, Type commandType)
		{
			CommandFactory commandFactory = new CommandFactory();

			ICommand result = commandFactory.GetCommand(command);

			Assert.IsType(commandType, result);
		}

        [Fact]
        public void Given_An_Invalid_Command_When_That_Command_Is_Parsed_AnExceptionShouldBeThrown()
        {
            CommandFactory commandFactory = new CommandFactory();

            Assert.Throws<ArgumentException>(() => commandFactory.GetCommand("InValIdComMaNd"));
        }
    }


}

