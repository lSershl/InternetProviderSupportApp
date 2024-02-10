using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using IPSA.Web.Client.Services;
using Microsoft.AspNetCore.Components;

namespace IPSA.Web.Client.Pages.Abonent
{
    public class AbonentInfoBase : ComponentBase
    {
        [Parameter]
        public int abon_id { get; set; }
        [Inject]
        public required IAbonentService AbonentService { get; set; }
        [Inject]
        public required IPaymentService PaymentService { get; set; }
        [Inject]
        public required NavigationManager navManager { get; set; }

        public required AbonentReadDto abonent = new AbonentReadDto();
        public PaymentDto payment = new PaymentDto();
        //public IEnumerable<AbonPageComment>? abonPageComments;
        //public AbonPageComment newComment = new AbonPageComment();
        //public AbonPageComment commentToEdit = new AbonPageComment();
        //public AbonPageComment commentToDelete = new AbonPageComment();

        protected decimal paymentAmount = 0;
        protected string? paymentComment;
        protected string? newCommentText;
        protected string? editCommentText;

        protected bool paymentPopup { get; set; }
        protected bool addCommentPopup { get; set; }
        protected bool editCommentPopup { get; set; }
        protected bool deleteCommentPopup { get; set; }

        protected override async Task OnInitializedAsync()
        {
            abonent = await AbonentService.GetAbonent(abon_id);
            //abonPageComments = commentsHandler.GetCommentsByAbonent(abon_id).OrderByDescending(x => x.comm_date_t);
            payment.PaymentType = "Наличными в офисе";
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

        protected void AcceptPayment(decimal paymentAmount, string paymentComment)
        {
            payment.AbonentId = abon_id;
            payment.ManagerId = 1;
            payment.PaymentDateTime = DateTime.UtcNow;
            payment.Comment = paymentComment;
            payment.Amount = paymentAmount;
            PaymentService.AddNewPayment(payment);
            AbonentService.ApplyPaymentToAbonentBalance(payment);
            paymentPopup = false;
            navManager.NavigateTo($"/Abonent/{abon_id}/Info/", true);
        }

        protected void GoToEditPage()
        {
            navManager.NavigateTo($"/Abonent/{abon_id}/Edit");
        }

        protected void GoToReportsPage()
        {
            navManager.NavigateTo($"/Abonent/{abon_id}/Reports");
        }

        protected void ShowAddCommentPopup()
        {
            addCommentPopup = true;
        }

        protected void CloseAddCommentPopup()
        {
            addCommentPopup = false;
        }

        //protected void AddNewComment(AbonPageComment new_comment)
        //{
        //    new_comment.comment_id = 0;
        //    new_comment.abon_id = abon.abon_id;
        //    new_comment.manager_id = 1;
        //    new_comment.comm_text = newCommentText;
        //    new_comment.comm_date_t = DateTime.UtcNow;
        //    commentsHandler.AddComment(new_comment);
        //    addCommentPopup = false;
        //    navManager.NavigateTo($"/abon/info/{abon_id}", true);
        //}

        //protected void ShowEditCommentPopup(int commentId)
        //{
        //    commentToEdit = commentsHandler.GetSingleComment(commentId);
        //    editCommentText = commentToEdit.comm_text;
        //    editCommentPopup = true;
        //}

        //protected void CloseEditCommentPopup()
        //{
        //    editCommentPopup = false;
        //}

        //protected void SaveEditedComment(AbonPageComment commentToEdit)
        //{
        //    commentToEdit.comm_text = editCommentText;
        //    commentsHandler.UpdateComment(commentToEdit);
        //    editCommentPopup = false;
        //    navManager.NavigateTo($"/abon/info/{abon_id}", true);
        //}

        //protected void ShowDeleteCommentPopup(int commentId)
        //{
        //    commentToDelete = commentsHandler.GetSingleComment(commentId);
        //    deleteCommentPopup = true;
        //}

        //protected void CloseDeleteCommentPopup()
        //{
        //    deleteCommentPopup = false;
        //}

        //protected void DeleteComment(AbonPageComment commentToDelete)
        //{
        //    commentsHandler.DeleteComment(commentToDelete);
        //    deleteCommentPopup = false;
        //    navManager.NavigateTo($"/abon/info/{abon_id}", true);
        //}
    }
}
