﻿namespace IPSA.Shared.Dtos
{
    public class AbonPageCommentDto
    {
        public int Id { get; set; }
        public int AbonentId { get; set; }
        public int EmployeeId { get; set; }
        public string? Text { get; set; }
        public DateTime CommentDateTime { get; set; }
    }
}
