using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTN.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public double Reliability { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public string ImagePath { get; set; }
        public bool Status { get; set; } = false;

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
