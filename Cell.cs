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
        ProcessSurroundingCells(cell, mineField, (surroundingCell) => 
            {
                if (!(surroundingCell is Open))
                {
                    surroundingCell.Open(mineField);
                }
            }
        );
    }

    protected void ChangeSurroundingCellsSurroundingFlags(bool flagState, Cell[,] mineField)
    {
        ProcessSurroundingCells(this, mineField, (surroundingCell) => 
            {
                surroundingCell.surroundingFlags = flagState ? 
                    surroundingCell.surroundingFlags + 1:
                    surroundingCell.surroundingFlags - 1;
            }
        );
    }

    protected void ProcessSurroundingCells(Cell cell, Cell[,] mineField, Action<Cell> action)
    {
        for (int row = -1; row <= 1; row++)
        {
            if (cell.row + row < 0 || cell.row + row > mineField.GetLength(0) - 1) // Out of range
            {
                continue;
            }

            for (int column = -1; column <= 1; column++)
            {
                if (cell.column + column < 0 || cell.column + column > mineField.GetLength(1) - 1 ||    // Out of range
                    (row == 0 && column == 0))                                                          // It self                                 
                {
                    continue;
                }

                action(mineField[cell.row + row, cell.column + column]);
            }
        }
    }
}