using Microsoft.AspNetCore.Mvc;
using Wadjet.DTO;
using Wadjet.Entities;
using Wadjet.Services;

namespace Wadjet.Controllers;

[ApiController]
[Route("/establishment")]
public class EstablishmentController : ControllerBase
{
    private readonly EstablishmentService _service;

    public EstablishmentController(EstablishmentService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(EstablishmentForm form)
    {
        Establishment establishment;
        try
        {
            establishment = await _service.CreateAsync(form);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(establishment);
    }

    [HttpGet]
    public async Task<IActionResult> GetActiveAsync()
    {
        IList<Establishment> establishments;
        try
        {
            establishments = await _service.GetActiveAsync();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

        return Ok(establishments);
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        IList<Establishment> establishments;
        try
        {
            establishments = await _service.GetAllAsync();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

        return Ok(establishments);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneAsync(long id)
    {
        Establishment establishment;
        try
        {
            establishment = await _service.GetOneAsync(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(establishment);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> RemoveAsync(long id)
    {
        try
        {
            await _service.RemoveAsync(id);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateAsync(long id, EstablishmentForm form)
    {
        Establishment establishment;
        try
        {
            establishment = await _service.UpdateAsync(id, form);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

        return Ok(establishment);
    }
}
