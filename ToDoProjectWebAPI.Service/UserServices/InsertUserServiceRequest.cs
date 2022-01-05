using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.UserData;
using ToDoPojectWebAPI.Model.UserModels.RequestModels;

namespace ToDoProjectWebAPI.Service.UserServices
{
    public interface IInsertUserServiceRequest
    {
        Task<bool> InsertUser(InsertUserDataModel model);
    }
    public class InsertUserServiceRequest:IInsertUserServiceRequest
    {
        private readonly IInsertUserDataRequest _insertUserDataRequest;

        public InsertUserServiceRequest(IInsertUserDataRequest insertUserDataRequest)
        {
            _insertUserDataRequest = insertUserDataRequest;
        }

        public async Task<bool> InsertUser(InsertUserDataModel model)
        {
            return await _insertUserDataRequest.InsertUser(model);
        }

    }
}
