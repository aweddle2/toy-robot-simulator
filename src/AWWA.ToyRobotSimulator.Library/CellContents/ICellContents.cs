using System;
using AWWA.ToyRobotSimulator.Library.Directions;

namespace AWWA.ToyRobotSimulator.Library.CellContents
{
	/// <summary>
	/// This interface is for items that go into a cell on a board.
	/// </summary>
	public interface ICellContents
	{
		AbsoluteDirection? Direction { get; set; }
	}
}

