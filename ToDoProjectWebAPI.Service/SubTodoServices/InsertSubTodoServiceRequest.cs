using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.SubTodoData;
using ToDoPojectWebAPI.Model.SubTodoModels.RequestModels;

namespace ToDoProjectWebAPI.Service.SubTodoServices
{
    public interface IInsertSubTodoServiceRequest
    {
        Task<bool> InsertSubTodo(int todoId, int userId, InsertSubTodoDataModel model);
    }
    public class InsertSubTodoServiceRequest:IInsertSubTodoServiceRequest
    {
        private readonly IInsertSubTodoDataRequest _insertSubTodoDataRequest;

        public InsertSubTodoServiceRequest(IInsertSubTodoDataRequest insertSubTodoDataRequest)
        {
            _insertSubTodoDataRequest = insertSubTodoDataRequest;
        }

        public async Task<bool> InsertSubTodo(int todoId, int userId, InsertSubTodoDataModel model)
        {
            return await _insertSubTodoDataRequest.InsertSubTodo(todoId, userId, model);
        }
    }
}
