using System;

public class Fraction
{
    // Encapsulated member variables
    private int _top;
    private int _bottom;

    // ************
    // ************
    // Constructor with no parameters - initialize to 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor with _top parameter(placeholder) & _bottom = 1
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // Constructor with both _top & _bottom parameters(placeholders)
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }
    // ************
    // ************

    // Getters and Setters Top (Accessors and Mutators)
    public int GetTop()
    {
        return _top;
    }
    public void SetTop(int top)
    {
        _top = top;
    }

    // Getters and Setters Bottom (Accessors and Mutators)

    public int GetBottom()
    {
        return _bottom;
    }
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }
    // ************
    // ************

    // Returns fraction string to display
    public string GetFractionString()
    {
        string fractionString = $"{_top}/{_bottom}";
        return fractionString;
    }
    // Returns decimal calculation of _top / _bottom
    public double GetDecimalValue()
    {
        // Must cast one member variable to double
        // to avoid int division
        double decimalValue = (double)_top / _bottom;
        return decimalValue;
    }
}