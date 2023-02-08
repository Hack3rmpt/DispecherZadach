using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace DispecherZadach
{
    class Program
    {
        static void Main(string[] args)
        {
            var ArrOfProcess = System.Diagnostics.Process.GetProcesses();
            List<System.Diagnostics.Process> LiveProcesses = new List<System.Diagnostics.Process>();
            foreach (var item in ArrOfProcess)
            {
                LiveProcesses.Add(item);
            }

            ProcessMapping.ShowLiveProcesses(LiveProcesses);

            ConsoleKeyInfo consoleKeyInfo = new ConsoleKeyInfo();
            Arrow arrow = new Arrow(ArrOfProcess.Length, 1);
            arrow.SetCursorToStart();
            while (true)
            {
                consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.DownArrow) arrow.Down();
                else if (consoleKeyInfo.Key == ConsoleKey.UpArrow) arrow.Up();
                else if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    ProcessMapping.ShowLiveProcess(LiveProcesses[arrow.GetCurrentIndex]);
                    while (true)
                    {
                        consoleKeyInfo = Console.ReadKey();
                        if (consoleKeyInfo.Key == ConsoleKey.Escape)
                        {
                            ProcessMapping.ShowLiveProcesses(LiveProcesses);
                            arrow.SetCursorToStart();
                            break;
                        }
                        if (consoleKeyInfo.Key == ConsoleKey.D)
                        {
                            try
                            {
                                LiveProcesses[arrow.GetCurrentIndex].Kill();
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Вы не можете завершить этот процесс");
                            }
                            break;
                        }
                        if (consoleKeyInfo.Key == ConsoleKey.Delete)
                        {
                            string name = LiveProcesses[arrow.GetCurrentIndex].ProcessName;
                            var Processes = Process.GetProcessesByName(name);
                            try
                            {
                                foreach (var item in Processes) item.Kill();
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Вы не можете заврешить этот процесс");
                            }
                            break;
                        }
                    }
                }
            }


        }
    }
}
