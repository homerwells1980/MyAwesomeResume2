using System;

namespace MyAwesomeResume
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeHttpServer fakeHttpServer = new FakeHttpServer();
            fakeHttpServer.Start();

            Console.ReadLine();

            fakeHttpServer.Stop();
        }
    }
}

