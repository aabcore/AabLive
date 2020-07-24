using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AabLive.Workers
{
    public class WorkerHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            var lastProcessTime = WorkerStatistics.GetLastProcessTime();
            var timeAgo = DateTimeOffset.UtcNow.Subtract(lastProcessTime);

            return Task.FromResult(lastProcessTime > DateTime.Now.AddSeconds(-90)
                ? HealthCheckResult.Healthy("Processing Healthy")
                : HealthCheckResult.Unhealthy("Not healthy."));
        }
    }
}