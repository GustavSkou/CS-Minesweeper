class Program
{
    static void Main()
    {
        MineField mineField = new MineField(9, 9, 9);
        mineField.CreateEmptyField();
        mineField.LayMines();
        
    }
}