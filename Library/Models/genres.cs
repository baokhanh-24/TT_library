using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class genres
    {
        [Key]
        public int genres_ID { get; set; }
        public string name { get; set; }
        public DateTime create_At { get; set; }
        public DateTime update_At { get; set; }
        public bool delete_Flag { get; set; }

        public virtual ICollection<books> Books_g { get; set; }
    }
}
