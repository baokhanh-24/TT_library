using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class ratings
    {
        [Key]
        public int ratings_ID { get; set; }
        public int books_ID { get; set; }
        public int users_ID { get; set; }
        public int star { get; set; }
        public DateTime create_At { get; set; }
        public DateTime update_At { get; set; }
        public bool delete_Flag { get; set; }

        public virtual books books_r { get; set; }
        public virtual users users_r { get; set; }
    }
}
