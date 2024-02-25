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

        protected List<PaymentDto>? abonentPayments = new List<PaymentDto>();

        protected override async Task OnInitializedAsync()
        {
            abonentPayments = await PaymentService.GetPaymentsListByAbonent(AbonId);
            abonentPayments.OrderByDescending(d => d.PaymentDateTime);
        }

        protected bool paymentsReportVisible = true;
        protected void ShowPaymentsReport()
        {
            paymentsReportVisible = true;
        }
    }
}
