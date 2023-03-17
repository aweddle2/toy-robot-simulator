using System;
using AWWA.ToyRobotSimulator.Library.Directions;

namespace AWWA.ToyRobotSimulator.Library.CellContents
{
	public class Robot : ICellContents
	{
		public AbsoluteDirection? Direction { get; set; }

        public Robot()
		{
		}
    }
}

