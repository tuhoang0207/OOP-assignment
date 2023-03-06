﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class Y2Server
{

    private const int BUFFER_SIZE = 1024;
    private const int PORT_NUMBER = 9999;

    static ASCIIEncoding encoding = new ASCIIEncoding();

    public static void Main()
    {
        try
        {
            IPAddress address = IPAddress.Parse("127.0.0.1");

            TcpListener listener = new TcpListener(address, PORT_NUMBER);

            // 1. listen
            listener.Start();

            Console.WriteLine("Server started on " + listener.LocalEndpoint);
            Console.WriteLine("Waiting for a connection...");

            Socket socket = listener.AcceptSocket();
            Console.WriteLine("Connection received from " + socket.RemoteEndPoint);

            var stream = new NetworkStream(socket);
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            while (true)
            {
                // 2. receive
                string str = reader.ReadLine();
                if (str.ToUpper() == "EXIT")
                {
                    writer.WriteLine("bye");
                    break;
                }
                // 3. send
                writer.WriteLine(socket.RemoteEndPoint + " : " + str);
            }
            // 4. close
            stream.Close();
            socket.Close();
            listener.Stop();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex);
        }
        Console.Read();
    }
}