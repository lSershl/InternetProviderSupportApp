using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace IPSA.Web.Client.Pages.Abonent
{
    public class AbonentInfoBase : ComponentBase
    {
        [Parameter]
        public int AbonId { get; set; }
        [Inject]
        public required IAbonentService AbonentService { get; init; }
        [Inject]
        public required IPaymentService PaymentService { get; init; }
        [Inject]
        public required IAbonPageCommentService CommentService { get; init; }
        [Inject]
        public required NavigationManager navManager { get; init; }

        protected AbonentReadDto abonent = new AbonentReadDto();
        protected List<AbonPageCommentDto>? abonPageComments = new List<AbonPageCommentDto>();

        protected override async Task OnInitializedAsync()
        {
            abonent = await AbonentService.GetAbonent(AbonId);
            abonPageComments = await CommentService.GetAbonentPageComments(AbonId);
            abonPageComments.OrderByDescending(d => d.CommentDateTime);
            payment.PaymentType = "Наличными в офисе";
        }

        protected void GoToEditPage()
        {
            navManager.NavigateTo($"/Abonent/{AbonId}/Edit");
        }

        protected void GoToReportsPage()
        {
            navManager.NavigateTo($"/Abonent/{AbonId}/Reports");
        }

        protected bool paymentPopup { get; set; }
        protected PaymentDto payment = new PaymentDto();
        protected decimal paymentAmount = 0;
        protected string? paymentComment;
        
        protected void AcceptPayment(decimal paymentAmount, string paymentComment)
        {
            payment.AbonentId = AbonId;
            payment.ManagerId = 1;
            payment.PaymentDateTime = DateTime.UtcNow;
            payment.Comment = paymentComment;
            payment.Amount = paymentAmount;
            PaymentService.AddNewPayment(payment);
            AbonentService.ApplyPaymentToAbonentBalance(payment);
            paymentPopup = false;
            navManager.NavigateTo($"/Abonent/{AbonId}/Info/", true);
        }
        
        protected void ShowPaymentPopup()
        {
            paymentPopup = true;
        }

        protected void ClosePaymentPopup()
        {
            paymentAmount = 0;
            paymentComment = string.Empty;
            paymentPopup = false;
        }

        protected bool addCommentPopup { get; set; }
        protected AbonPageCommentDto newComment = new AbonPageCommentDto();
        protected string? newCommentText;
        protected void AddNewComment(AbonPageCommentDto newComment)
        {
            newComment.Id = 0;
            newComment.AbonentId = AbonId;
            newComment.EmployeeId = 1;
            newComment.Text = newCommentText;
            newComment.CommentDateTime = DateTime.UtcNow;
            CommentService.AddNewAbonentPageComment(newComment);
            addCommentPopup = false;
            navManager.NavigateTo($"/Abonent/{AbonId}/Info/", true);
        }

        protected void ShowAddCommentPopup()
        {
            addCommentPopup = true;
        }

        protected void CloseAddCommentPopup()
        {
            addCommentPopup = false;
        }

        protected bool editCommentPopup { get; set; }
        protected AbonPageCommentDto commentToEdit = new AbonPageCommentDto();
        protected string? editCommentText;
        protected void SaveEditedComment(AbonPageCommentDto commentToEdit)
        {
            commentToEdit.Text = editCommentText;
            CommentService.UpdateAbonPageComment(commentToEdit);
            editCommentPopup = false;
            navManager.NavigateTo($"/Abonent/{AbonId}/Info/", true);
        }

        protected void ShowEditCommentPopup(int commentId)
        {
            commentToEdit = abonPageComments!.Find(x => x.Id == commentId)!;
            editCommentText = commentToEdit.Text;
            editCommentPopup = true;
        }

        protected void CloseEditCommentPopup()
        {
            editCommentPopup = false;
        }

        protected bool deleteCommentPopup { get; set; }
        protected AbonPageCommentDto commentToDelete = new AbonPageCommentDto();

        protected void DeleteComment(AbonPageCommentDto commentToDelete)
        {
            CommentService.DeleteAbonPageComment(commentToDelete.Id);
            deleteCommentPopup = false;
            navManager.NavigateTo($"/Abonent/{AbonId}/Info/", true);
        }

        protected void ShowDeleteCommentPopup(int commentId)
        {
            commentToDelete = abonPageComments!.Find(x => x.Id == commentId)!;
            deleteCommentPopup = true;
        }

        protected void CloseDeleteCommentPopup()
        {
            deleteCommentPopup = false;
        }
    }
}
