using System;

namespace IOTDataSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Sendor sendor = new Sendor();
            sendor.Initialize();
            sendor.SendMessage();
            Console.ReadKey();
        }
    }
}
