using System;
using System.Collections.Generic;

namespace CPUSimulator
{
    class RRProcessor : Processor
    {
        private int timeQuantum = 4;
        private int timer = 0;
        private Queue<Job> secondaryWaiting = new Queue<Job>();

        public RRProcessor(int quantum)
        {
            timeQuantum = quantum;
        }

        public override void Cycle()
        {
            Job job;
            if (timer >= timeQuantum)
            {
                timer = 0;
                if (waitingJobs.Count > 0)
                {
                    job = GetActiveJob();
                    secondaryWaiting.Enqueue(job);
                    waitingJobs.Remove(job);
                }
            }
            cpuTime += cycleTime;
            timer += cycleTime;

            if (waitingJobs.Count <= 0 && secondaryWaiting.Count > 0)
            {
                waitingJobs.AddRange(secondaryWaiting);
                secondaryWaiting.Clear();
            }

            job = GetActiveJob();
            if (job != null)
            {
                //PrintStatus();
                
                if (job.Cycle(cpuTime)) //Returns true if job is finished
                {
                    finishedJobs.Add(job);
                    waitingJobs.Remove(job);
                    
                    timer = 0;
                }
            }

        }
    }
}
