using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.TodoData;
using ToDoPojectWebAPI.Model.TodoModels.RequestModels;

namespace ToDoProjectWebAPI.Service.TodoServices
{
    public interface IUpdateTodoByIdServiceRequest
    {
        Task<bool> UpdateTodoById(int todoId, InsertTodoDataModel model);
    }
    public class UpdateTodoByIdServiceRequest:IUpdateTodoByIdServiceRequest 
    {
        private readonly IUpdateTodoByIdDataRequest _updateTodoByIdServiceRequest;

        public UpdateTodoByIdServiceRequest(IUpdateTodoByIdDataRequest updateTodoByIdDataRequest)
        {
            _updateTodoByIdServiceRequest = updateTodoByIdDataRequest;
        }

        public async Task<bool> UpdateTodoById(int todoId, InsertTodoDataModel model)
        {
            return await _updateTodoByIdServiceRequest.UpdateTodoById(todoId, model);
        }
    }
}
