using System;
using AWWA.ToyRobotSimulator.Library.Boards;
using AWWA.ToyRobotSimulator.Library.Commands;
using Xunit;
using Moq;
using AWWA.ToyRobotSimulator.Library.CellContents;

namespace AWWA.ToyRobotSimulator.Library.Tests.CommandTests
{
	public class PlaceCommandTests
	{
        [Theory]
        [InlineData("PLACE")]
        [InlineData("PLACE 0")]
        [InlineData("PLACE 0,")]
        [InlineData("PLACE,0,0")]
        [InlineData("PLACE notANumber,0")]
        [InlineData("PLACE notANumber,notANumber")]
        public void Given_An_Invalid_Input_When_That_Command_Is_Parsed_AnExceptionShouldBeThrown(string command)
        {
            CommandFactory commandFactory = new CommandFactory();

            Assert.Throws<ArgumentException>(() => commandFactory.GetCommand(command));
        }

        [Fact]
        public void Given_A_Blank_Board_When_A_PlaceCommand_Is_Issued_Then_The_Command_Should_Validate()
        {
            //Arrange
            Board board = new Board(6,6);
            PlaceCommand placeCommand = new PlaceCommand("PLACE 1,1,NORTH");

            //Act
            CommandResult result = placeCommand.Validate(board);

            //Assert
            Assert.True(result.Success);
        }

        [Fact]
        public void Given_A_Blank_Board_When_A_PlaceCommand_Is_Issued_Without_A_Direction_Then_The_Command_Should_Fail_Validation()
        {
            //Arrange
            Board board = new Board(6, 6);
            PlaceCommand placeCommand = new PlaceCommand("PLACE 1,1");

            //Act
            CommandResult result = placeCommand.Validate(board);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public void Given_A_Blank_Board_When_A_PlaceCommand_Is_Issued_Issued_Outside_The_Board_Then_The_Command_Should_Fail()
        {
            //Arrange
            Board board = new Board(6, 6);
            PlaceCommand placeCommand = new PlaceCommand("PLACE 8,8");

            //Act
            CommandResult result = placeCommand.Validate(board);

            //Assert
            Assert.False(result.Success);
        }


        [Fact]
		public void Given_A_Robot_Is_On_The_Board_When_A_PlaceCommand_Is_Issued_Then_The_Command_Should_Validate()
		{
            //Arrange
            Mock<ICellContents> mockCellContents = new Mock<ICellContents>();

            Board board = new Board(6, 6);
            board.SetCellContents(3, 3, mockCellContents.Object);
            PlaceCommand placeCommand = new PlaceCommand("PLACE 1,1,NORTH");

            //Act
            CommandResult result = placeCommand.Validate(board);

            //Assert
            Assert.True(result.Success);
        }

        [Fact]
        public void Given_A_Robot_Is_On_The_Board_When_A_PlaceCommand_Is_Issued_Outside_The_Board_Then_The_Command_Should_Fail()
        {
            //Arrange
            Mock<ICellContents> mockCellContents = new Mock<ICellContents>();

            Board board = new Board(6, 6);
            board.SetCellContents(3, 3, mockCellContents.Object);
            PlaceCommand placeCommand = new PlaceCommand("PLACE 8,8,NORTH");

            //Act
            CommandResult result = placeCommand.Validate(board);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public void Given_A_Blank_Board_When_A_PlaceCommand_With_No_Direction_Is_Issued_Then_The_Command_Should_Fail()
        {
            //Arrange
            Board board = new Board(6, 6);
            PlaceCommand placeCommand = new PlaceCommand("PLACE 1,1");

            //Act
            CommandResult result = placeCommand.Execute(board);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public void Given_A_Robot_Is_On_The_Board_When_A_PlaceCommand_Is_Issued_Then_The_Command_Should_Execute()
        {
            //Arrange
            Mock<ICellContents> mockCellContents = new Mock<ICellContents>();

            Board board = new Board(6, 6);
            board.SetCellContents(3, 3, mockCellContents.Object);
            PlaceCommand placeCommand = new PlaceCommand("PLACE 1,1,NORTH");

            //Act
            CommandResult result = placeCommand.Execute(board);

            //Assert
            Assert.True(result.Success);
        }

    }
}

