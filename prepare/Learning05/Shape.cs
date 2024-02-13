using System;

public abstract class Shape
{
    // Member variable
    protected string _color = " ";

    // Constructor
    public Shape(string colour)
    {
        _color = colour;
    }

    // Color Setter & Getter
    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    // Empty Virtual Method
    public abstract double GetArea();
}