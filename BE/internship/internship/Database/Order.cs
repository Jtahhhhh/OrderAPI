using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace internship.Database
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Order_Id {  get; set; }
        public int Id {  get; set; }
        [ForeignKey(nameof(Id))]
        public string Address { get; set; }

        public string State {  get; set; }

        public string Total { get; set; }

        public DateTime Date_create { get; set; }
        public DateTime Date_update { get; set;}
        

    }
}
