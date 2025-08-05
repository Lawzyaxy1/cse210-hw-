using System;
using System.Collections.Generic;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        if (_jobs.Count == 0)
        {
            Console.WriteLine("No jobs to display.");
            return;
        }
        Console.WriteLine("Job History:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}