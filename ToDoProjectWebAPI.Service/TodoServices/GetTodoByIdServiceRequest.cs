using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.TodoData;
using ToDoPojectWebAPI.Model.TodoModels.RequestModels;

namespace ToDoProjectWebAPI.Service.TodoServices
{
    public interface IGetTodoByIdServiceRequest
    {
        Task<GetTodoDataModel> GetTodoById(int todoId);
    }
    public class GetTodoByIdServiceRequest:IGetTodoByIdServiceRequest
    {
        private readonly IGetTodoByIdDataRequest _getTodoByIdDataRequest;

        public GetTodoByIdServiceRequest(IGetTodoByIdDataRequest getTodoByIdDataRequest)
        {
            _getTodoByIdDataRequest = getTodoByIdDataRequest;       // getTodoByIdDataRequest IGetTodoByIdDataRequest'ten geliyor
        }

        public async Task<GetTodoDataModel> GetTodoById(int todoId)
        {
            return await _getTodoByIdDataRequest.GetTodoById(todoId);
        }
    }
}
