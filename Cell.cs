class Cell
{
    protected int row, column, surroundingMines;
    protected string model = "#";

    public string Model
    {
        get { return model; }
    }

    public Cell(int row, int column)
    {
        this.row = row;
        this.column = column;
    }

    public virtual void Open(Cell[,] mineField)
    {
        if (this is Open)
        {
            return;
        }

        mineField[row, column] = new Open(row, column, mineField);
        if (mineField[row, column].surroundingMines == 0)
        {
            OpenSurroundingCells(this, mineField);
        }
    }

    public void OpenSurroundingCells(Cell cell, Cell[,] mineField)
    {
        for (int row = -1; row <= 1; row++)
        {
            if (cell.row + row < 0 || cell.row + row > mineField.GetLength(0)-1) // Out of range
            {
                continue;
            }

            for (int column = -1; column <= 1; column++)
            {
                if (cell.column + column < 0 || cell.column + column > mineField.GetLength(1)-1) // Out of range
                {
                    continue;
                }

                if (mineField[cell.row + row, cell.column + column] is Open) // Is Opened
                {
                    continue;
                }

                mineField[cell.row+row, cell.column+column].Open(mineField);
            }
        }
    }
}