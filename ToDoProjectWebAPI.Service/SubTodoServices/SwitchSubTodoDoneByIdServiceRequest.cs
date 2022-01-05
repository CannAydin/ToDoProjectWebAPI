using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.SubTodoData;
using ToDoPojectWebAPI.Data.TodoData;

namespace ToDoProjectWebAPI.Service.SubTodoServices
{
    public interface ISwitchSubTodoDoneByIdServiceRequest
    {
        Task<bool> SwitchSubTodoDone(int subTodoId);
    }
    public class SwitchSubTodoDoneByIdServiceRequest: ISwitchSubTodoDoneByIdServiceRequest
    {
        private readonly ISwitchSubTodoDoneByIdDataRequest _switchSubTodoDoneByIdDataRequest;
        private readonly IGetIdIsDoneProgressOfTodoDataRequest _getIdIsDoneProgressOfTodoDataRequest;
        private readonly IGetRatioOfSubTodoByIdDataRequest _getRatioOfSubTodoByIdDataRequest;
        private readonly ISwitchTodoByIdDataRequest _switchTodoByIdDataRequest;
        private readonly IChangeTodoProgressByIdDataRequest _changeTodoProgressByIdDataRequest;

        public SwitchSubTodoDoneByIdServiceRequest(ISwitchSubTodoDoneByIdDataRequest switchSubTodoDoneByIdDataRequest, IGetIdIsDoneProgressOfTodoDataRequest getIdIsDoneProgressOfTodoDataRequest, IGetRatioOfSubTodoByIdDataRequest getRatioOfSubTodoByIdDataRequest, ISwitchTodoByIdDataRequest switchTodoByIdDataRequest, IChangeTodoProgressByIdDataRequest changeTodoProgressByIdDataRequest)
        {
            _switchSubTodoDoneByIdDataRequest = switchSubTodoDoneByIdDataRequest;
            _getIdIsDoneProgressOfTodoDataRequest = getIdIsDoneProgressOfTodoDataRequest;
            _getRatioOfSubTodoByIdDataRequest = getRatioOfSubTodoByIdDataRequest;
            _switchTodoByIdDataRequest = switchTodoByIdDataRequest;
            _changeTodoProgressByIdDataRequest = changeTodoProgressByIdDataRequest;
        }
        public async Task<bool> SwitchSubTodoDone(int subTodoId)
        {
            var setSubTodoDone = await _switchSubTodoDoneByIdDataRequest.SwitchSubTodoDone(subTodoId);
            var IdIsdoneProgressofTodo = await _getIdIsDoneProgressOfTodoDataRequest.GetIdIsDoneProgressOfTodo(subTodoId);
            var ratioOfSubTodo = await _getRatioOfSubTodoByIdDataRequest.GetRatioOfSubTodo(subTodoId);

            if (setSubTodoDone)
            {
                if (IdIsdoneProgressofTodo.Progress >= 100 && !IdIsdoneProgressofTodo.IsDone )
                {
                    var switchTodoDone = await _switchTodoByIdDataRequest.SwitchTodo(IdIsdoneProgressofTodo.Id, 1);
                    var addRatioToProgress = await _changeTodoProgressByIdDataRequest.ChangeProgressTodo(IdIsdoneProgressofTodo.Id, ratioOfSubTodo);
                    return (switchTodoDone && addRatioToProgress);
                }
                else
                {
                    return await _changeTodoProgressByIdDataRequest.ChangeProgressTodo(IdIsdoneProgressofTodo.Id, ratioOfSubTodo);
                }
            }
            else return false;

        }
    }
}
