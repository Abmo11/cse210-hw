using System;

class Reference
{
    // ************
    // Member variables
    private string _book;

    private int _chapter;

    private int _verse;

    private int _endVerse;

    // ************
    // Constructors
    // Initialize member variables here
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // ************
    // Method
    public string GetDisplayText()
    {
        // Checks to see if there are multiple verses
        // _endVerse is 0 - default initialization, when not explicitly initialized
        if (_endVerse == 0) 
        {
            return $"{_book} {_chapter}: {_verse}";
        }
        else
        {
            return $"{_book} {_chapter}: {_verse} - {_endVerse}";
        }
    }
}