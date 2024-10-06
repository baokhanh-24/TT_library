using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class borrowingItem
    {
        [Key]
        public int borrowingItem_ID { get; set; }
        public int borrowings_ID { get; set; }
        public int books_ID { get; set; }
        public int quantity { get; set; }
        public DateTime create_At { get; set; }
        public DateTime update_At { get; set; }
        public bool delete_Flag { get; set; }

        public virtual borrowings Borrowings_bri { get; set; }
        public virtual books Books_bri { get; set; }
    }
}
