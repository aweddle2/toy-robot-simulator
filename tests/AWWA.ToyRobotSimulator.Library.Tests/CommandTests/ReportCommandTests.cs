using System;
using AWWA.ToyRobotSimulator.Library.Boards;
using AWWA.ToyRobotSimulator.Library.CellContents;
using AWWA.ToyRobotSimulator.Library.Commands;
using AWWA.ToyRobotSimulator.Library.Directions;
using Moq;
using Xunit;

namespace AWWA.ToyRobotSimulator.Library.Tests.CommandTests
{
	public class ReportCommandTests
	{
        [Fact]
        public void Given_A_Blank_Board_When_A_ReportCommand_Is_Issued_Then_The_Command_Should_BeIgnored()
        {
            //Arrange
            Board board = new Board(6, 6);
            ReportCommand command = new ReportCommand();

            //Act
            CommandResult result = command.Validate(board);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public void Given_A_Robot_Is_On_The_Board_When_A_ReportCommand_Is_Issued_Then_The_Command_Should_Validate()
        {
            //Arrange
            Mock<ICellContents> mockCellContents = new Mock<ICellContents>();
            mockCellContents.SetupAllProperties();
            mockCellContents.Object.Direction = AbsoluteDirection.North;

            Board board = new Board(6, 6);
            board.SetCellContents(3, 3, mockCellContents.Object);
            ReportCommand command = new ReportCommand();

            //Act
            CommandResult result = command.Validate(board);

            //Assert
            Assert.True(result.Success);
        }

        [Fact]
        public void Given_A_Robot_Is_On_The_Board_When_A_ReportCommand_Is_Issued_Then_The_Command_Should_Execute()
        {
            //Arrange
            Mock<ICellContents> mockCellContents = new Mock<ICellContents>();
            mockCellContents.SetupAllProperties();
            mockCellContents.Object.Direction = AbsoluteDirection.North;

            Board board = new Board(6, 6);
            board.SetCellContents(0, 1, mockCellContents.Object);
            ReportCommand command = new ReportCommand();

            //Act
            CommandResult result = command.Execute(board);

            //Assert
            Assert.True(result.Success);
            Assert.Equal("Output: 0,1,NORTH", result.Messages[0]);
        }
    }
}

