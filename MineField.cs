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

        field = new Cell[heigth, width];
        SetFieldToCells();
    }

    public void SetFieldToCells()
    {
        ProcessField((row, column) =>
            {
                field[row, column] = new Cell(row, column);
            }
        );
    }

    public void LayMines(int mines)
    {
        totalMines =+ mines;

        for (int minesPlaced = 0; minesPlaced < mines; minesPlaced++)
        {
            int[] coordiantes = GetRandomCellCoordiantes();
            field[coordiantes[0], coordiantes[1]] = new Mine(coordiantes[0], coordiantes[1]);
        }
    }

    public void PrintMineField(Input input)
    {
        Console.Clear();

        if (input == null)
        {
            input.Row = 0;
            input.Column = 0;
        }

        ProcessField((row, column) =>
            {
                Console.BackgroundColor = row == input.Row && column == input.Column ? 
                    ConsoleColor.DarkGray : 
                    ConsoleColor.Black;

                Console.Write($"{field[row, column].Model} ");
                
                if (column == width - 1)
                {
                    Console.WriteLine();
                }
            }
        );
    }

    private int[] GetRandomCellCoordiantes()
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

        return GetRandomCellCoordiantes();
    }

    private void ProcessField(Action<int ,int > action)
    {
        for (int row = 0; row < heigth; row++)
        {
            for (int column = 0; column < width; column++)
            {
                action(row, column);
            }
        }
    }

    public void OpenAllCells()
    {
        foreach (Cell cell in field)
        {
            cell.Open(field);
        }
    }
}