using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPojectWebAPI.Model.TodoModels.RequestModels
{
    public class GetProgressAndIdOfTodoDataModel
    {
        public int Id { get; }
        public int Progress { get; set; }
    }
}
