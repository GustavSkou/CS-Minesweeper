class Mine : Cell
{
    public Mine(int row, int column) : base(row, column)
    {
        this.row = row;
        this.column = column;
    }

    public override void Open(Cell[,] minefield)
    {
        model = "¤";
    }
}