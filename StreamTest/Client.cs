using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StreamTest
{
   public class Client
    {
        public string name;
        internal int totalSent;

        public Client(Subject<string> mainStream)
        {
            mainStream.Subscribe(SendMessage);
        }


        public void SendMessage(string s)
        {
            Thread.SpinWait(1000);
            //Console.WriteLine(" sendMessage: " + s + " to " + name);
            totalSent++;
        }

    }
}
