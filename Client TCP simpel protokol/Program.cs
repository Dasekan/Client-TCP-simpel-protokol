using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net.Sockets;


public class ClientProgram
{
    private static StreamReader _reader;
    private static StreamWriter _writer;

    public static void Main()
    {
        Console.WriteLine("Connecting to server...");
        // Connect to the server (adjust the IP and port)
        TcpClient client = new TcpClient("127.0.0.1", 7);
        NetworkStream stream = client.GetStream();
        _reader = new StreamReader(stream);
        _writer = new StreamWriter(stream);

        Console.WriteLine("Connected to server.");

        // Interact with the user
        while (true)
        {
            Console.WriteLine("Enter command (Random, Add, Subtract) or 'exit' to quit:");
            string command = Console.ReadLine();

            if (command.ToLower() == "exit")
            {
                break;
            }

            // Send the command to the server
            _writer.WriteLine(command);
            _writer.Flush();

            // Wait for server's response
            string response = _reader.ReadLine();
            Console.WriteLine("Server: " + response);

            if (command == "Random" || command == "Add" || command == "Subtract")
            {
                Console.WriteLine("Enter two numbers separated by space:");
                string numbers = Console.ReadLine();

                // Send the numbers to the server
                _writer.WriteLine(numbers);
                _writer.Flush();

                // Wait for result from the server
                string result = _reader.ReadLine();
                Console.WriteLine("Result: " + result);
            }
        }

        // Close the connection
        client.Close();
    }
}