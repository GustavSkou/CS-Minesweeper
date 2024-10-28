class Cell
{
    protected int row, column;
    private string cellModel = "#";
    protected bool isOpen = false;
    protected bool isFlag = false;

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

        for (int i = 0; i < mineField.GetLength(0); i++)
        {
            for (int j = 0; j < mineField.GetLength(1); j++)
            {
                if (mineField[i, j].Equals(this))
                {
                    mineField[i, j] = new Open(this.row, this.column, mineField);
                }
            }
        }
    }
}