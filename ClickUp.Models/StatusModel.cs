
namespace ClickUp.Models
{
    public class StatusModel
    {
        public string id { get; set; } = null!;

        public string? status { get; set; }

        public string? type { get; set; }

        public long orderindex { get; set; }

        public string? color { get; set; }
    }
}