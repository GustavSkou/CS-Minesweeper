class Flag
{
    private bool state = false;
    
    public bool State
    {
        get {return state;}
    }

    public void ChangeState()
    {
        state = !state;
    }
}