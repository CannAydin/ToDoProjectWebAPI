using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Model.SubTodoModels.RequestModels;
using ToDoProjectWebAPI.Service.SubTodoServices;

namespace ToDoProjectWebAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTodoController : Controller
    {
        private readonly IGetAllSubTodosServiceRequest _getAllSubTodosServiceRequest;
        private readonly IGetSubTodoByIdServiceRequest _getSubTodoByIdServiceRequest;
        private readonly IInsertSubTodoServiceRequest _insertSubTodoServiceRequest;
        private readonly ISwitchSubTodoDoneByIdServiceRequest _switchSubTodoDoneByIdServiceRequest;
        private readonly ISwitchSubTodoUndoneByIdServiceRequest _switchSubTodoUndoneByIdServiceRequest;
        private readonly IRemoveSubTodoByIdServiceRequest _removeSubTodoByIdServiceRequest;

        public SubTodoController(IGetAllSubTodosServiceRequest getAllSubTodosServiceRequest, IGetSubTodoByIdServiceRequest getSubTodoByIdServiceRequest, IInsertSubTodoServiceRequest insertSubTodoServiceRequest, ISwitchSubTodoDoneByIdServiceRequest switchSubTodoDoneByIdServiceRequest, ISwitchSubTodoUndoneByIdServiceRequest switchSubTodoUndoneByIdServiceRequest, IRemoveSubTodoByIdServiceRequest removeSubTodoByIdServiceRequest)
        {
            _getAllSubTodosServiceRequest = getAllSubTodosServiceRequest;
            _getSubTodoByIdServiceRequest = getSubTodoByIdServiceRequest;
            _insertSubTodoServiceRequest = insertSubTodoServiceRequest;
            _switchSubTodoDoneByIdServiceRequest = switchSubTodoDoneByIdServiceRequest;
            _switchSubTodoUndoneByIdServiceRequest = switchSubTodoUndoneByIdServiceRequest;
            _removeSubTodoByIdServiceRequest = removeSubTodoByIdServiceRequest;
        }

        [HttpGet("all")]
        public async Task<List<GetSubTodoDataModel>> GetAllSubTodos()
        {
            return await _getAllSubTodosServiceRequest.GetAllSubTodos();
        }

        [HttpGet("{subTodoId}")]
        public async Task<GetSubTodoDataModel> GetsubTodoById(int subTodoId)
        {
            return await _getSubTodoByIdServiceRequest.GetSubTodoById(subTodoId);
        }
        [HttpPost("add")]
        public async Task<bool> InsertSubTodo(int todoId, int userId, InsertSubTodoDataModel model)
        {
            return await _insertSubTodoServiceRequest.InsertSubTodo(todoId, userId, model);
        }

        [HttpPut("setisdone")]
        public async Task<bool> SwitchSubTodoDone(int subTodoId)
        {
            return await _switchSubTodoDoneByIdServiceRequest.SwitchSubTodoDone(subTodoId);
        }
        [HttpPut("setundone")]
        public async Task<bool> SwitchSubTodo(int subTodoId)
        {
            return await _switchSubTodoUndoneByIdServiceRequest.SwitchSubTodoUndone(subTodoId);
        }
        [HttpDelete("delete")]
        public async Task<bool> RemoveSubTodo(int subTodoId)
        {
            return await _removeSubTodoByIdServiceRequest.RemoveSubTodo(subTodoId);
        }
    }
    
}
