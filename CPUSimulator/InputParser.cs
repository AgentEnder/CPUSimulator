using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CPUSimulator
{
    class InputParser
    {
        Simulator sim;
        public InputParser(ref Simulator simulator)
        {
            sim = simulator;
        }

        public void ParseFromConsole()
        {
            int jobs = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < jobs; i++)
            {
                string input = Console.ReadLine();
                string[] input_arr = input.Split(' ');
                int[] int_arr = new int[3];
                for (int j = 0; j < input_arr.Length; j++)
                {
                    int_arr[j] = Int32.Parse(input_arr[j]);
                }
                sim.AddJob(int_arr[0], int_arr[2], int_arr[1]);
            }
        }

        public void ParseFromFile()
        {
            Console.Write("Enter the filepath: ");
            string path = Console.ReadLine();
            path = path.Replace("\"", "");
            ParseFromFile(path);
        }

        public void ParseFromFile(string filepath)
        {
            using (StreamReader f = new StreamReader(filepath))
            {
                int jobs = Int32.Parse(f.ReadLine());
                for (int i = 0; i < jobs; i++)
                {
                    string input = f.ReadLine();
                    string[] input_arr = input.Split(' ');
                    int[] int_arr = new int[3];
                    for (int j = 0; j < input_arr.Length; j++)
                    {
                        int_arr[j] = Int32.Parse(input_arr[j]);
                    }
                    sim.AddJob(int_arr[0], int_arr[2], int_arr[1]);
                }
            }
        }
    }
}
