using System;

class Program
{
    static void Main(string[] args)
    {
        //Create new job
        Job job1 = new Job();
        Job job2 = new Job();
        // Create job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        // Create another job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;
        // Create a resume and add the jobs to it.
        Resume myResume = new Resume();
        myResume._name = "Allison Rose";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        // Display the resume
        Console.WriteLine("Resume for: " + myResume._name);
        myResume.Display();
    }
}
