using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_api.Models;
using dotnet_api.src.Data;
using dotnet_api.src.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace dotnet_api.src.Services
{

    public class ToDoServices : IToDoServices
    {
        private readonly Context _context;

        public ToDoServices(Context context)
        {
            _context = context;
        }

        public async Task<ToDo> delete(int id)
        {
            var getpost = await _context.ToDo.FirstOrDefaultAsync(item => item.Id == id);
            if (getpost == null) return null;


            getpost.IsDelete = true;

            _context.ToDo.Update(getpost);
            _context.SaveChanges();
            return (getpost);
        }


        public async Task<ToDo> GetById(int id)
        {
            var SearchPost = await _context.ToDo.FirstOrDefaultAsync(e => e.Id.Equals(id));
            if (SearchPost == null)
            {
                return null;
            }
            return SearchPost;
        }

        public List<ToDo> list()
        {
            var ToDoContext = _context.ToDo.Where(e => !e.IsDelete).ToList();

            return ToDoContext;
        }

        public async Task<ToDo> post(ToDoRequest dto)
        {
            DateTime now = DateTime.Today;

            var response = new ToDo
            {
                Description = dto.Description,
                Title = dto.Title,
                DatePost = now,
                IsDelete = false
            };

            _context.ToDo.Add(response);
            _context.SaveChanges();

            return response;
        }

        public async Task<ToDo> update(ToDoRequest dto, int id)
        {
            var getpost = await _context.ToDo.FirstOrDefaultAsync(e => e.Id == id);
            if (getpost == null) return null;

            getpost.Title = dto.Title;
            getpost.Description = dto.Description;
            getpost.DatePost = DateTime.Today;


            _context.ToDo.Update(getpost);
            _context.SaveChanges();
            return (getpost);
        }

    }
}