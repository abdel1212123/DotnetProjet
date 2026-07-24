// Controllers/FormationController.cs
using Microsoft.AspNetCore.Mvc;
using DotnetProjet.Entities;
using DotnetProjet.Services;

namespace DotnetProjet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FormationController : ControllerBase
{
    private readonly IServices _service;
    public FormationController(IServices service) => _service = service;

    [HttpPost("inscrire")]
    public IActionResult Inscrire([FromBody] InscriptionRequest request)
    {
        try
        {
            _service.Inscrire(request.UserId, request.SessionId);
            return Ok(new { message = "Inscription réussie." });
        }
        catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetByUser(int userId) => Ok(_service.GetSessionsByUser(userId));

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAllFormations());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var formation = _service.GetFormationById(id);
        if (formation == null) return NotFound(new { message = "Formation introuvable." });
        return Ok(formation);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Formation formation)
    {
        _service.AddFormation(formation);
        return Ok(new { message = "Formation ajoutée.", formation });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Formation formation)
    {
        _service.UpdateFormation(id, formation);
        return Ok(new { message = "Formation modifiée." });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteFormation(id);
        return Ok(new { message = "Formation supprimée." });
    }

    [HttpGet("test")]
    public IActionResult Test() => Ok(new { message = "test ok" });
}

public class InscriptionRequest
{
    public int UserId { get; set; }
    public int SessionId { get; set; }
}