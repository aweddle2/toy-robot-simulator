using System;
using AWWA.ToyRobotSimulator.Library.Boards;
using AWWA.ToyRobotSimulator.Library.CellContents;
using AWWA.ToyRobotSimulator.Library.Commands;
using AWWA.ToyRobotSimulator.Library.Directions;
using Moq;
using Xunit;

namespace AWWA.ToyRobotSimulator.Library.Tests.CommandTests
{
	public class MoveCommandTests
	{
        [Fact]
        public void Given_A_Blank_Board_When_A_MoveCommand_Is_Issued_Then_The_Command_Should_BeIgnored()
        {
            //Arrange
            Board board = new Board(6, 6);
            MoveCommand command = new MoveCommand();

            //Act
            CommandResult result = command.Validate(board);

            //Assert
            Assert.False(result.Success);
        }

        [Theory]
        [InlineData(3,3,AbsoluteDirection.North,true)]
        [InlineData(3,3,AbsoluteDirection.South,true)]
        [InlineData(3,3,AbsoluteDirection.East,true)]
        [InlineData(3,3,AbsoluteDirection.West,true)]
        [InlineData(3,5,AbsoluteDirection.North,false)]
        [InlineData(3,0,AbsoluteDirection.South,false)]
        [InlineData(5,3,AbsoluteDirection.East, false)]
        [InlineData(0,3,AbsoluteDirection.West, false)]
        public void Given_A_Robot_Is_On_The_Board_When_A_MoveCommand_Is_Issued_Then_The_Command_Should_Validate(int x, int y, AbsoluteDirection absoluteDirection, bool expectedResult)
        {
            //Arrange
            Mock<ICellContents> mockCellContents = new Mock<ICellContents>();
            mockCellContents.SetupAllProperties();
            mockCellContents.Object.Direction = absoluteDirection;

            Board board = new Board(6, 6);
            board.SetCellContents(x, y, mockCellContents.Object);
            MoveCommand command = new MoveCommand();

            //Act
            CommandResult result = command.Validate(board);

            //Assert
            Assert.Equal(expectedResult,result.Success);
        }

        [Theory]
        [InlineData(3, 3, AbsoluteDirection.North, 3, 4)]
        [InlineData(3, 3, AbsoluteDirection.South, 3, 2)]
        [InlineData(3, 3, AbsoluteDirection.East, 4, 3)]
        [InlineData(3, 3, AbsoluteDirection.West, 2, 3)]
        public void Given_A_Robot_Is_On_The_Board_When_A_MoveCommand_Is_Issued_Then_The_Command_Should_Execute(int x, int y, AbsoluteDirection absoluteDirection, int expectedX, int expectedY)
        {
            //Arrange
            Mock<ICellContents> mockCellContents = new Mock<ICellContents>();
            mockCellContents.SetupAllProperties();
            mockCellContents.Object.Direction = absoluteDirection;

            Board board = new Board(6, 6);
            board.SetCellContents(x, y, mockCellContents.Object);
            MoveCommand command = new MoveCommand();

            //Act
            CommandResult result = command.Execute(board);

            //Assert
            Assert.True(result.Success);
            Assert.Equal(expectedX, board.GetCellsWithContents()[0].XPosition);
            Assert.Equal(expectedY, board.GetCellsWithContents()[0].YPosition);
        }

    }
}

