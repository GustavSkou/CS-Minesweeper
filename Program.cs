class Program
{
    static void Main()
    {
        MineField mineField = new MineField(9,9);
        Player player = new Player(mineField);

        mineField.LayMines(20);
        mineField.PrintMineField();

        player.GetInput();
        
    }
}