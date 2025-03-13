using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace assessment_backend_aspdotnet
{
    public class HealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var message = $"API is Up and Running";
            return Task.FromResult(HealthCheckResult.Healthy(message));
        }
    }
}
