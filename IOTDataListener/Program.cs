using System;

namespace IOTDataListener
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LISTENER 1 : Listening to the server....");
            Listener listener = new Listener();
            listener.Initialize();
            listener.RecieveMessage();
            Console.WriteLine("Press escape to close connection");
            Console.ReadKey();
            OnEscapePressed(listener);
        }

        private static void OnEscapePressed(Listener listener)
        {
            do
            {
                while (!Console.KeyAvailable)
                {
                    listener.Close();
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
