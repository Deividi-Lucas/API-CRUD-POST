using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_api.Models;

namespace dotnet_api.src.Services.Interface
{
    public interface IToDoServices
    {
        List<ToDo> list();

        Task<ToDo> post(ToDoRequest dto);

        Task<ToDo> GetById(int id);

        Task<ToDo> update(ToDoRequest dto, int id);

        Task<ToDo> delete(int id);
    }
}