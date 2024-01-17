using System;

class Program
{
    static void Main(string[] args)
    {
        // Creates new Job object called 'job1'
        Job job1 = new Job();

        job1._company = "Google";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2019;
        job1._endYear = 2023;

        // Creates new Job object called 'job2'
        Job job2 = new Job();

        job2._company = "OpenAi";
        job2._jobTitle = "ML Engineer";
        job2._startYear = 2024;
        job2._endYear = 2050;

        // Creates new Resume object called 'resume'
        Resume resume = new Resume();

        resume._name = "Abraham Moreno";
        // Adds job1 and job2 objects to 'Job' type list in resume object
        resume._jobList.Add(job1);
        resume._jobList.Add(job2);

        // Calls method to display resume
        resume.Display();
    }
}