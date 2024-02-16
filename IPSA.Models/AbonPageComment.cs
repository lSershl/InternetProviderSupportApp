using System.ComponentModel.DataAnnotations;

namespace IPSA.Models
{
    public class AbonPageComment
    {
        public required int Id { get; set; }
        public required int AbonentId { get; set; }
        public required int EmployeeId { get; set; }
        public required string Text { get; set; }
        public required DateTime CommentDateTime { get; set; }
    }
}
