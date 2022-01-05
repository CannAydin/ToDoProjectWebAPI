using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.TodoData;
using ToDoPojectWebAPI.Model.TodoModels.RequestModels;

namespace ToDoProjectWebAPI.Service.TodoServices
{
    public interface IGetAllTodosServiceRequest
    {
        Task<List<GetTodoDataModel>> GetAllTodos();
    }
    public class GetAllTodosServiceRequest:IGetAllTodosServiceRequest
    {
        private readonly IGetAllTodosDataRequest _getAllTodos;

        public GetAllTodosServiceRequest(IGetAllTodosDataRequest getAllTodos)
        {
            _getAllTodos = getAllTodos;         // getAllTodos IGetAllTodosDataRequest'ten geliyor.
        }

        public async Task<List<GetTodoDataModel>> GetAllTodos()
        {
            return await _getAllTodos.GetAllTodos();
        }
    }
}
