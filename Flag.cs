class Flag
{
    private bool state;
    
    public bool State
    {
        get {return state;}
    }

    public void ChangeState()
    {
        state = !state;
    }
}