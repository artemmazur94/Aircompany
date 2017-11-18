using System;

namespace Aircompany.DataAccess.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string CommentText { get; set; }
        public DateTime DateTime { get; set; }
        public int ProfileId { get; set; }
    
        public virtual Movie Movie { get; set; }
        public virtual Profile Profile { get; set; }
    }
}