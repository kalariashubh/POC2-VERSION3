using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

class Program
{
    static string triggerPath =
        @"D:\Buniyad Byte\POC 2\svf-dwg-dbId-boundary\server\storage\run_autocad.flag";

    static string acadExe =
        @"C:\Program Files\Autodesk\AutoCAD 2022\acad.exe";

    static string scriptPath =
        @"D:\Buniyad Byte\POC 2\svf-dwg-dbId-boundary\autocad-plugin\run.scr";

    static void Main()
    {
        Console.WriteLine("🟢 AutoCAD Automation Agent started");

        while (true)
        {
            if (File.Exists(triggerPath))
            {
                Console.WriteLine("📌 Trigger detected");
                RunAutoCAD();
                File.Delete(triggerPath);
                Console.WriteLine("✅ Done & trigger cleared");
            }

            Thread.Sleep(2000);
        }
    }

    static void RunAutoCAD()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = acadExe,
            Arguments = $"/b \"{scriptPath}\"",
            UseShellExecute = true
        });

        // wait for AutoCAD to finish
        Thread.Sleep(30000);
    }
}
