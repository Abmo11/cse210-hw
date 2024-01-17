using System;

public class Resume
{
    public string _name;

    // Creates a list of objects, of data type 'Job', called _jobList
    public List<Job> _jobList = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job j in _jobList)
        {
            // Calls method for each job
            j.DisplayJobDetails();
        }
    }
}