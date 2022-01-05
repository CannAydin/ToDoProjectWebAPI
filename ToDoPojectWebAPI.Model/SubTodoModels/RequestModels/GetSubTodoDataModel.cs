using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPojectWebAPI.Model.SubTodoModels.RequestModels
{
    public class GetSubTodoDataModel
    {
        public int Id { get; }
        public int TodoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Ratio { get; set; }
        public int UserId { get; set; }
        public bool IsDone { get; set; }
        
    }
}
