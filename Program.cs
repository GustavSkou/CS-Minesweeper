class Program
{
    static void Main()
    {
        MineField mineField = new MineField(9,9);
        Player player = new Player(mineField);

        mineField.LayMines(5);
        mineField.PrintMineField();

        //mineField.getMineField()[1,1].Open(mineField.getMineField());
        mineField.PrintMineField();

        while (true)
        {
            int[] coordinets = player.GetInput();

            mineField.getMineField()[coordinets[0], coordinets[1]].
                Open(mineField.getMineField());
                
            mineField.PrintMineField(coordinets);
        }
    }
}