using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace internship.Database
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public string Item_Id { get; set; }
        public string Item_Name { get; set; }
        public string Item_Description { get; set; }
        public string Category_id { get; set; }
        [ForeignKey(nameof(Category_id))]
        public string Item_Prie { get; set;}
    }
}
