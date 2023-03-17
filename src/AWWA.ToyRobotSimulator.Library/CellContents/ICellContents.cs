using System;
using AWWA.ToyRobotSimulator.Library.Directions;

namespace AWWA.ToyRobotSimulator.Library.CellContents
{
	public interface ICellContents
	{
		AbsoluteDirection? Direction { get; set; }
	}
}

