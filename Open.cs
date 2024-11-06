class Open : Cell
{
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

    /*private void OpenSurroundingCells(List<Cell> cellsToOpen, Cell[,] mineField)
    {
        for (int row = -1; row <= 1; row++)
        {
            if (this.row + row < 0 || this.row + row > mineField.GetLength(0)-1) //Out of bounds
            {
                continue;
            }

            for (int column = -1; column <= 1; column++)
            {
                if (this.column + column < 0 || this.column + column > mineField.GetLength(1)-1) //Out of bounds
                {
                    continue;
                }

                if (row == 0 && column == 0) //it self
                {
                    continue;
                }

                if (mineField[this.row + row, this.column + column] is Open)
                {
                    continue;
                }

                if (mineField[this.row + row, this.column + column].isOpen)
                {
                    continue;
                }

                mineField[this.row + row, this.column + column].isOpen = true;
                cellsToOpen.Add(mineField[this.row + row, this.column + column]);
            }
        }

        for (int index = 0; index < cellsToOpen.Count(); index++)
        {
            cellsToOpen[index].Open(mineField);
        }
    }*/
}