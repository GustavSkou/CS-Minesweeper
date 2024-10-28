class Open : Cell
{
    private int surroundingMines;
    
    public Open (int row, int column, Cell[,] mineField) : base(row, column)
    {
        this.row = row;
        this.column = column;
        surroundingMines = SetsurroundingMines(mineField);
    }

    public override string GetChar()
    {
        return surroundingMines.ToString();
    }

    private int SetsurroundingMines(Cell[,] mineField)
    {
        int surroundingMinesCounter = 0;
        for (int row = -1; row <= 1; row++)
        {
            if (this.row + row < 0 || this.row + row > mineField.GetLength(0)-1)
            {
                continue;
            }

            for (int column = -1; column <= 1; column++)
            {
                if (this.column + column < 0 || this.column + column > mineField.GetLength(1)-1)
                {
                    continue;
                }

                if (mineField[this.row + row, this.column + column] is Mine)
                {
                    surroundingMinesCounter++;
                }
            }
        }

        if (surroundingMines == 0)
        {
            for (int row = -1; row <= 1; row++)
            {
                if (this.row + row < 0 || this.row + row > mineField.GetLength(0)-1)
                {
                    continue;
                }

                for (int column = -1; column <= 1; column++)
                {
                    if (this.column + column < 0 || this.column + column > mineField.GetLength(1)-1)
                    {
                        continue;
                    }

                    if (!(mineField[this.row + row, this.column + column] is Open))
                    {
                        mineField[this.row + row, this.column + column].Open(mineField);  
                    }
                }
            }    
        }

        return surroundingMinesCounter;
    }
}