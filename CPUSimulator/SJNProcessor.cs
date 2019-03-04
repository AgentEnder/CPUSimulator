using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    class SJNProcessor : Processor
    {
        public override void Cycle()
        {
            cpuTime += cycleTime;
            Job job = GetActiveJob();
            if (job != null)
            {
                if (job.Cycle(cpuTime)) //Returns true if job is finished
                {
                    finishedJobs.Add(job);
                    waitingJobs.Remove(job);
                    waitingJobs.Sort((x, y) => x.CyclesRemaining.CompareTo(y.CyclesRemaining));
                }
            }
        }
    }
}
