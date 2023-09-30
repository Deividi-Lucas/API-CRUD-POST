using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_api.Models;
using dotnet_api.src.Data;
using dotnet_api.src.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace dotnet_api.src.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoServices _services;

        public ToDoController(IToDoServices services)
        {
            _services = services;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var ResultServices = _services.list();

            return Ok(ResultServices);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var result = _services.GetById(id);

            return Ok(result.Result);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ToDoRequest req)
        {
            var ResultServices = _services.post(req);

            return Ok(ResultServices.Result);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] ToDoRequest dto, int id)
        {
            var result = _services.update(dto, id);

            if (result.Result == null) return BadRequest("Not exist Post!");

            return Ok(result.Result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _services.delete(id);

            if (result.Result == null) return BadRequest("Not Exist Post");

            return Ok(result.Result);
        }
    }
}