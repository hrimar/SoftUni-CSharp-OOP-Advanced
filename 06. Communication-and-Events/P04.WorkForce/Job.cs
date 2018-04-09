using P04.WorkForce.Contracts;
using P04.WorkForce.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WorkForce
{
    public class Job
    {
        public event JobDoneEventHandler JobDone;


        private string name;
        private int workHoursRequired;
        private IEmployee employee;
        private bool isDone;
       
        public Job(string name, int  workHoursRequired, IEmployee employee)
        {
            this.Name = name;
            this.WorkHoursRequired = workHoursRequired;
            this.employee = employee;
            this.IsDone = false;
        }

        public string Name
        {
            get { return name; }
           private set { name = value; }
        }
        public int WorkHoursRequired
        {
            get { return workHoursRequired; }
          private  set { workHoursRequired = value; }
        }
        public bool IsDone
        {
            get { return isDone; }
            private set { isDone = value; }
        }


        public void Update()
        {
            this.WorkHoursRequired -= employee.WorkHoursPerWeek;
            if (this.WorkHoursRequired <= 0 && !this.IsDone)
            {
                if (JobDone != null)
                {
                    JobDone(this, new JobEventArgs(this));
                }
            }
        }

        public void OnJobDone(object sebder, JobEventArgs e)
        {
            Console.WriteLine($"Job {this.Name} done!");
            IsDone = true;
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.WorkHoursRequired}";
        }
    }
}
