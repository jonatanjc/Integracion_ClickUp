using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickUp.Models
{
    public class User
    {
        public long id { get; set; }

        public string username { get; set; }

        public string color { get; set; }

        public object profilePicture { get; set; }

        public string initials { get; set; }
    }
}
