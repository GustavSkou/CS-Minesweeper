
class Cell
{
    protected char cellModel = '#';
    protected bool isOpen = false;
    protected bool isFlag = false;

    public virtual char GetChar()
    {
        return cellModel;
    }

    public virtual void Open()
    {
        if (isOpen)
        {
            return;
        }
        
        isOpen = true;
    }

    public virtual void Flag()
    {

    }
}