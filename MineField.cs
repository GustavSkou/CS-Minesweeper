class MineField
{
    private int  heigth, width, totalMines = 0;

    private Cell[,] mineField;

    public MineField(int heigth, int width)
    {
        this.heigth = heigth;
        this.width = width;
        mineField = SetFieldToCells();
    }

    public int GetHeight()
    {
        return this.heigth;
    }
    public int GetWidth()
    {
        return this.width;
    }

    public Cell[,] SetFieldToCells()
    {
        Cell[,] someField = new Cell[this.heigth, this.width];

        for (int row = 0; row < this.heigth; row++)
        {
            for (int column = 0; column < this.width; column++)
            {
                someField[row,column] = new Cell(row, column);
            }
        }
        return someField;
    }

    public void LayMines(int mines)
    {
        this.totalMines = this.totalMines + mines;
        Random random = new();

        for ( int minesPlaced = 0; minesPlaced < mines; minesPlaced++ )
        {
            int[] minePlace = GetRandomPlace();

            Cell mine = new Mine(minePlace[0], minePlace[1]);
            this.mineField[ minePlace[0], minePlace[1] ] = mine;
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
        Console.Clear();
        //PrintColumnNumbers();
        
        for(int row = 0; row < this.heigth; row++)
        {
            //PrintRowNumbers(row);
            
            for (int column = 0; column < this.width; column++)
            {
                Console.Write( $"{this.mineField[ row, column ].GetChar()} " );
            }
            
            //PrintRowNumbers(row);
            Console.WriteLine();
        }

        //PrintColumnNumbers();
    }
    public void PrintMineField(int[] coordinates)
    {
        Console.Clear();
        //PrintColumnNumbers();
        
        for(int row = 0; row < this.heigth; row++)
        {
            //PrintRowNumbers(row);
            
            for (int column = 0; column < this.width; column++)
            {
              
                Console.BackgroundColor = row == coordinates[0] || column == coordinates[1] ? ConsoleColor.DarkGray : ConsoleColor.Black;
                
                Console.Write( $"{this.mineField[ row, column ].GetChar()} " );
                Console.BackgroundColor = ConsoleColor.Black;
            }
            
            //PrintRowNumbers(row);
            Console.WriteLine();
        }

        //PrintColumnNumbers();
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

    public void OpenMineField()
    {
        foreach (Cell cell in mineField)
        {
            cell.Open(mineField);
        }
    }
}