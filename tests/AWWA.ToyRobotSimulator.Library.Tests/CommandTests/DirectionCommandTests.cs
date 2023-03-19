using System;
using AWWA.ToyRobotSimulator.Library.Boards;
using AWWA.ToyRobotSimulator.Library.CellContents;
using AWWA.ToyRobotSimulator.Library.Commands;
using AWWA.ToyRobotSimulator.Library.Directions;
using Moq;
using Xunit;

namespace AWWA.ToyRobotSimulator.Library.Tests.CommandTests
{
	public class DirectionCommandTests
	{
        [Theory]
        [InlineData(RelativeDirection.Left)]
        [InlineData(RelativeDirection.Right)]
        public void Given_A_Blank_Board_When_A_DirectionCommand_Is_Issued_Then_The_Command_Should_BeIgnored(RelativeDirection direction)
        {
            //Arrange
            Board board = new Board(6, 6);
            DirectionCommand command = new DirectionCommand(direction);

            //Act
            CommandResult result = command.Validate(board);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public void Given_A_Robot_Is_On_The_Board_When_A_DirectionCommand_Is_Issued_Then_The_Command_Should_Execute()
        {
            //Arrange
            Mock<ICellContents> mockCellContents = new Mock<ICellContents>();
            mockCellContents.SetupAllProperties();
            mockCellContents.Object.Direction = AbsoluteDirection.North;

            Board board = new Board(6, 6);
            board.SetCellContents(3, 3, mockCellContents.Object);
            DirectionCommand command = new DirectionCommand(RelativeDirection.Left);

            //Act
            CommandResult result = command.Execute(board);

            //Assert
            Assert.True(result.Success);
            Assert.Equal(AbsoluteDirection.West, board?.GetCellWithContents()?.Contents?.Direction);
        }

    }
}

