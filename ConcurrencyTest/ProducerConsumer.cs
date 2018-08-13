using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyTest
{
    public class ProducerConsumer<T>
    {
        BlockingCollection<T> bc = new BlockingCollection<T>();
        public delegate void ExecuteEventHandler(T arg);
        public event ExecuteEventHandler ExecuteEvent;
        public Task task;

        public int totalSent = 0;

        public int ItemsCount {
            get { return bc.Count; }
        }

        public void Add(T s)
        {
            bc.Add(s);
        }

        public void Start()
        {
            task = Task.Factory.StartNew(this.Consume, TaskCreationOptions.LongRunning);

        }

        private void Consume()
        {
            foreach (var item in bc.GetConsumingEnumerable())
            {
                totalSent++;
                ExecuteEvent(item);
                //Console.Write(item.ToString());
            }
        }
    }
}
