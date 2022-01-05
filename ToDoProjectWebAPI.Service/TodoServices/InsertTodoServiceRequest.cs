using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.TodoData;
using ToDoPojectWebAPI.Model.TodoModels.RequestModels;

namespace ToDoProjectWebAPI.Service.TodoServices
{
    public interface IInsertTodoServiceRequest
    {
        Task<bool> InsertTodo(InsertTodoDataModel model);
    }
    public class InsertTodoServiceRequest:IInsertTodoServiceRequest
    {
        private readonly IInsertTodoDataRequest _insertTodoServiceRequest;

        public InsertTodoServiceRequest(IInsertTodoDataRequest insertTodoDataRequest)
        {
            _insertTodoServiceRequest = insertTodoDataRequest;
        }

        public async Task<bool> InsertTodo(InsertTodoDataModel model)
        {
            return await _insertTodoServiceRequest.InsertTodo(model);
        }
    }
}
