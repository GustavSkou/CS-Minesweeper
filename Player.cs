class Player
{
    private MineField mineField;
    private int[] coordinatesChoosen = new int[2];
    public Player(MineField mineField) 
    {
        this.mineField = mineField;
    }
    
    public void GetInput()
    {        
        ConsoleKeyInfo keyInfo;
        
        do
        {
            keyInfo = Console.ReadKey();
            
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    coordinatesChoosen[0] = coordinatesChoosen[0] > 0 ? coordinatesChoosen[0] = coordinatesChoosen[0] - 1 : coordinatesChoosen[0] = mineField.GetHeight() - 1;
                    break;

                case ConsoleKey.DownArrow:
                    coordinatesChoosen[0] = coordinatesChoosen[0] < mineField.GetHeight() - 1 ? coordinatesChoosen[0] = coordinatesChoosen[0] + 1 : coordinatesChoosen[0] = 0;
                    break;

                case ConsoleKey.LeftArrow:
                    coordinatesChoosen[1] = coordinatesChoosen[1] > 0 ? coordinatesChoosen[1] = coordinatesChoosen[1] - 1 : coordinatesChoosen[1] = mineField.GetWidth() - 1;
                    break;

                case ConsoleKey.RightArrow:
                    coordinatesChoosen[1] = coordinatesChoosen[1] < mineField.GetWidth() - 1 ? coordinatesChoosen[1] = coordinatesChoosen[1] + 1 : coordinatesChoosen[1] = 0;
                    break;

                default:
                    Console.WriteLine("ArrowKeys to move \nEnter to continue");
                    break;
            }
            mineField.PrintMineField(coordinatesChoosen);
        }
        while(keyInfo.Key != ConsoleKey.Enter);
        mineField.getMineField()[ coordinatesChoosen[0],coordinatesChoosen[1] ].Open(mineField.getMineField());
        mineField.PrintMineField(coordinatesChoosen);
    }
}