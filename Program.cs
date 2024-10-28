class Program
{
    static void Main()
    {
        MineField mineField = new MineField(9,9);
        Player player = new Player(mineField);

        mineField.LayMines(5);
        mineField.PrintMineField();
        //mineField.OpenMineField();
        //mineField.PrintMineField();
        while (true)
        {
            player.GetInput();
        }
    }
}