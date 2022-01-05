using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.UserData;
using ToDoPojectWebAPI.Model.UserModels.RequestModels;

namespace ToDoProjectWebAPI.Service.UserServices
{
    public interface IUpdateUserByIdServiceRequest
    {
        Task<bool> UpdateUser(int userId, GetUserDataModel model);
    }
    public class UpdateUserByIdServiceRequest:IUpdateUserByIdServiceRequest
    {
        private readonly IUpdateUserByIdDataRequest _updateUserByIdDataRequest;

        public UpdateUserByIdServiceRequest(IUpdateUserByIdDataRequest updateUserByIdDataRequest)
        {
            _updateUserByIdDataRequest = updateUserByIdDataRequest;
        }

        public async Task<bool> UpdateUser(int userId, GetUserDataModel model)
        {
            return await _updateUserByIdDataRequest.UpdateUser(userId, model);
        }
    }
}
