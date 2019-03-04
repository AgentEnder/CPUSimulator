namespace CPUSimulator
{
    class RRProcessor : Processor
    {
        private int timeQuantum = 4;
        private int timer = 0;

        public RRProcessor(int quantum)
        {
            timeQuantum = quantum;
        }

        public override void Cycle()
        {
            cpuTime += cycleTime;
            timer += cpuTime;

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
                    }                                                      //effectively incrementing activeJobIdx, the modulus handles when the last job is removed 
                    else
                    {
                        activeJobIdx = 0;
                    }
                    timer = 0;
                }
                else if (timer >= timeQuantum)
                {
                    activeJobIdx = (activeJobIdx + 1) % waitingJobs.Count;
                    timer = 0;
                }
            }
        }
    }
}
