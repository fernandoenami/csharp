using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyTest
{
    public class MultipleTasks
    {
        int qtyClients = 40;
        int qtyMsg = 50000;

        public ProducerConsumer<string> mainProcess;
        public Client[] clients;
        

        public MultipleTasks()
        {
            mainProcess = new ProducerConsumer<string>();
            mainProcess.ExecuteEvent += MainProcess_ExecuteEvent1;
            mainProcess.Start();

            clients = new Client[qtyClients];
            for (int i = 0; i < qtyClients; i++)
            {
                clients[i] = new Client();
                clients[i].name = "client" + i;
            }

            
        }

        private void MainProcess_ExecuteEvent1(string arg)
        {
            Thread.SpinWait(1000);

            foreach (var cli in clients)
            {
                cli.SendMessage(arg);
            }
        }


        public void Run()
        {
            for (int i = 0; i < qtyMsg; i++)
            {
                mainProcess.Add("item " + i);
            }

            int total = 0;
            do
            {
                total = 0;
                foreach (var item in clients)
                {
                    total += item.clientProcess.totalSent;
                }
            } while (total < qtyMsg * qtyClients);

            Console.WriteLine("clients: "+ qtyClients);
            Console.WriteLine("msgs: " + qtyMsg);
            Console.WriteLine("totalsent: " + total);
            //Task.WaitAll(clientTasks.ToArray());
        }

    }
}
