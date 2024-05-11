using Microsoft.AspNetCore.Mvc;
using p.lib;
[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    ItemsService _service;

    public ItemsController(ItemsService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<ToDoItems> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("getItem/{id}")]
    public ActionResult<ToDoItems> GetById(string id)
    {
        var item = _service.GetItemById(id);

        if (item is not null)
        {
            return item;
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost("AddItem")]
    public IActionResult Add(ToDoItems newItem)
    {
        var item = _service.AddItem(newItem);
        return CreatedAtAction(nameof(GetById), new { id = item!.ToDoItemsId }, item);
    }

    [HttpDelete("deleteitem/{idi}")]
    public IActionResult Delete(string idi)
    {
        var item = _service.GetItemById(idi);

        if (item is not null)
        {
            _service.DeleteItemById(idi);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}