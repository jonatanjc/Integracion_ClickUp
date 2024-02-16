
namespace ClickUp.Models
{
    public class StatusModel
    {
        private string id { get; set; } = null!;

        public string? status { get; set; }

        public string? type { get; set; }

        public long orderindex { get; set; }

        public string? color { get; set; }

        public void Test()
        {
            id = "0001101010";
        }

        public void SetColor(string color)
        {
            this.color = color;
        }

        public string GetId()
        {
            return id;
        }
    }

}