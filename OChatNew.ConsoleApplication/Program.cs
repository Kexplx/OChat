using OChatNew.Core.Connection.Server;
using System;

namespace OChatNew.ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WriteLine("Server Side");
            Console.Write("Enter Port: ");
            new Server(int.Parse(Console
                                        .ReadLine()))
                                        .OpenServerForConnection();
        }
    }
}