class MineField
{
    private int heigth, width, mines;
    private Cell[,] mineField;

    public MineField(int heigth, int width, int mines)
    {
        this.heigth = heigth;
        this.width = width;
        this.mines = mines;
    }

    public void CreateEmptyField()
    {
        this.mineField = new Cell[this.heigth, this.width];

        for (int row = 0; row < this.heigth; row++)
        {
            for (int column = 0; column < this.width; column++)
            {
                this.mineField[row,column] = new Cell();
            }
        }
    }

    public void LayMines()
    {
        Random random = new Random();

        for (int mine = 0; mine < mines; mine++)
        {
            int[] minePlace = GetRandomPlace();

            this.mineField[ minePlace[0], minePlace[1] ] = new Mine(); // Downcast Cell to Mine
        }

        int[] GetRandomPlace()
        {
            int[] place = 
            [
                random.Next(this.heigth),   // row
                random.Next(this.width)     // column
            ];
            
            if (this.mineField[place[0],place[1]] is Mine)
            {
                return GetRandomPlace();
            }

            return place;
        }
    }
}