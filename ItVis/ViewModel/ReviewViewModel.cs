using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItVis.ViewModel
{
    [Table("vProductReviews")]
    public class ReviewViewModel
    {
        [Column("Review_Id")]
        public int Id { get; set; }
        [Column("Product_Id")]
        public int ProductId { get; set; }
        [Column("User_Id")]
        public int? UserId { get; set; }
        [Column("User_Name")]
        public string? UserName { get; set; } 
        [Column("Comment_Text")]
        public string Comment { get; set; } = null!;
        [Column("Comment_Date")]
        public DateTime CommentDate { get; set; } = DateTime.Now; 
    }
}
