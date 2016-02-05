using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using  System.Diagnostics;
using System.Timers;
namespace testapp
{
    class Program
    { 
        static Timer aTimer = new Timer();
        private static int segundos=0; 
        private static string nameapp;   
       static int Main(string[] args)
        {
            aTimer = new Timer();
            aTimer.Interval = 1000;
            aTimer.AutoReset = true;
            aTimer.Enabled = false;
            aTimer.Elapsed += OnTimedEvent;
            nameapp = "notepad";
            while (true)
            {
                Process[] processes = System.Diagnostics.Process.GetProcessesByName(nameapp);
                if (processes.Length > 0)
                {
                    if (!(processes[0].Responding))
                    {
                        Start();
                        if (segundos == 5)
                        {
                            processes[0].Kill();
                            processes[0].WaitForExit();
                            Process.Start(nameapp);
                            End();
                        }
                    }
                }
                else {
                    Start();
                    if (segundos == 5)
                    { 
                        Process.Start(nameapp);
                        End();
                    }
                }
                 
            }
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        { 
            segundos++;
            Console.WriteLine("Seg. " + segundos);
        } 
        private static int End() 
        {
            aTimer.Enabled = false;
            segundos = 0;
            return segundos; 
        }
        private static void Start()
        {  
            aTimer.Enabled = true;
        } 
    }
}
