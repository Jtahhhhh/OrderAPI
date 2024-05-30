using internship.Database;

namespace internship.Controllers.SubmitModels
{
    public class EditOrderForm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Quanity { get; set; }
        public string Address { get; set; }
        public Item[] item { get; set; }
    }
}
