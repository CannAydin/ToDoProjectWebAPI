using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPojectWebAPI.Model.UserModels.RequestModels
{
    public class InsertUserDataModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
