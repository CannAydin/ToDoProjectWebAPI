using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.SubTodoData;
using ToDoPojectWebAPI.Data.TodoData;
using ToDoPojectWebAPI.Data.UserData;
using ToDoPojectWebAPI.Data.Utils;
using ToDoProjectWebAPI.Api.Controllers;
using ToDoProjectWebAPI.Service.SubTodoServices;
using ToDoProjectWebAPI.Service.TodoServices;
using ToDoProjectWebAPI.Service.UserServices;


namespace ToDoProjectWebAPI.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var todoConnectionString = "Server = localhost; Database = DbTodo; Integrated Security = True";
            services.AddSingleton<IProjectDbConnection>(s => new ProjectDbConnection(todoConnectionString));

            // Services for Todo
            services.AddSingleton<IGetTodoByIdServiceRequest, GetTodoByIdServiceRequest>();
            services.AddSingleton<IGetAllTodosServiceRequest, GetAllTodosServiceRequest>();
            services.AddSingleton<IInsertTodoServiceRequest, InsertTodoServiceRequest>();
            services.AddSingleton<IUpdateTodoByIdServiceRequest, UpdateTodoByIdServiceRequest>();
            services.AddSingleton<IRemoveTodoByIdServiceRequest, RemoveTodoByIdServiceRequest>();

            // Services for User
            services.AddSingleton<IGetUserByIdServiceRequest, GetUserByIdServiceRequest>();
            services.AddSingleton<IInsertUserServiceRequest, InsertUserServiceRequest>();
            services.AddSingleton<IUpdateUserByIdServiceRequest, UpdateUserByIdServiceRequest>();
            services.AddSingleton<IRemoveUserByIdServiceRequest, RemoveUserByIdServiceRequest>();

            // Services for SubTodo
            services.AddSingleton<IGetAllSubTodosServiceRequest, GetAllSubTodosServiceRequest>();
            services.AddSingleton<IGetSubTodoByIdServiceRequest, GetSubTodoByIdServiceRequest>();
            services.AddSingleton<IInsertSubTodoServiceRequest, InsertSubTodoServiceRequest>();
            services.AddSingleton<ISwitchSubTodoDoneByIdServiceRequest, SwitchSubTodoDoneByIdServiceRequest>();
            services.AddSingleton<ISwitchSubTodoUndoneByIdServiceRequest, SwitchSubTodoUndoneByIdServiceRequest>();
            services.AddSingleton<IRemoveSubTodoByIdServiceRequest, RemoveSubTodoByIdServiceRequest>();

            // Data for Todo
            services.AddSingleton<IGetTodoByIdDataRequest, GetTodoByIdDataRequest>();  // Add Singleton Add Scoped, Add Transiant araþtýrýlacak. Solid prensipleri de araþtýrýlacak.
            services.AddSingleton<IGetAllTodosDataRequest, GetAllTodosDataRequest>();  // Bunu yazmazmasaydýk bu deðiþken türünden field oluþturamazdýk. (Dependency Injection)
            services.AddSingleton<IInsertTodoDataRequest, InsertTodoDataRequest>();
            services.AddSingleton<IUpdateTodoByIdDataRequest, UpdateTodoByIdDataRequest>();
            services.AddSingleton<IRemoveTodoByIdDataRequest, RemoveTodoByIdDataRequest>();
            services.AddSingleton<IChangeTodoProgressByIdDataRequest, ChangeTodoProgressByIdDataRequest>();
            services.AddSingleton<IGetIdIsDoneProgressOfTodoDataRequest, GetIdIsDoneProgressOfTodoDataRequest>();
            services.AddSingleton<ISwitchTodoByIdDataRequest, SwitchTodoByIdDataRequest>();

            // Data for User
            services.AddSingleton<IGetUserByIdDataRequest, GetUserByIdDataRequest>();
            services.AddSingleton<IInsertUserDataRequest, InsertUserDataRequest>();
            services.AddSingleton<IUpdateUserByIdDataRequest, UpdateUserByIdDataRequest>();
            services.AddSingleton<IRemoveUserByIdDataRequest, RemoveUserByIdDataRequest>();

            // Data for SubTodos
            services.AddSingleton<IGetAllSubTodosDataRequest, GetAllSubTodosDataRequest>();
            services.AddSingleton<IGetSubTodoByIdDataRequest, GetSubTodoByIdDataRequest>();
            services.AddSingleton<IInsertSubTodoDataRequest, InsertSubTodoDataRequest>();
            services.AddSingleton<IGetRatioOfSubTodoByIdDataRequest, GetRatioOfSubTodoByIdDataRequest>();
            services.AddSingleton<ISwitchSubTodoDoneByIdDataRequest, SwitchSubTodoDoneByIdDataRequest>();
            services.AddSingleton<ISwitchSubTodoUndoneByIdDataRequest, SwitchSubTodoUndoneByIdDataRequest>();
            services.AddSingleton<IRemoveSubTodoByIdDataRequest, RemoveSubTodoByIdDataRequest>();

            // Controllers
            services.AddSingleton<TodoController>();
            services.AddSingleton<UserController>();
            services.AddSingleton<SubTodoController>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoProjectWebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoProjectWebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
