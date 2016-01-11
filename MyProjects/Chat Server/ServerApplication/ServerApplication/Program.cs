using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ServerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            RunServer server = new RunServer();
            server.startServer();
            Console.ReadKey();
            /*
            // SERVER INFORMATION
            IPAddress serverIP = IPAddress.Parse("10.0.0.245");
            int port = 1234;
            Boolean isRunning = true;
            
            // CREATE SERVER
            TcpListener server = new TcpListener(serverIP, port);

            // START SERVER
            server.Start();

            // BUFFER FOR READING DATA
            byte[] bytes = new byte[1024];
            try {
                while (isRunning)
                {
                    // WAIT FOR CLIENT
                    Console.WriteLine("Waiting for a connection...");
                    TcpClient client = server.AcceptTcpClient();

                    // RESPONSE IF CONNECTION RECIEVED
                    Console.WriteLine("Connected!");

                    string data = null;

                    // GET STREAM FROM CLIENT AND READ INTO AN INTEGER
                    NetworkStream stream = client.GetStream();
                    int i;

                    while ((i = stream.Read(bytes,0,bytes.Length)) != 0)
                    {
                        // CONVERT DATABYTES INTO ASCII STRING
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Recieved: {0}", data);

                        // PREPARE STRING TO TELL CLIENT MESSAGE WAS RECIEVED
                        byte[] notify = System.Text.Encoding.ASCII.GetBytes("Message Recieved");

                        // SEND CLIENT NOTIFICATION
                        stream.Write(notify, 0, notify.Length);
                        Console.WriteLine("Notify sent");
                    }

                    client.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();*/
        }
    }
}
