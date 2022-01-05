using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Model.TodoModels.RequestModels;
using ToDoProjectWebAPI.Service.TodoServices;

namespace ToDoProjectWebAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly IGetTodoByIdServiceRequest _getTodoByIdServiceRequest;
        private readonly IGetAllTodosServiceRequest _getAllTodosServiceRequest;
        private readonly IInsertTodoServiceRequest _insertTodoServiceRequest;
        private readonly IUpdateTodoByIdServiceRequest _updateTodoByIdServiceRequest;
        private readonly IRemoveTodoByIdServiceRequest _removeTodoByIdServiceRequest;

        public TodoController(IGetTodoByIdServiceRequest getTodoByIdServiceRequest,
            IGetAllTodosServiceRequest getAllTodosServiceRequest, 
            IInsertTodoServiceRequest InsertTodoServiceRequest, 
            IUpdateTodoByIdServiceRequest updateTodoByIdServiceRequest, 
            IRemoveTodoByIdServiceRequest removeTodoByIdServiceRequest)
        {
            _getTodoByIdServiceRequest = getTodoByIdServiceRequest;     // getTodoByIdServiceRequest IGetTodoByIdServiceRequest'ten geliyor.
            _getAllTodosServiceRequest = getAllTodosServiceRequest;     // getAllTodosServiceRequest IGetAllTodosServiceRequest'ten geliyor.
            _insertTodoServiceRequest = InsertTodoServiceRequest;
            _updateTodoByIdServiceRequest = updateTodoByIdServiceRequest;
            _removeTodoByIdServiceRequest = removeTodoByIdServiceRequest;
        }

        [HttpGet("{todoId}")]
        public async Task<GetTodoDataModel> GetTodoById(int todoId)
        {
            return await _getTodoByIdServiceRequest.GetTodoById(todoId);
        }

        [HttpGet("all")]
        public async Task<List<GetTodoDataModel>> GetAllTodos()
        {
            return await _getAllTodosServiceRequest.GetAllTodos();
        }

        [HttpPost("add")]
        public async Task<bool> InsertTodo(InsertTodoDataModel model)
        {
            return await _insertTodoServiceRequest.InsertTodo(model);
        }

        [HttpPut("update")]
        public async Task<bool> UpdateTodoById(int todoId, InsertTodoDataModel model)
        {
            return await _updateTodoByIdServiceRequest.UpdateTodoById(todoId, model);
        }

        [HttpDelete("delete")]
        public async Task<bool> RemoveById(int id)
        {
            return await _removeTodoByIdServiceRequest.RemoveById(id);
        }
    }
}
