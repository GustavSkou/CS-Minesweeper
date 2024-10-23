class MineField
{
    public required int Heigth {get; set;}
    public required int Width {get; set;}
    public required int Mines {get; set;}
    private Cell[,] mineField;

    public void CreateEmptyField()
    {
        this.mineField = new Cell[this.Heigth, this.Width];

        for (int row = 0; row < this.Heigth; row++)
        {
            for (int column = 0; column < this.Width; column++)
            {
                this.mineField[row,column] = new Cell();
            }
        }
    }

    public void LayMines()
    {
        Random random = new();

        for ( int mine = 0; mine < Mines; mine++ )
        {
            int[] minePlace = GetRandomPlace();

            this.mineField[ minePlace[0], minePlace[1] ] = new Mine();
        }

        int[] GetRandomPlace()
        {
            int[] place = 
            [
                random.Next(this.Heigth),   // row
                random.Next(this.Width)     // column
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
        void PrintColumnNumbers()
        {
            for (int columnNum = 0; columnNum < this.Heigth; columnNum++)
            {
                if (columnNum == 0) 
                { 
                    Console.Write("  "); 
                }
                Console.Write($"{columnNum} ");    
            }
            Console.WriteLine();
        }
        PrintColumnNumbers();
        
        for(int row = 0; row < this.Heigth; row++)
        {
            Console.Write($"{row} ");
            for (int column = 0; column < this.Width; column++)
            {
                Console.Write( $"{this.mineField[ row, column ].GetChar()} " );
            }
            Console.WriteLine($"{row}");
        }

        PrintColumnNumbers();
    }

    public Cell[,] getMineField()
    {
        return this.mineField;
    }
}