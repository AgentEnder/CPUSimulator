using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool valid;
            Simulator sim = new Simulator(new FCFSProcessor());
            do
            {
                valid = true;
                Console.WriteLine("Would you like to use (1)FCFS, (2)SJN, (3)SRT, or (4)Round Robin?");
                switch (Int32.Parse(Console.ReadLine()))
                {
                    case 1:
                        {
                            //FCFS is the default, finished.
                        }break;
                    case 2:
                        {
                            sim = new Simulator(new SJNProcessor());
                        }
                        break;
                    case 3:
                        {
                            sim = new Simulator(new SRTProcessor());
                        }
                        break;
                    case 4:
                        {
                            Console.Write("Using time quantum _____: ");
                            int q;
                            if (Int32.TryParse(Console.ReadLine(), out q))
                            {
                                sim = new Simulator(new RRProcessor(q));
                            }
                            else
                            {
                                valid = false;
                            }
                        }
                        break;
                    default:
                        {
                            valid = false;
                        }break;
                }
            } while (!valid);
            InputParser inputParser = new InputParser(ref sim);
            inputParser.ParseFromFile();
            sim.Simulate();
            Console.ReadKey();
        }
    }
}
