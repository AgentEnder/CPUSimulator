using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    class Job
    {
        int priority = 1;
        int arrivalTime;
        int completionTime;
        int jobID;
        int cyclesRemaining;
        public readonly int Cycles;

        private bool finished = false;

        public int JobID { get => jobID; }
        public int CyclesRemaining { get => cyclesRemaining; }
        public bool Finished { get => finished; }
        public int ArrivalTime { get => arrivalTime;}
        public int CompletionTime { get => completionTime; }

        public Job(int arrival, int cycles, int id)
        {
            arrivalTime = arrival;
            cyclesRemaining = cycles;
            Cycles = cycles;
            jobID = id;
        }

        public bool Cycle(int cpuTime)
        {
            cyclesRemaining -= 1;
            finished = cyclesRemaining < 1;
            if (finished)
            {
                completionTime = cpuTime;
            }
            return finished;
        }
    }
}
