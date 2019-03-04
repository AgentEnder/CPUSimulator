using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    abstract class Processor
    {
        protected int cpuTime = 0;
        protected int cycleTime = 1;

        protected int activeJobIdx = 0;
        protected List<Job> waitingJobs = new List<Job>();
        protected List<Job> finishedJobs = new List<Job>();

        abstract public void Cycle();
        public Job GetActiveJob()
        {
            if (waitingJobs == null || waitingJobs.Count == 0)
            {
                return null;
            }
            return waitingJobs[activeJobIdx];
        }
        public bool IsBusy()
        {
            return waitingJobs.Count > 0;
        }

        public void AddJob(int id, int cycles)
        {
            Job job = new Job(cpuTime, cycles, id);
            waitingJobs.Add(job);
        }

        public int GetProcessorTime()
        {
            return cpuTime;
        }

        public List<Job> GetFinishedJobs()
        {
            return finishedJobs;
        }
    }
}
