using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickUp.Models
{
    public class ResponseTask
    {
        public List<TaskModel> tasks { get; set; } = new List<TaskModel>();

        public bool last_page { get; set; }
    }
}
