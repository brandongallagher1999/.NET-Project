using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project2.Entities;
using Project2.Services;

namespace Project2.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ApiController : Controller
    {

        private DatabaseService db;

        public ApiController()
        {
            db = new DatabaseService();
        }
        public IActionResult Index()
        {
            return View();
        }


        //POST: /api/items/create
        [Route("items/create")]
        [HttpPost]
        public IActionResult Create([FromBody] ToDoItem item)
        {
            var res = db.CreateItem(item);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }


        //GET: /api/items/all
        [Route("items/all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var res = db.GetAllItems();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }


        //PUT: /api/items/update
        [Route("items/update")]
        [HttpPut]
        public IActionResult Update([FromBody] ToDoItem item)
        {
            var res = db.UpdateItem(item);
            if (res == null)
            {
                return NotFound();
            }
            return Ok("Updated: " + item._id);
        }


        //DELETE /api/items/delete/{id}
        [Route("items/delete/{id}")]
        [HttpDelete]
        public IActionResult Delete([FromBody] ToDoItem item)
        {
            var res = db.DeleteItem(item);
            if (res == null)
            {
                return NotFound();
            }
            return Ok("Deleted: " + item._id);
        }

        
    }
}
