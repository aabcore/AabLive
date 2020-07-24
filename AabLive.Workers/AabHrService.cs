using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AabLive.Workers
{
    //https://www.johanohlin.com/blog/worker-service-in-kubernetes-with-health-checks/
    public class AabHrService: BackgroundService
    {
        private readonly ILogger<AabHrService> _logger;
        private readonly Random _rand;

        public AabHrService(ILogger<AabHrService> logger)
        {
            _logger = logger;
            _rand = new Random();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                if (i < 10)
                {
                    _logger.LogInformation($"I'm doing HR Work at {DateTimeOffset.Now:O}");
                    WorkerStatistics.SetProcessTime();
                    i++;
                }
                else
                {
                    _logger.LogError($"Uh oh! Haven't Processed for {DateTimeOffset.Now.Subtract(WorkerStatistics.GetLastProcessTime()).TotalSeconds} seconds!");
                }
                await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
            }
        }
    }

    public class AabTellerService: BackgroundService
    {
        private readonly ILogger<AabHrService> _logger;
        private readonly Random _rand;

        public AabTellerService(ILogger<AabHrService> logger)
        {
            _logger = logger;
            _rand = new Random();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                if (i < 10)
                {
                    _logger.LogInformation($"I'm doing Teller Work at {DateTimeOffset.Now:O}");
                    WorkerStatistics.SetProcessTime();
                    i++;
                }
                else
                {
                    _logger.LogError($"Uh oh! Haven't Processed for {DateTimeOffset.Now.Subtract(WorkerStatistics.GetLastProcessTime()).TotalSeconds} seconds!");
                }
                await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
            }
        }
    }
}
