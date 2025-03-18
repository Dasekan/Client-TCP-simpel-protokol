using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net.Sockets;


public class Program
{
    private static void Main()
    {
        string serverIp = "127.0.0.1"; 
        int serverPort = 7;

        try
        {
            using (TcpClient client = new TcpClient(serverIp, serverPort))
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                
                Console.WriteLine("Enter command (Random, Add, Subtract):");
                string command = Console.ReadLine();
                writer.WriteLine(command);
                writer.Flush(); 

                string response = reader.ReadLine();
                Console.WriteLine("Server: " + response);

                
                Console.WriteLine("Enter two numbers separated by a space:");
                string numbers = Console.ReadLine();
                writer.WriteLine(numbers);
                writer.Flush(); 

                
                string result = reader.ReadLine();
                Console.WriteLine("Server result: " + result);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
