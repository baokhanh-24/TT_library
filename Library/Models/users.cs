using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class users
    {
        [Key]
        public int users_ID { get; set; }
        public string name { get; set; }
        public string user_Name { get; set; }
        public string password { get; set; }
        public DateTime create_At { get; set; }
        public DateTime update_At { get; set; }
        public bool delete_Flag { get; set; }

        public virtual ICollection<ratings> ratings_u { get; set; }
        public virtual ICollection<borrowings> Borrowings_br { get; set; }
    }
}
