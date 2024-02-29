using IPSA.API.Services.Contarcts;

namespace IPSA.API.Services
{
    public class FeeCollectionBackgroundService(IServiceProvider serviceProvider) : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var now = DateTime.Now;
            var hours = 23 - now.Hour;
            var minutes = 60 - now.Minute;
            var seconds = 60 - now.Second;
            var secondsUntilMidnight = hours * 3600 + minutes * 60 + seconds;

            await Task.Delay(TimeSpan.FromSeconds(secondsUntilMidnight), stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var feeService = scope.ServiceProvider.GetRequiredService<ITariffFeeService>();

                    var todayMonthlyFees = feeService.CheckIncompleteMonthlyFees();
                    if (todayMonthlyFees.Count > 0)
                    {
                        feeService.CollectMonthlyFees(todayMonthlyFees);
                    }
                    feeService.CollectDailyFees();
                    

                }
                catch (Exception ex)
                {
                    // Log Exception
                }
            }
        }
    }
}
