using System;
using AWWA.ToyRobotSimulator.Library.Commands;
using Xunit;
namespace AWWA.ToyRobotSimulator.Library.Tests
{
	public class ToyRobotSimulatorClientTests
	{

		[Theory]
		[InlineData(new string[]{ "PLACE 0,0,NORTH", "MOVE", "REPORT" }, "Output: 0,1,NORTH")]
		[InlineData(new string[]{ "PLACE 0,0,NORTH", "LEFT", "REPORT" }, "Output: 0,0,WEST")]
		[InlineData(new string[]{ "PLACE 1,2,EAST", "MOVE", "MOVE", "LEFT", "MOVE", "REPORT" }, "Output: 3,3,NORTH")]
		[InlineData(new string[]{ "PLACE 1,2,EAST", "MOVE", "LEFT", "MOVE", "PLACE 3,1", "MOVE", "REPORT" }, "Output: 3,2,NORTH")]
		public void Samples_From_Acceptance_Criteria(string[] commands, string expectedOutput)
		{
			ToyRobotSimulatorClient client = new ToyRobotSimulatorClient();

			CommandResult result = new CommandResult();

			//run through each command, we only really care about the last one
			foreach (string command in commands)
			{
				result = client.ExecuteCommand(command);
			}

			Assert.True(result.Success);
			Assert.Equal(expectedOutput, result.Messages[0]);


		}

	}
}

