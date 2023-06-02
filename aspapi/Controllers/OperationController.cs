using Microsoft.AspNetCore.Mvc;

namespace aspapi.Controllers;

[ApiController]
[Route("[controller]")]
public class OperationController : ControllerBase
{
    private readonly ILogger<OperationController> _logger;
    private readonly IRepository<Operation> _repository;

    public OperationController(ILogger<OperationController> logger,IRepository<Operation> repository)
    {
        _logger = logger;
        _repository=repository;
    }

[HttpGet]
    public async Task<IEnumerable<Operation>> Get()
    {
        return await _repository.GetAllAsync();
    }

    [HttpPost]
    public async Task<Operation> Post([FromBody]Operation entity){
        entity.Id=Guid.NewGuid();
 await _repository.AddAsync(entity);

 return entity;
    }
}
