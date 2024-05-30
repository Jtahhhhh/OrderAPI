using System.ComponentModel.DataAnnotations.Schema;

namespace internship.Database
{
    [Table("Order_Detail")]
    public class Order_detail
    {
        public int Order_Id { get; set; }
        public int Item_Id { get; set; }

        public string Price { get; set; }
        public string Quantity { get; set; }
        public string Note { get; set; }
    }
}
