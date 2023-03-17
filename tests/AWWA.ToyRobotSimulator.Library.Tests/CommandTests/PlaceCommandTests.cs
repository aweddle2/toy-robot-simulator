using System;
using AWWA.ToyRobotSimulator.Library.Boards;
using AWWA.ToyRobotSimulator.Library.Commands;
using Xunit;
using Moq;
using AWWA.ToyRobotSimulator.Library.CellContents;
using AWWA.ToyRobotSimulator.Library.Directions;

namespace AWWA.ToyRobotSimulator.Library.Tests.CommandTests
{
	public class PlaceCommandTests
	{
        [Theory]
        [InlineData("PLACE", false, false)]
        [InlineData("PLACE 0", false, false)]
        [InlineData("PLACE 0,", false, false)]
        [InlineData("PLACE,0,0", false, false)]
        [InlineData("PLACE notANumber,0", false, false)]
        [InlineData("PLACE notANumber,notANumber", false, false)]
        [InlineData("PLACE 1,1,NORTH", false, true)]
        [InlineData("PLACE 1,1,NORTH", true, true)]
        [InlineData("PLACE 1,1", false, false)]
        [InlineData("PLACE 1,1", true, true)]
        [InlineData("PLACE 8,8", false, false)]
        [InlineData("PLACE 8,8,NORTH", false, false)]
        public void PlaceCommand_Validation_Tests(string command, bool existingRobot, bool expectedResult)
        {
            //Arrange
            Board board = new Board(6,6);

            if (existingRobot)
            {
                Mock<ICellContents> mockCellContents = new Mock<ICellContents>();
                mockCellContents.SetupAllProperties();
                mockCellContents.Object.Direction = AbsoluteDirection.North;
                board.SetCellContents(3, 3, mockCellContents.Object);
            }

            PlaceCommand placeCommand = new PlaceCommand(command);

            //Act
            CommandResult result = placeCommand.Validate(board);

            //Assert
            Assert.Equal(expectedResult, result.Success);
        }

        [Theory]
        [InlineData("PLACE 1,1", false, false)]
        [InlineData("PLACE 1,1", true, true)]
        [InlineData("PLACE 1,1,NORTH", false, true)]
        [InlineData("PLACE 1,1,NORTH", true, true)]
        [InlineData("PLACE 8,8,NORTH", true, false)]
        [InlineData("PLACE 8,8,NORTH", false, false)]
        public void PlaceCommand_Execute_Tests(string command, bool existingRobot, bool expectedResult)
        {
            //Arrange
            Board board = new Board(6, 6);

            if (existingRobot)
            {
                Mock<ICellContents> mockCellContents = new Mock<ICellContents>();
                mockCellContents.SetupAllProperties();
                mockCellContents.Object.Direction = AbsoluteDirection.North;
                board.SetCellContents(3, 3, mockCellContents.Object);
            }

            PlaceCommand placeCommand = new PlaceCommand(command);

            //Act
            CommandResult result = placeCommand.Execute(board);

            //Assert
            Assert.Equal(expectedResult, result.Success);
        }

    }
}

