using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace internship.Database
{
    [Table("Category")]
    public class Catagory
    {
        [Key]
        public string Category_id { get; set; }
        public string Category_name { get; set; }
        public string Catagory_description { get; set;}
    }
}
