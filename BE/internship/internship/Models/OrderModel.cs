using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace internship.Model
{
    public class OrderModel
    {
        public int Order_Id { get; set; }
        public int Id { get; set; }
        public string Address { get; set; }

        public string State { get; set; }

        public string Total { get; set; }
        public DateTime Date_create { get; set; }
    }
}
