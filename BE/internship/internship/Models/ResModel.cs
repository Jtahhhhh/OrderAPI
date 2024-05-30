namespace internship.Models
{
    public class ResModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public ResModel(int success, string message, object? data = null)
        {
            Status = success;
            Message = message;
            Data = Data;
        }
    }
}
