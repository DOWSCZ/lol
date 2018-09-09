using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> output =  new List<string>();

            ProcessStartInfo info = new ProcessStartInfo
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                FileName = @"C:\Program Files (x86)\PioSolver\PioSOLVER-edge19AVX.exe",
                WorkingDirectory = @"C:\Program Files (x86)\PioSolver",
                CreateNoWindow = true
            };



            Process proc = new Process();
            proc.OutputDataReceived += (s, e) =>
            {
                //Console.WriteLine(e.Data);
                output.Add(e.Data);
            };
            //async output
            proc.StartInfo = info;
            proc.Start();
            proc.BeginOutputReadLine();


            using (StreamWriter writer = proc.StandardInput)
            {
                string command = "";
                while (command != "exit")
                {
                    command = Console.ReadLine();
                    writer.WriteLine(command);
                }
            }
        }
    }
}
