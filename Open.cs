class Open : Cell
{
    public Open (int row, int column, Cell[,] mineField) : base(row, column)
    {
        this.row = row;
        this.column = column;
        surroundingMines = SetsurroundingMines(mineField);
        model = surroundingMines.ToString();
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

                if (row == 0 && column == 0)
                {
                    continue;
                }

                if (mineField[this.row + row, this.column + column] is Mine)
                {
                    surroundingMinesCounter++;
                }       
            }
        }

        return surroundingMinesCounter;
    }
}