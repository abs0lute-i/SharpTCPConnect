using System;
using System.Net;
using System.Net.Sockets;
namespace tcpprobe
{
    internal class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            //Make sure we were passed something, otherwise return help.
            if (args.Length < 2 || args[0].Equals("-help"))
            {
                Console.WriteLine("Usage is: tcpprobe [Host Name]/[Host IP] [Port]");
                return -1;
            }
            else
            {
                try
                {
                    // Connect to the specified host.
                    TcpClient t = new TcpClient(AddressFamily.InterNetwork);
                    string host = args[0];
                    int port = int.Parse(args[1]);
                    IPAddress[] IPAddresses = Dns.GetHostAddresses(host);

                    Console.WriteLine("Establishing connection to {0}", args[0]);
                    t.Connect(IPAddresses, port);

                    Console.WriteLine("Connection established");
                    return 0;
                }
                catch (System.Net.Sockets.SocketException se)
                {
                    // The system had problems resolving the address passed
                    Console.WriteLine(se.Message.ToString());
                    return -1;
                }
                catch (System.FormatException fe)
                {
                    // Non unicode chars were probably passed
                    Console.WriteLine(fe.Message.ToString());
                    return -1;
                }
            }
        }
    }
}