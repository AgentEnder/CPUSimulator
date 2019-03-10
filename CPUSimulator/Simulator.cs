using System;
using System.Collections.Generic;

namespace CPUSimulator
{
    class Simulator
    {
        private Processor processor;
        private Dictionary<int, List<Tuple<int, int>>> simJobs; //Arrival Time: ID, Cycles
        int jobs = 0;
        public Simulator(Processor p)
        {
            processor = p;
            simJobs = new Dictionary<int, List<Tuple<int, int>>>();
        }

        public void AddJob(int id, int cycles, int arrival)
        {
            if (!simJobs.ContainsKey(arrival))
            {
                simJobs[arrival] = new List<Tuple<int, int>>();
            }
            simJobs[arrival].Add(new Tuple<int, int>(id, cycles));
            jobs++;
        }

        public void Simulate()
        {
            while (processor.GetFinishedJobs().Count < jobs)
            {
                int time = processor.GetProcessorTime();
                if (simJobs.ContainsKey(time))
                {
                    simJobs[time].Sort((x, y) => x.Item2.CompareTo(y.Item2));
                    foreach (var item in simJobs[time])
                    {
                        processor.AddJob(item.Item1, item.Item2);
                    }
                }
                processor.Cycle();
            }
            Console.WriteLine("\n\n" +
                              "-----------------------------------------------\n" +
                              "SIMULATOR OUTPUT for " + processor.GetType().ToString().Split('.')[1] + "\n" +
                              "-----------------------------------------------");
            int totalTurnaround = 0;
            int totalWaiting = 0;

            Console.WriteLine(String.Format("{0,5}|{1,15}|{2,15}|{3,15}|{4,15}", "JobID", "Arrival Time", "Complete Time", "Waiting", "Turnaround"));
            List<Job> completed = processor.GetFinishedJobs();
            completed.Sort((x, y) => x.JobID.CompareTo(y.JobID));
            foreach (Job job in completed)
            {
                int turnaround = (job.CompletionTime - job.ArrivalTime);
                totalTurnaround += turnaround;
                int waiting = turnaround - job.Cycles;
                totalWaiting += waiting;
                Console.WriteLine(String.Format("{0,5}|{1,15}|{2,15}|{3,15}|{4,15}", job.JobID, job.ArrivalTime, job.CompletionTime, waiting, turnaround));
                //Console.WriteLine("Job " + job.JobID.ToString() + ": Arrived at " + job.ArrivalTime + ", finished at " + job.CompletionTime);
                
                //Console.WriteLine("Turnaround Time: " + turnaround.ToString() + ", Waiting: " + waiting.ToString());
            }

            Console.WriteLine("\n===Averages===\n" +
                              "Waiting: " + ((float)totalWaiting / (float)jobs).ToString() +
                              "\nTurnaround Time: " + ((float)totalTurnaround / (float)jobs).ToString());
        }
    }
}
