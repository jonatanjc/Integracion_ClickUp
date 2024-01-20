using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickUp.Models.DTO
{
    public class FolderDto
    {
        public string id { get; set; }

        public string name { get; set; }

        public bool hidden { get; set; }

        public bool access { get; set; }
    }
}
