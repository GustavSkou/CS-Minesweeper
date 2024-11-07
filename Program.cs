class Program
{
    static void Main()
    {
        MineField mineField = new MineField(9,9);
        Player player = new Player(mineField);

        mineField.LayMines(5);
        mineField.PrintMineField(new Input());

        while (true)
        {
            Input input = player.GetInput();

            if (input.Key == ConsoleKey.Enter)
            {
                mineField.Field[input.Row, input.Column].
                    Open(mineField.Field);
            }
            
            if (input.Key == ConsoleKey.Spacebar)
            {
                mineField.Field[input.Row, input.Column].
                    Flag(mineField.Field);
            }
 
            mineField.PrintMineField(input);
        }
    }
}