using System.ComponentModel.DataAnnotations;

namespace Contacts.Models

{
    public class Contacts
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public DateTime Created_Date_Time { get; set; } = DateTime.Now;
    }
}
