using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPojectWebAPI.Model.TodoModels.RequestModels
{
    public class DoneUndoneDataModel
    {
        public int Id { get; }
        public bool IsDone { get; set; }
        public int Progress { get; set; }
    }
}
