using System;
using System.Runtime.CompilerServices;

class Word
{
    // ************
    // Member variables
    private string _text;
    private bool _isHidden;

    // ************
    // Constructor
    // You are forced to pass in an argument when the object is created
    public Word(string text)
    {
        _text = text;
        this.Show();
    }

    // ************
    // Methods
    public void Hide()
    {
        _text = "___";
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        // If _isHidden = true, returns true; if false, returns false
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _text;
    }
}