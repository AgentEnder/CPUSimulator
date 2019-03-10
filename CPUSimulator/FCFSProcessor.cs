using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    class FCFSProcessor : Processor
    {
        


        override public void Cycle()
        {
            cpuTime += cycleTime;
            Job job = GetActiveJob();
            if (job != null)
            {
                if (job.Cycle(cpuTime)) //Returns true if job is finished
                {
                    finishedJobs.Add(job);
                    waitingJobs.Remove(job);
                    if (waitingJobs.Count > 0)
                    {
                        activeJobIdx = (activeJobIdx) % waitingJobs.Count; //This works because removing the current job shifts all jobs after it to the left   
                    }                                                      //effectively incrementing activeJobIdx, the modulus handles when the last job in 
                    else
                    {
                        activeJobIdx = 0;
                    }
                }
            }
            
        }
    }
}
