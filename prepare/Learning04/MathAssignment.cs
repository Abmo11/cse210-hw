using System;

public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    // Must pass in paramemters from base class' constructor into derived class' constructor - to use 'base'
    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base (studentName, topic)
    {
        // 2 variables differ from base class
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}