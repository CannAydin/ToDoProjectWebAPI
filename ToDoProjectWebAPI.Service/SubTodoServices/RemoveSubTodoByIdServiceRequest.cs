using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.SubTodoData;
using ToDoPojectWebAPI.Data.TodoData;

namespace ToDoProjectWebAPI.Service.SubTodoServices
{
    public interface IRemoveSubTodoByIdServiceRequest
    {
        Task<bool> RemoveSubTodo(int subTodoId);
    }
    public class RemoveSubTodoByIdServiceRequest:IRemoveSubTodoByIdServiceRequest
    {
        private readonly IRemoveSubTodoByIdDataRequest _removeSubTodoByIdDataRequest;
        private readonly IGetSubTodoByIdDataRequest _getSubTodoByIdDataRequest;
        private readonly IGetIdIsDoneProgressOfTodoDataRequest _getIdIsDoneProgressOfTodoDataRequest;
        private readonly IChangeTodoProgressByIdDataRequest _changeTodoProgressByIdDataRequest;
        private readonly ISwitchTodoByIdDataRequest _switchTodoByIdDataRequest;

        public RemoveSubTodoByIdServiceRequest(IRemoveSubTodoByIdDataRequest removeSubTodoByIdDataRequest, IGetSubTodoByIdDataRequest getSubTodoByIdDataRequest, IChangeTodoProgressByIdDataRequest changeTodoProgressByIdDataRequest, ISwitchTodoByIdDataRequest switchTodoByIdDataRequest)
        {
            _removeSubTodoByIdDataRequest = removeSubTodoByIdDataRequest;
            _getSubTodoByIdDataRequest = getSubTodoByIdDataRequest;
            _changeTodoProgressByIdDataRequest = changeTodoProgressByIdDataRequest;
            _switchTodoByIdDataRequest = switchTodoByIdDataRequest;
        }
        public async Task<bool> RemoveSubTodo(int subTodoId)
        {
            var getSubTodo = await _getSubTodoByIdDataRequest.GetSubTodoById(subTodoId);
            if (getSubTodo.IsDone)
            {
                var getTodo = await _getIdIsDoneProgressOfTodoDataRequest.GetIdIsDoneProgressOfTodo(subTodoId);
                if (getTodo.IsDone)
                {
                    var switchTodo = await _switchTodoByIdDataRequest.SwitchTodo(getTodo.Id, 0);
                    var changeTodoProgress = await _changeTodoProgressByIdDataRequest.ChangeProgressTodo(getTodo.Id, -getSubTodo.Ratio);
                    var removeSubTodo = await _removeSubTodoByIdDataRequest.RemoveSubTodo(subTodoId);
                    return (changeTodoProgress && removeSubTodo && switchTodo);
                }
                else
                {
                    var changeTodoProgress = await _changeTodoProgressByIdDataRequest.ChangeProgressTodo(getTodo.Id, -getSubTodo.Ratio);
                    var removeSubTodo = await _removeSubTodoByIdDataRequest.RemoveSubTodo(subTodoId);
                    return (changeTodoProgress && removeSubTodo);
                }
            }
            else
            {
                return await _removeSubTodoByIdDataRequest.RemoveSubTodo(subTodoId);
            }

        }
    }
}
