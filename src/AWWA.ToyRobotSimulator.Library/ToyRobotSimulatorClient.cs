using System;
using AWWA.ToyRobotSimulator.Library.Boards;
using AWWA.ToyRobotSimulator.Library.CellContents;
using AWWA.ToyRobotSimulator.Library.Commands;

namespace AWWA.ToyRobotSimulator.Library
{
	public class ToyRobotSimulatorClient
	{
		public Board Board;
		public Robot Robot;

        /// <summary>
        /// This constructor will create a new board with a 6 x 6 grid
        /// </summary>
        public ToyRobotSimulatorClient()
		{
			Board = new Board(6, 6);
			Robot = new Robot();
		}
	}
}

