class MineField
{
    private int heigth, width, totalMines = 0;

    private Cell[,] mineField;

    public MineField(int height, int width)
    {
        this.heigth = height;
        this.width = width;
        mineField = SetFieldToCells();
    }

    public Cell[,] SetFieldToCells()
    {
        Cell[,] someField = new Cell[this.heigth, this.width];

        for (int row = 0; row < this.heigth; row++)
        {
            for (int column = 0; column < this.width; column++)
            {
                someField[row,column] = new Cell();
            }
        }
        return someField;
    }

    public void LayMines(int mines)
    {
        this.totalMines = this.totalMines + mines;
        Random random = new();

        for ( int mine = 0; mine < mines; mine++ )
        {
            int[] minePlace = GetRandomPlace();

            this.mineField[ minePlace[0], minePlace[1] ] = new Mine();
        }

        int[] GetRandomPlace()
        {
            int[] place = 
            [
                random.Next(this.heigth),   // row
                random.Next(this.width)     // column
            ];
            
            if ( this.mineField[place[0],place[1]].GetType() == typeof(Cell) )
            {
                return place; 
            }

            return GetRandomPlace();
        }
    }

    public void PrintMineField()
    {
        PrintColumnNumbers();
        
        for(int row = 0; row < this.heigth; row++)
        {
            PrintRowNumbers(row);
            
            for (int column = 0; column < this.width; column++)
            {
                Console.Write( $"{this.mineField[ row, column ].GetChar()} " );
            }
            
            PrintRowNumbers(row);
            Console.WriteLine();
        }

        PrintColumnNumbers();
    }
    private void PrintColumnNumbers()
        {
            for (int columnNum = 0; columnNum < this.heigth; columnNum++)
            {
                if (columnNum == 0) 
                { 
                    Console.Write("  "); 
                }
                Console.Write($"{columnNum} ");    
            }
            Console.WriteLine();
        }
    private void PrintRowNumbers(int row)
    {
        Console.Write($"{row} ");
    }
    public Cell[,] getMineField()
    {
        return this.mineField;
    }
}