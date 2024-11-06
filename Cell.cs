class Cell
{
    protected int row, column;
    private string cellModel = "#";
    public bool isOpen = false;
    protected bool isFlag = false;
    protected int surroundingMines;

    public Cell(int row, int column)
    {
        this.row = row;
        this.column = column;
    }

    public virtual string GetChar()
    {
        return cellModel;
    }

    public virtual void Open(Cell[,] mineField)
    {
        if (this is Open)
        {
            return;
        }

        mineField[this.row, this.column] = new Open(this.row, this.column, mineField);
        if (mineField[this.row, this.column].surroundingMines == 0)
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

                if (mineField[cell.row + row, cell.column + column] is Open)
                {
                    continue;
                }

                mineField[cell.row+row, cell.column+column].Open(mineField);
            }
        }
    }
}