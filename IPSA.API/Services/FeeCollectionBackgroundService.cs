using IPSA.API.Services.Contarcts;

namespace IPSA.API.Services
{
    public class FeeCollectionBackgroundService(IServiceProvider serviceProvider) : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        bool StartOrRestart { get; set; } = true;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (StartOrRestart)
                {
                    try
                    {
                        using var scope = _serviceProvider.CreateScope();
                        var feeService = scope.ServiceProvider.GetRequiredService<ITariffFeeService>();

                        var oldMonthlyFees = feeService.CheckCompletedMonthlyFeesForRemoval();
                        feeService.RemoveCompletedMonthlyFeesOfLastMonth(oldMonthlyFees);
                        var oldDailyFees = feeService.CheckCompletedDailyFeesForRemoval();
                        feeService.RemoveCompletedDailyFees(oldDailyFees);

                        var todayMonthlyFees = feeService.CheckIncompleteMonthlyFees();
                        if (todayMonthlyFees.Count > 0)
                        {
                            feeService.CollectMonthlyFees(todayMonthlyFees);
                        }
                        var todayDailyFees = feeService.CheckIncompleteDailyFees();
                        if (todayDailyFees.Count > 0)
                        {
                            feeService.CollectDailyFees(todayDailyFees);
                        }
                        StartOrRestart = false;
                    }
                    catch (Exception ex)
                    {
                        // Log Exception
                    }

                }
                else
                {
                    await Task.Delay(TimeSpan.FromSeconds(EstimateSecondsUntilMidnight() + 60), stoppingToken);

                    try
                    {
                        using var scope = _serviceProvider.CreateScope();
                        var feeService = scope.ServiceProvider.GetRequiredService<ITariffFeeService>();

                        var oldMonthlyFees = feeService.CheckCompletedMonthlyFeesForRemoval();
                        feeService.RemoveCompletedMonthlyFeesOfLastMonth(oldMonthlyFees);
                        var oldDailyFees = feeService.CheckCompletedDailyFeesForRemoval();
                        feeService.RemoveCompletedDailyFees(oldDailyFees);

                        feeService.FormDailyFeesForToday();

                        var todayMonthlyFees = feeService.CheckIncompleteMonthlyFees();
                        if (todayMonthlyFees.Count > 0)
                        {
                            feeService.CollectMonthlyFees(todayMonthlyFees);
                        }
                        var todayDailyFees = feeService.CheckIncompleteDailyFees();
                        if (todayDailyFees.Count > 0)
                        {
                            feeService.CollectDailyFees(todayDailyFees);
                        }

                    }
                    catch (Exception ex)
                    {
                        // Log Exception
                    }
                }
            }
        }

        private int EstimateSecondsUntilMidnight()
        {
            var now = DateTime.Now;
            var hours = 23 - now.Hour;
            var minutes = 60 - now.Minute;
            var seconds = 60 - now.Second;
            var secondsUntilMidnight = hours * 3600 + minutes * 60 + seconds;
            return secondsUntilMidnight;
        }
    }
}
