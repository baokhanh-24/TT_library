using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class borrowings
    {
        [Key]
        public int borrowings_ID { get; set; }
        public int users_ID { get; set; }
        public DateTime start_At { get; set; }
        public DateTime end_At { get; set; }
        public DateTime actual_End_At { get; set; }
        public DateTime create_At { get; set; }
        public DateTime update_At { get; set; }
        public bool delete_Flag { get; set; }

        public virtual users Users_br { get; set; }
        public virtual ICollection<borrowingItem> BorrowingItem_br { get; set; }
    }
}
