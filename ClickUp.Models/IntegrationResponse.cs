using ClickUp.Moldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickUp.Models
{
    public class IntegrationResponse
    {
        public List<SpaceModel> spaces { get; set; }
        public List<FolderModel> folders { get; set; }
        public TaskModel task { get; set; }
        public List<ListModel> lists { get; set; }
    }
}
//