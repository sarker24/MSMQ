using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Application2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Latest message");
            MessageQueue myQueue;
            myQueue = new MessageQueue(@".\Private$\MyQueue");

            Message MyMessage = myQueue.Receive();
            MyMessage.Formatter = new BinaryMessageFormatter();

            Console.WriteLine(MyMessage.Body.ToString());
            Console.ReadKey();

        }
    }
}
