using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = Path.Combine(Directory.GetCurrentDirectory(), "background_analysis.exe"), //Make sure the file name is correct, I am changing names a lot!
            CreateNoWindow = true,
            UseShellExecute = false,

        };
        Process process = new Process
        {
            StartInfo = psi,
        };
        process.Start();
    }
}
