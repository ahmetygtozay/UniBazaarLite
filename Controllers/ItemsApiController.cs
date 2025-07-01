using Microsoft.AspNetCore.Mvc;
using UniBazaarLite.Data;

[Route("api/items")]
[ApiController]
public class ItemsApiController : ControllerBase
{
    private readonly IRepository _repository;

    public ItemsApiController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetItems()
    {
        var items = _repository.GetListings();
        return Ok(items);
    }
}
