class Program
{
    static void Main()
    {
        MineField mineSweeper = new MineField(9,9);
        
        mineSweeper.LayMines(20);

        mineSweeper.PrintMineField();
    }
}