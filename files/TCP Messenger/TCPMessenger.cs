using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
class Program
{
    static IPAddress ipadress;
    static int portToConnect;
    static void Main(string[] args)
    {
        Console.Title = "TCP ASCII message sender";
        while(true)
        {
            Console.Clear();
            Console.Write("     IP: ");
            string ip = Console.ReadLine();
            Console.Write("   PORT: ");
            string port = Console.ReadLine();
            Console.Write("MESSAGE: ");
            string message = Console.ReadLine();
            Console.Clear();

            try
            {
                ipadress = IPAddress.Parse(ip);
                portToConnect = Convert.ToInt32(port);
            }catch (Exception ex)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Sending \"{message}\" to {ip}:{port}?");
            Console.Write("Press \"y\" to continue or any otherkey to cancel");
            char key = Console.ReadKey().KeyChar;
            Console.WriteLine();
            try
            {
                if (key == 'y')
                {
                    TcpClient tcp = new TcpClient();
                    tcp.Connect(ipadress, portToConnect);
                    NetworkStream stream = tcp.GetStream();
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine();
                    Console.WriteLine("Message sent!");
                    int i;
                    while (true)
                    {
                        Console.ReadKey();
                        Console.Clear();
                        Console.Write("Enter new message: ");
                        message = Console.ReadLine();
                        Console.WriteLine($"Sending \"{message}\" to {ip}:{port}?");
                        Console.Write("Press \"y\" to continue or any otherkey to cancel");
                        key = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        try
                        {
                            if (key == 'y')
                            {
                                data = System.Text.Encoding.ASCII.GetBytes(message);
                                stream.Write(data, 0, data.Length);
                                Console.WriteLine();
                                Console.WriteLine("Message sent!");
                            }
                        }
                        catch { }
                    }
                }
            }catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Conenction failure!");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
