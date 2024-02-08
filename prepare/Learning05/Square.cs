using System;
public class Square : Shape
{
    private double _side = 0.0;

    public Square(string colour, double side) : base(colour)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}