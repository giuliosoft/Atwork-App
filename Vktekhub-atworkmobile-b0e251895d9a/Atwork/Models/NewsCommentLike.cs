namespace Atwork.Models
{
    using System;
    
    public partial class NewsCommentLike
    {
        public int Id { get; set; }
        public int newsCommentId { get; set; }
        public string likeByID { get; set; }
        public DateTime? likeDate { get; set; }
    }
}
