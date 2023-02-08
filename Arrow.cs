using System.Diagnostics;
using System;

public class Arrow
{
    public int upperBound;
    public int bottomBound;
    public int max;
    public int pointerPosition;

    public Arrow(int numOfElements, int upperBound)
    {
        max = numOfElements + upperBound;
        this.upperBound = upperBound;
    }
    public Arrow()
    {
        pointerPosition = upperBound;
    }
    public void SetCursorToStart()
    {
        pointerPosition = upperBound;
        Console.SetCursorPosition(0, upperBound);
        Console.WriteLine("->");
    }
    public void Down()
    {
        if (pointerPosition != max)
        {
            Console.SetCursorPosition(0, pointerPosition);
            Console.WriteLine("  ");
            pointerPosition++;
            Console.SetCursorPosition(0, pointerPosition);
            Console.WriteLine("->");
        }
    }
    public void Up()
    {
        if (pointerPosition != upperBound)
        {
            Console.SetCursorPosition(0, pointerPosition);
            Console.WriteLine("  ");
            pointerPosition--;
            Console.SetCursorPosition(0, pointerPosition);
            Console.WriteLine("->");
        }
    }
    public void D(Process process)
    {
        process.Kill();
    }
    private int CurrentIndex()
    {
        return pointerPosition - upperBound;
    }

    public int GetCurrentIndex
    {
        get { return CurrentIndex(); }

    }

}