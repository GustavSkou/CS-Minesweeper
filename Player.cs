class Player
{
    private MineField mineField;
    private int[] coordinatesChoosen = new int[2];
    public Player(MineField mineField) 
    {
        this.mineField = mineField;
    }
    
    public Input GetInput()
    {        
        ConsoleKeyInfo keyInfo;
        Input input = new Input();
        
        do
        {
            keyInfo = Console.ReadKey();
            
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    
                    input.Row = input.Row > 0 ? 
                        input.Row - 1 : 
                        input.Row = mineField.Height - 1;
                    break;

                case ConsoleKey.DownArrow:
                    input.Row = input.Row < mineField.Height - 1 ? 
                        input.Row + 1 : 
                        input.Row = 0;
                    break;

                case ConsoleKey.LeftArrow:
                    input.Column = input.Column > 0 ? 
                        input.Column - 1 : 
                        input.Column = mineField.Width - 1;
                    break;

                case ConsoleKey.RightArrow:
                    input.Column = input.Column < mineField.Width - 1 ? 
                        input.Column + 1 : 
                        input.Column = 0;
                    break;

                default:
                    Console.WriteLine("ArrowKeys to move \nEnter to continue");
                    break;
            }
            mineField.PrintMineField(input);
        
        
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                input.Key = ConsoleKey.Enter;
                break;
            }

            if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                input.Key = ConsoleKey.Spacebar;
                break;
            }
        }
        while(keyInfo.Key != ConsoleKey.Enter || keyInfo.Key != ConsoleKey.Spacebar);

        return input;
    }
}

class Input
{
    static private int row = 0, column = 0;
    private ConsoleKey key;

    public int Row 
    {
        get { return row; }
        set { row = value;} 
    }
    public int Column
    {
        get { return column; }
        set { column = value;}
    }
    public ConsoleKey Key
    {
        get { return key; }
        set { key = value; }
    }
}