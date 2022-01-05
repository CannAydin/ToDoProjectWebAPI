using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.UserData;

namespace ToDoProjectWebAPI.Service.UserServices
{
    public interface IRemoveUserByIdServiceRequest
    {
        Task<bool> RemoveUser(int userId);
    }
    public class RemoveUserByIdServiceRequest:IRemoveUserByIdServiceRequest
    {
        private readonly IRemoveUserByIdDataRequest _removeUserByIdDataRequest;
        public RemoveUserByIdServiceRequest(IRemoveUserByIdDataRequest removeUserByIdDataRequest)
        {
            _removeUserByIdDataRequest = removeUserByIdDataRequest;
        }
        public async Task<bool> RemoveUser(int userId)
        {
            return await _removeUserByIdDataRequest.RemoveUser(userId);
        }
    }
}
