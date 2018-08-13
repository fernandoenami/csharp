using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyTest
{
   public class Client
    {
        public ProducerConsumer<string> clientProcess;
        public string name;

        public Client()
        {
            clientProcess = new ProducerConsumer<string>();
            clientProcess.ExecuteEvent += ProducerConsumer_ExecuteEvent;
            clientProcess.Start();
        }

        private void ProducerConsumer_ExecuteEvent(string arg)
        {
            Thread.SpinWait(1000);
            //Console.WriteLine(" sendMessage: " + arg +" to "+ name);
        }

        public void SendMessage(string s)
        {
            clientProcess.Add(s);
        }

    }
}
