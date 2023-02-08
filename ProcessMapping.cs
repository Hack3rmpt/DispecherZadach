using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DispecherZadach
{
    static class ProcessMapping
    {

        public static void ShowLiveProcesses(List<System.Diagnostics.Process> processes)
        {
            Console.Clear();
            Console.WriteLine("  Имя процесса" + "\t" + "Виртуальная память");
            foreach (var item in processes)
            {
                if (item.ProcessName == "") Console.WriteLine("  " + "<undefined_name>" + " " + item.VirtualMemorySize64 / 1048576 + " Мб.");
                else Console.WriteLine("  " + item.ProcessName + "\t" + item.VirtualMemorySize64 / 1048576 + " Мб.");
            }
        }
        public static void ShowLiveProcess(System.Diagnostics.Process process)
        {
            Console.Clear();
            Console.WriteLine("Имя процесса: " + process.ProcessName);
            Console.WriteLine("Id процесса: " + process.Id);

        }

    }
}
