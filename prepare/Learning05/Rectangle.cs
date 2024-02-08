using System;
public class Rectangle : Shape
{
    private double _length = 0.0;
    private double _width = 0.0;

    public Rectangle(string colour, double length, double width) : base(colour)
    {
        _length = length;
        _width = width;
    }

    public override double GetArea()
    {
        return _length * _width;
    }
}