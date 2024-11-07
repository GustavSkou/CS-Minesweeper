class Mine : Cell
{
    private bool isExploded = false;
    public Mine(int row, int column) : base(row, column)
    {
        this.row = row;
        this.column = column;
    }

    public override void Open(Cell[,] minefield)
    {
        if (flag.State)
        {
            return;
        }
        isExploded = true;
        model = "¤";
        // END GAME //
    }

    public override void Flag(Cell[,] mineField)
    {
        if (isExploded)
        {
            return;
        }
        base.Flag(mineField);
    }
}