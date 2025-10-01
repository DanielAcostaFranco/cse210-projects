using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();

        job1._company = "Amazon";

        job1._jobTitle = "Software Engineer";

        job1._startYear = 2020;

        job1._endYear = 2023;


        Job job2 = new Job();

        job2._company = "Apple";

        job2._jobTitle = "Software Engineer";

        job2._startYear = 2023;

        job2._endYear = 2025;


        Resume Resume1 = new Resume();
        Resume1._name = "Daniel Acosta";

        Resume1._jobs.Add(job1);
        Resume1._jobs.Add(job2);

        Resume1.DisplayJobDetails();
    }


}