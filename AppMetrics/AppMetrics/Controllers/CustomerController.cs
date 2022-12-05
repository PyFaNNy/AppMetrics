using App.Metrics;
using AppMetrics.Domain;
using AppMetrics.Interfaces;
using AppMetrics.MetricsR;
using Microsoft.AspNetCore.Mvc;

namespace AppMetrics.Controllers;

[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMetrics _metrics;
    private readonly IAppDbContext _dbContext;

    public CustomerController(IAppDbContext dbContext, IMetrics metrics)
    {
        _dbContext = dbContext;
        _metrics = metrics;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("customers")]
    public IActionResult Get()
    {
        _metrics.Measure.Counter.Increment(BusinessMetrics.CustomersGetAllCounter);
        var result = _dbContext.Customers.ToList();
        return Ok(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("customer")]
    public IActionResult Get(Guid id)
    {
        var result = _dbContext.Customers.FirstOrDefault(x => x.Id == id);
        return Ok(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPost("customer")]
    public async Task<IActionResult> Post(Customer value)
    {
        var obj = await _dbContext.Customers.AddAsync(value);
        _dbContext.SaveChanges();
        return Ok(obj.Entity);
    }

    [HttpPut("customer")]
    public void Put(Customer customer)
    {
        _dbContext.Customers.Update(customer);
        _dbContext.SaveChanges();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("customer")]
    public void Delete(Guid id)
    {
        var filteredData = _dbContext.Customers.FirstOrDefault(x => x.Id == id);
        _dbContext.Customers.Remove(filteredData);
        _dbContext.SaveChanges();
    }
}