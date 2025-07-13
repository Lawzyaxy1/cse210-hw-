using System;

class Program
{
    static void Main(string[] args)
    {
         Console.WriteLine("Hello World! This is the Resumes Project.");
    // Create Job 
        Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
        Job job2 = new Job("Manager", "Apple", 2022, 2023);

        // Create a Resume 
        Resume myResume = new Resume("Allison Rose");

        // Add jobs to the resume
        myResume.AddJob(job1);
        myResume.AddJob(job2);

        // Display the resume
        myResume.DisplayResume();
        // Wait for user input before closing
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(); 
    }
}