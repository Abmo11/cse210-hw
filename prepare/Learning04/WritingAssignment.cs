using System;

public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title) : base (studentName, topic)
    {
        _title = title; // 1 variable differs from base class
    }

    public string GetWritingInformation()
    {
        // Calls 'GetStudentName' method from base class since base's '_name' is set to private
        return $"{_title} by {GetStudentName()}";
    }
}