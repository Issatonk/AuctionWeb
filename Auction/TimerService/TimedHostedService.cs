using Auction.Managers.Lots;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.TimerService
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private Timer timer;
        private int i = 0;
        private int exCount = 0;


        public TimedHostedService()
        {
            
        }
        public void Dispose()
        {
            timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            
            Console.WriteLine("Фоновая служба запущена");
            timer = new Timer(DoWork, null, 10000, 1000);
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var count = Interlocked.Increment(ref exCount);
            Console.WriteLine(i++);
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Фоновая служба остановлена");
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
