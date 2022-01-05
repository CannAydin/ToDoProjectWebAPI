using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.SubTodoData;
using ToDoPojectWebAPI.Model.SubTodoModels.RequestModels;

namespace ToDoProjectWebAPI.Service.SubTodoServices
{
    public interface IGetSubTodoByIdServiceRequest
    {
        Task<GetSubTodoDataModel> GetSubTodoById(int subTodoId);
    }
    public class GetSubTodoByIdServiceRequest:IGetSubTodoByIdServiceRequest
    {
        private readonly IGetSubTodoByIdDataRequest _getSubTodoByIdDataRequest;
        public GetSubTodoByIdServiceRequest(IGetSubTodoByIdDataRequest getSubTodoByIdDataRequest)
        {
            _getSubTodoByIdDataRequest = getSubTodoByIdDataRequest;
        }

        public async Task<GetSubTodoDataModel> GetSubTodoById(int subTodoId)
        {
            return await _getSubTodoByIdDataRequest.GetSubTodoById(subTodoId);
        }
    }

    
}
