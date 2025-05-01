class MyClass
{
    private int x;
    private int y;

    public MyClass()
    {
        x = 0;
        y = 0;
    }

    public void SetValues(int newX, int newY)
    {
        x = newX;
        y = newY;
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }
}