using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace IPSA.Web.Client.Pages.Abonent
{
    public class AbonentReportsBase : ComponentBase
    {
        [Parameter]
        public int AbonId { get; set; }
        [Inject]
        public required IPaymentService PaymentService { get; init; }
        [Inject]
        public required IReportService ReportService { get; init; }

        protected List<PaymentDto>? payments = new List<PaymentDto>();
        protected List<FeeWithdrawRecordDto>? feeWithdraws = new List<FeeWithdrawRecordDto>();
        protected DatePeriodDto paymentsDatePeriod = new DatePeriodDto();
        protected DatePeriodDto withdrawsDatePeriod = new DatePeriodDto();
        protected const string withdraw = "Списание";

        protected override async Task OnInitializedAsync()
        {
            paymentsDatePeriod = SetInitialDates(paymentsDatePeriod);
            withdrawsDatePeriod = SetInitialDates(withdrawsDatePeriod);
            await RefreshPaymentsReport();
            await RefreshWithdrawsReport();
            
        }
        protected DatePeriodDto SetInitialDates(DatePeriodDto datePeriodDto)
        {
            datePeriodDto.StartDate = new DateOnly(DateOnly.FromDateTime(DateTime.Now).Year, DateOnly.FromDateTime(DateTime.Now).Month, 1);
            datePeriodDto.EndDate = datePeriodDto.StartDate.AddMonths(1).AddDays(-1);
            return datePeriodDto;
        }

        protected bool paymentsReportVisible = true;
        protected void ShowPaymentsReport()
        {
            paymentsReportVisible = true;
            withdrawsReportVisible = !paymentsReportVisible;
        }
        protected async Task RefreshPaymentsReport()
        {
            payments = await ReportService.GetPaymentRecordsByAbonent(AbonId, paymentsDatePeriod);
            payments = payments.OrderBy(d => d.PaymentDateTime).ToList();
        }

        protected bool withdrawsReportVisible = false;
        protected void ShowWithdrawsReport()
        {
            withdrawsReportVisible = true;
            paymentsReportVisible = !withdrawsReportVisible;
        }
        protected async Task RefreshWithdrawsReport()
        {
            feeWithdraws = await ReportService.GetFeeWithdrawRecordsByAbonent(AbonId, withdrawsDatePeriod);
            feeWithdraws = feeWithdraws.OrderBy(d => d.CompletionDateTime).ToList();
        }
        
    }
}
