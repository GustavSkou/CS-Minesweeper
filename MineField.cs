class MineField
{
    private int heigth, width, totalMines = 0;

    private Cell[,] field;

    private Random random = new();

    public Cell[,] Field
    {
        get { return field; }
    }

    public int Height
    {
        get { return heigth; }
    }

    public int Width
    {
        get { return width; }
    }

    public MineField(int heigth, int width)
    {
        this.heigth = heigth;
        this.width = width;
        field = SetFieldToCells();
    }

    public Cell[,] SetFieldToCells()
    {
        Cell[,] someField = new Cell[heigth, width];

        for (int row = 0; row < heigth; row++)
        {
            for (int column = 0; column < width; column++)
            {
                someField[row, column] = new Cell(row, column);
            }
        }
        return someField;
    }

    public void LayMines(int mines)
    {
        totalMines =+ mines;

        for (int minesPlaced = 0; minesPlaced < mines; minesPlaced++)
        {
            int[] coordiantes = GetRandomCoordiantes();
            field[coordiantes[0], coordiantes[1]] = new Mine(coordiantes[0], coordiantes[1]);
        }
    }

    public void PrintMineField(Input input)
    {
        if (input == null)
        {
            input.Row = 0;
            input.Column = 0;
        }

        Console.Clear();

        for (int row = 0; row < heigth; row++)
        {
            for (int column = 0; column < width; column++)
            {
                Console.BackgroundColor = row == input.Row && column == input.Column ? 
                    ConsoleColor.DarkGray : 
                    ConsoleColor.Black;

                Console.Write($"{field[row, column].Model} ");
            }

            Console.WriteLine();
        }
    }

    // Helpers //
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

    private int[] GetRandomCoordiantes()
    {
        int[] coordiantes =
        [
            random.Next(heigth),        // row
                random.Next(width)      // column
        ];

        if (field[coordiantes[0], coordiantes[1]].GetType() == typeof(Cell)) // Coordinates should only be return if it corresponds to a Cell
        {
            return coordiantes;
        }

        return GetRandomCoordiantes();
    }

    public void OpenAllCells()
    {
        foreach (Cell cell in field)
        {
            cell.Open(field);
        }
    }
}