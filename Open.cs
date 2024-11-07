class Open : Cell
{
    public Open (int row, int column, int surroundingFlags, Cell[,] mineField) : base(row, column)
    {
        this.row = row;
        this.column = column;
        this.surroundingFlags = surroundingFlags;
        surroundingMines = SetsurroundingMines(mineField);
        model = surroundingMines.ToString();
    }

    public override void Flag(Cell[,] mineField)
    {
        return;
    }

    private int SetsurroundingMines(Cell[,] mineField)
    {
        int surroundingMinesCounter = 0;

        ProcessSurroundingCells(this, mineField, (surroundingCell) =>
            {
                surroundingMinesCounter = surroundingCell is Mine ? 
                    surroundingMinesCounter + 1 :
                    surroundingMinesCounter;
            }
        );
        
        return surroundingMinesCounter;
    }
}