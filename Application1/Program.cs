using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace Application1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your message to be sent");
            Console.WriteLine("High prioroty message mark as 'HP:' ");
            string MessageSend = Console.ReadLine();

            MessageQueue myQueue;
            if(MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                myQueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                myQueue = MessageQueue.Create(@".\Private$\MyQueue");
            }

            Message MyMessage = new System.Messaging.Message();

            MyMessage.Formatter = new BinaryMessageFormatter();
            MyMessage.Body = MessageSend;
            MyMessage.Label = "FromAppication1";
           

            if (MessageSend.Contains("Hi:"))
            {
                MyMessage.Priority = MessagePriority.Highest;
            }
            else
            {
                MyMessage.Priority = MessagePriority.Normal;
            }
            myQueue.Send(MyMessage);
            Console.WriteLine("Thangs for sending message");
            Console.ReadKey();
        }
    }
}
