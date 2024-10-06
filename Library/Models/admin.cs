using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class admin
    {
        [Key]
        public int admin_ID { get; set; }
        public string name { get; set; }
        public string admin_Name { get; set; }
        public string Password { get; set; }
        public DateTime create_At { get; set; }
        public DateTime update_At { get; set; }
        public bool delete_Flag { get; set; }
    }
}
