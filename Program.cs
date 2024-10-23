class Program
{
    static void Main()
    {
        MineField mineSweeper = new MineField()
        {
            Heigth = 9, 
            Width = 9, 
            Mines = 9
        };
        
        mineSweeper.CreateEmptyField();
        mineSweeper.LayMines();
        
        mineSweeper.PrintMineField();
    }
}