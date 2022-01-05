using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.TodoData;

namespace ToDoProjectWebAPI.Service.TodoServices
{
    public interface IRemoveTodoByIdServiceRequest
    {
        Task<bool> RemoveById(int id);
    }
    public class RemoveTodoByIdServiceRequest:IRemoveTodoByIdServiceRequest
    {
        private readonly IRemoveTodoByIdDataRequest _removeTodoByIdDataRequest;

        public RemoveTodoByIdServiceRequest(IRemoveTodoByIdDataRequest removeTodoByIdDataRequest)
        {
            _removeTodoByIdDataRequest = removeTodoByIdDataRequest;
        }

        public async Task<bool> RemoveById(int id)
        {
            return await _removeTodoByIdDataRequest.RemoveById(id);
        }
    }
}
