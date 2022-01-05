using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.SubTodoData;
using ToDoPojectWebAPI.Data.TodoData;

namespace ToDoProjectWebAPI.Service.SubTodoServices
{
    public interface ISwitchSubTodoUndoneByIdServiceRequest
    {
        Task<bool> SwitchSubTodoUndone(int subTodoId);
    }
    public class SwitchSubTodoUndoneByIdServiceRequest: ISwitchSubTodoUndoneByIdServiceRequest
    {
        private readonly ISwitchSubTodoUndoneByIdDataRequest _switchSubTodoUndoneByIdDataRequest;
        private readonly IGetIdIsDoneProgressOfTodoDataRequest _getIdIsDoneProgressOfTodoDataRequest;
        private readonly ISwitchTodoByIdDataRequest _switchTodoByIdDataRequest;
        private readonly IChangeTodoProgressByIdDataRequest _changeTodoProgressByIdDataRequest;
        private readonly IGetRatioOfSubTodoByIdDataRequest _getRatioOfSubTodoByIdDataRequest;

        public SwitchSubTodoUndoneByIdServiceRequest(ISwitchSubTodoUndoneByIdDataRequest switchSubTodoUndoneByIdDataRequest, IGetIdIsDoneProgressOfTodoDataRequest getIdIsDoneProgressOfTodoDataRequest, ISwitchTodoByIdDataRequest switchTodoByIdDataRequest, IChangeTodoProgressByIdDataRequest changeTodoProgressByIdDataRequest, IGetRatioOfSubTodoByIdDataRequest getRatioOfSubTodoByIdDataRequest)
        {
            _switchSubTodoUndoneByIdDataRequest = switchSubTodoUndoneByIdDataRequest;
            _getIdIsDoneProgressOfTodoDataRequest = getIdIsDoneProgressOfTodoDataRequest;
            _switchTodoByIdDataRequest = switchTodoByIdDataRequest;
            _changeTodoProgressByIdDataRequest = changeTodoProgressByIdDataRequest;
            _getRatioOfSubTodoByIdDataRequest = getRatioOfSubTodoByIdDataRequest;
        }

        public async Task<bool> SwitchSubTodoUndone(int subTodoId)
        {
            var setSubTodoUndone = await _switchSubTodoUndoneByIdDataRequest.SwitchSubTodoUndone(subTodoId);
            var IdIsdoneProgressOfTodo = await _getIdIsDoneProgressOfTodoDataRequest.GetIdIsDoneProgressOfTodo(subTodoId);
            var ratioSubTodo = await _getRatioOfSubTodoByIdDataRequest.GetRatioOfSubTodo(subTodoId);

            if (setSubTodoUndone)
            {
                if(IdIsdoneProgressOfTodo.IsDone)
                {
                    var switchTodo = await _switchTodoByIdDataRequest.SwitchTodo(IdIsdoneProgressOfTodo.Id, 0);
                    var changeTodoProgress = await _changeTodoProgressByIdDataRequest.ChangeProgressTodo(IdIsdoneProgressOfTodo.Id, -ratioSubTodo);
                    return (switchTodo && changeTodoProgress);
                }
                else
                {
                    return await _changeTodoProgressByIdDataRequest.ChangeProgressTodo(IdIsdoneProgressOfTodo.Id, -ratioSubTodo);
                }                
                
            }
            else return false;
        }
    }
}
