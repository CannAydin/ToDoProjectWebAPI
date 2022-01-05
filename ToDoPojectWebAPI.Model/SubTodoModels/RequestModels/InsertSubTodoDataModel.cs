using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPojectWebAPI.Model.SubTodoModels.RequestModels
{
    public class InsertSubTodoDataModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Ratio { get; set; }
        public bool IsDone { get; set; }
    }
}
