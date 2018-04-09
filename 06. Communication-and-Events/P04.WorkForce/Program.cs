using P04.WorkForce.Contracts;
using P04.WorkForce.Employees;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.WorkForce // 100/100 - ПАК!
{

    public delegate void JobDoneEventHandler(object sender, JobEventArgs e);


    class Program
    {
        static void Main()
        {
            JobsList jobs = new JobsList();
            List<IEmployee> emploees = new List<IEmployee>();

            string[] input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                switch (input[0])
                {
                    case "Job":
                        Job realJob = new Job(input[1], int.Parse(input[2]), emploees.FirstOrDefault(e => e.Name == input[3]));
                        realJob.JobDone += realJob.OnJobDone;
                        jobs.Add(realJob);
                        break;
                    case "StandardEmployee":
                        emploees.Add(new StandardEmployee(input[1]));
                        break;
                    case "PartTimeEmployee":
                        emploees.Add(new PartTimeEmployee(input[1]));
                        break;
                    case "Pass":
                        foreach (var job in jobs)
                        {
                            job.Update();
                        }
                        break;
                    case "Status":
                        foreach (var job in jobs)
                        {
                            if (!job.IsDone)
                            {
                                Console.WriteLine(job.ToString());
                            }
                        }
                        break;
                }

                input = Console.ReadLine().Split();
            }
        }
    }
}
