class Cell
{
    public virtual char GetChar()
    {
        return '#';
    }
}

class Mine : Cell
{
    public override char GetChar()
    {
        return '¤';
    }
}

class Flag : Cell
{
    public override char GetChar()
    {
        return 'F';
    }
}

class Open : Cell
{
    public override char GetChar()
    {
        return ' ';
    }
}