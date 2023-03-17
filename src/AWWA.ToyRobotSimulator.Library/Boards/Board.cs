using System;
using AWWA.ToyRobotSimulator.Library.CellContents;
namespace AWWA.ToyRobotSimulator.Library.Boards
{
	public class Board
	{
		private int _width;
		private int _height;
		private IList<Cell> _cells;

		public Board(int width, int height)
		{
			_width = width;
			_height = height;
			_cells = new List<Cell>();
			InitializeBoard();
		}

		private void InitializeBoard()
		{
			for (int i = 0; i < _width; i++)
			{
				for (int j = 0; j < _height; j++)
				{
					_cells.Add(new Cell(i, j));
				}
			}
		}

		public IList<Cell> GetCellsWithContents()
		{
			return _cells.Where(c => c.Contents != null).ToList();
		}

        public bool SetCellContents(int x, int y, ICellContents contents)
        {
            //If the coordinates are bigger than the board, just return
            if (!IsCellValid(x, y))
            {
                return false;
            }

            //Clear the contents of the cell
            Cell cell = _cells.First(c => c.XPosition.Equals(x) && c.YPosition.Equals(y));
            cell.Contents = contents;
            return true;

        }


        public bool ClearCellContents(int x, int y)
		{
			//If the coordinates are bigger than the board, just return
			if (!IsCellValid(x,y))
			{
				return false;
			}

			//Clear the contents of the cell
			Cell cell = _cells.First(c => c.XPosition.Equals(x) && c.YPosition.Equals(y));
			cell.Contents = null;

			return true;

		}

        /// <summary>
        /// Ensure the cell being written to or read from is in range
        /// </summary>
        /// <param name="x">zero based index for the x axis</param>
        /// <param name="y">zero based index for the y axis</param>
        public bool IsCellValid(int x, int y)
		{
			return (x < _width & y < _height);
        }
	}
}

