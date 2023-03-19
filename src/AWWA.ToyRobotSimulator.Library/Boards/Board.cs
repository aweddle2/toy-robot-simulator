using System;
using AWWA.ToyRobotSimulator.Library.CellContents;
namespace AWWA.ToyRobotSimulator.Library.Boards
{
	/// <summary>
	/// This is the board that items can be added to.
	/// This class also holds methods for clearing and settings items in a cell.
	/// </summary>
	public class Board
	{
        private IList<Cell> _cells;

		public int Width { get; private set; }
		public int Height { get; private set; }

		public Board(int width, int height)
		{
			Width = width;
			Height = height;
			_cells = new List<Cell>();
			InitializeBoard();
		}

		private void InitializeBoard()
		{
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					_cells.Add(new Cell(i, j));
				}
			}
		}

		public Cell? GetCellWithContents()
		{
			return _cells.Where(c => c.Contents != null).FirstOrDefault();
		}

        public bool SetCellContents(int x, int y, ICellContents contents)
        {
            //If the coordinates are bigger than the board, just return
            if (!IsCellValid(x, y))
            {
                return false;
            }

            //Set the contents of the cell
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
			return (x < Width & y < Height);
        }
	}
}

