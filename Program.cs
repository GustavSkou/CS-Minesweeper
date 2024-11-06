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

            mineField.Field[input.Row, input.Column].
                Open(mineField.Field);
                
            mineField.PrintMineField(input);
        }
    }
}