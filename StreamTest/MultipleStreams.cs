using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StreamTest
{
    public class MultipleStreams
    {
        int qtyClients = 40;
        int qtyMsg = 50000;

        public Subject<string> mainStream;
        public Client[] clients;
        

        public MultipleStreams()
        {
            mainStream = new Subject<string>();

            clients = new Client[qtyClients];
            for (int i = 0; i < qtyClients; i++)
            {
                clients[i] = new Client(mainStream);
                clients[i].name = "client" + i;
            }

            
        }


        public void Run()
        {
            for (int i = 0; i < qtyMsg; i++)
            {
                Thread.SpinWait(1000);
                mainStream.OnNext("item " + i);
            }

            int total = 0;
            do
            {
                total = 0;
                foreach (var item in clients)
                {
                    total += item.totalSent;
                }
            } while (total < qtyMsg * qtyClients);

            Console.WriteLine("clients: "+ qtyClients);
            Console.WriteLine("msgs: " + qtyMsg);
            Console.WriteLine("totalsent: " + total);
            //Task.WaitAll(clientTasks.ToArray());
        }

    }
}
