using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.UserData;
using ToDoPojectWebAPI.Model.UserModels.RequestModels;

namespace ToDoProjectWebAPI.Service.UserServices
{
    public interface IGetUserByIdServiceRequest
    {
        Task<GetUserDataModel> GetUserById(int UserId);
    }
    public class GetUserByIdServiceRequest:IGetUserByIdServiceRequest
    {
        private readonly IGetUserByIdDataRequest _getUserByIdDataRequest;

        public GetUserByIdServiceRequest(IGetUserByIdDataRequest getUserByIdDataRequest)
        {
            _getUserByIdDataRequest = getUserByIdDataRequest;
        }

        public async Task<GetUserDataModel> GetUserById(int UserId)
        {
            return await _getUserByIdDataRequest.GetUserById(UserId);
        }
    }
}
