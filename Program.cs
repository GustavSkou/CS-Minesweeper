class Program
{
    static void Main()
    {
        MineField mineField = new MineField(9,9);
        Player player = new Player(mineField);

        mineField.LayMines(5);
        mineField.PrintMineField(null);

        while (true)
        {
            int[] coordinets = player.GetInput();

            mineField.Field[coordinets[0], coordinets[1]].
                Open(mineField.Field);
                
            mineField.PrintMineField(coordinets);
        }
    }
}