using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.SubTodoData;
using ToDoPojectWebAPI.Model.SubTodoModels.RequestModels;

namespace ToDoProjectWebAPI.Service.SubTodoServices
{
    public interface IGetAllSubTodosServiceRequest
    {
        Task<List<GetSubTodoDataModel>> GetAllSubTodos();
    }
    public class GetAllSubTodosServiceRequest:IGetAllSubTodosServiceRequest
    {
        private readonly IGetAllSubTodosDataRequest _getAllSubTodosDataRequest;

        public GetAllSubTodosServiceRequest(IGetAllSubTodosDataRequest getAllSubTodosDataRequest)
        {
            _getAllSubTodosDataRequest = getAllSubTodosDataRequest;
        }

        public async Task<List<GetSubTodoDataModel>> GetAllSubTodos()
        {
            return await _getAllSubTodosDataRequest.GetAllSubTodos();
        }
    }
}
