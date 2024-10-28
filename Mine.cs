class Mine : Cell
{
    private string mineModel = "¤";
    public Mine(int row, int column) : base(row, column)
    {
        this.row = row;
        this.column = column;
    }

    public override string GetChar()
    {
        if (!isOpen)
        {
            return base.GetChar();
            
        }
        return mineModel;
    }

    public override void Open(Cell[,] minefield)
    {
        isOpen = true;
        GetChar();
        Console.WriteLine("boom");
    }
}