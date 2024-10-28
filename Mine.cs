class Mine : Cell
{
    private char mineModel = '¤';
    public override char GetChar()
    {
        if (!isOpen)
        {
            return base.GetChar();
            
        }
        return mineModel;
    }
}