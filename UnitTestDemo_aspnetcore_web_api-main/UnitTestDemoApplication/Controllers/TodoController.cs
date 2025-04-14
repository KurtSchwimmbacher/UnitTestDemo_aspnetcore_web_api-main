using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitTestDemoApplication.Interfaces;
using UnitTestDemoApplication.Models;

namespace UnitTestDemoApplication.Controllers
{
    /// <summary>
    /// Controller for managing todo items. Can get a specifc item, and add a new item.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _service;

        public TodoController(ITodoRepository repository)
        {
            _service = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddTodoAsync(string title)
        {
            var newItem = new TodoItem { Title = title, IsCompleted = false };
            await _service.AddAsync(newItem);

            return Ok(newItem);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoByIdAsync(int id)
        {
            TodoItem? todo = await _service.GetByIdAsync(id);
            if (todo == null) return NotFound();

            return Ok(todo);
        }
    }
}
