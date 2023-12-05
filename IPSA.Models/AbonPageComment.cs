using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPSA.Models
{
    //[Table ("AbonPageComments", Schema = "public")]
    public class AbonPageComment
    {
        [Key]
        public required int Id { get; set; }
        public required int AbonentId { get; set; }
        public required int EmployeeId { get; set; }
        public required string Text { get; set; }
        public required DateTime CommentDateTime { get; set; }
    }
}
