using System;
using AWWA.ToyRobotSimulator.Library.CellContents;
namespace AWWA.ToyRobotSimulator.Library.Boards
{
	/// <summary>
	/// A Board is made up of a grid of Cells
	/// Each cell is responsible for it;s own location on the board and it's contents, but it is not opinionated on what the contents are
	/// </summary>
	public class Cell
	{
		public ICellContents? Contents;
		public int XPosition;
		public int YPosition;


		public Cell(int x, int y)
		{
			XPosition = x;
			YPosition = y;
		}
	}
}

