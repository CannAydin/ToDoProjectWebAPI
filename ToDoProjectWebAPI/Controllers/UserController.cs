using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Model.UserModels.RequestModels;
using ToDoProjectWebAPI.Service.UserServices;

namespace ToDoProjectWebAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IGetUserByIdServiceRequest getUserByIdServiceRequest;
        private readonly IInsertUserServiceRequest _insertUserServiceRequest;
        private readonly IUpdateUserByIdServiceRequest _updateUserByIdServiceRequest;
        private readonly IRemoveUserByIdServiceRequest _removeUserByIdServiceRequest;

        public UserController(IGetUserByIdServiceRequest getUserByIdServiceRequest, IInsertUserServiceRequest insertUserServiceRequest, IUpdateUserByIdServiceRequest updateUserByIdServiceRequest, IRemoveUserByIdServiceRequest removeUserByIdServiceRequest)
        {
            this.getUserByIdServiceRequest = getUserByIdServiceRequest;
            _insertUserServiceRequest = insertUserServiceRequest;
            _updateUserByIdServiceRequest = updateUserByIdServiceRequest;
            _removeUserByIdServiceRequest = removeUserByIdServiceRequest;
        }

        [HttpGet("{userId}")]
        public async Task<GetUserDataModel> GetUserById(int userId)
        {
            return await getUserByIdServiceRequest.GetUserById(userId);
        }
        [HttpPost("add-user")]
        public async Task<bool> InsertUser(InsertUserDataModel model)
        {
            return await _insertUserServiceRequest.InsertUser(model);
        }
        [HttpPut("update-user")]
        public async Task<bool> UpdateUser(int userId,GetUserDataModel model)
        {
            return await _updateUserByIdServiceRequest.UpdateUser(userId, model);
        }
        [HttpDelete("delete-user")]
        public async Task<bool> RemoveUser(int userId)
        {
            return await _removeUserByIdServiceRequest.RemoveUser(userId);
        }

    }
}
