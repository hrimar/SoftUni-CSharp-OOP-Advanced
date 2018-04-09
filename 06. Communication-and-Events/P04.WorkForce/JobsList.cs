using System.Collections.Generic;

namespace P04.WorkForce
{

    public class JobsList : List<Job>
    {
        public void OnJobDone(object sender, JobEventArgs e)
        {
            this.Remove(e.Job);
        }
    }

}