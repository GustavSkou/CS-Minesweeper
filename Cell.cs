class Cell
{
    protected int row, column, surroundingMines, surroundingFlags = 0;
    protected string model = "#";
    public Flag flag;

    public string Model
    {
        get { return model; }
    }

    public Cell(int row, int column)
    {
        this.row = row;
        this.column = column;
        flag = new Flag();
    }

    public virtual void Open(Cell[,] mineField)
    {
        mineField[row, column] = !(this is Open) && !flag.State ? 
            new Open(row, column, surroundingFlags, mineField): 
            this;

        Console.WriteLine(surroundingFlags);

        if (mineField[row, column].surroundingMines == 0 || 
            mineField[row, column].surroundingMines == mineField[row, column].surroundingFlags)
        {
            OpenSurroundingCells(this, mineField);
        }
    }

    public virtual void Flag(Cell[,] mineField)
    {
        flag.ChangeState();
        model = model == "#" ? "F" : "#";
        ChangeSurroundingCellsSurroundingFlags(flag.State, mineField);
    }

    protected void OpenSurroundingCells(Cell cell, Cell[,] mineField)
    {
        for (int row = -1; row <= 1; row++)
        {
            if (cell.row + row < 0 || cell.row + row > mineField.GetLength(0)-1)                    // Out of range
            {
                continue;
            }

            for (int column = -1; column <= 1; column++)
            {
                if (cell.column + column < 0 || cell.column + column > mineField.GetLength(1)-1)    // Out of range
                {
                    continue;
                }

                if (mineField[cell.row + row, cell.column + column] is Open)                        // Is Opened
                {
                    continue;
                }

                mineField[cell.row+row, cell.column+column].Open(mineField);
            }
        }
    }

    protected void ChangeSurroundingCellsSurroundingFlags(bool flagState, Cell[,] mineField)
    {
        for (int row = -1; row <= 1; row++)
        {
            if (this.row + row < 0 || this.row + row > mineField.GetLength(0)-1)                    // Out of range
            {
                continue;
            }

            for (int column = -1; column <= 1; column++)
            {
                if (this.column + column < 0 || this.column + column > mineField.GetLength(1)-1)    // Out of range
                {
                    continue;
                }

                if (row == 0 && column == 0)                     // it self
                {
                    continue;
                }

                mineField[this.row + row, this.column + column].surroundingFlags = flagState ? 
                    mineField[this.row + row, this.column + column].surroundingFlags + 1 : 
                    mineField[this.row + row, this.column + column].surroundingFlags - 1;
            }
        }
    }
}