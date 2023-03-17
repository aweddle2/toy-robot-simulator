using System;
using AWWA.ToyRobotSimulator.Library.CellContents;
namespace AWWA.ToyRobotSimulator.Library.Boards
{
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

