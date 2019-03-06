using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    class SRTProcessor : Processor
    {
        public override void Cycle()
        {
            cpuTime += cycleTime;
            waitingJobs.Sort((x, y) => x.CyclesRemaining.CompareTo(y.CyclesRemaining)); //Sorting the list every frame is inoptimal, a priority queue would be MUCH better.
            Job job = GetActiveJob();
            if (job != null)
            {
                if (job.Cycle(cpuTime)) //Returns true if job is finished
                {
                    finishedJobs.Add(job);
                    waitingJobs.Remove(job);
                }
            }
        }
    }
}
