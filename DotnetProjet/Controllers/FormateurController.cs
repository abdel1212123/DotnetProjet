// Controllers/FormateurController.cs
using Microsoft.AspNetCore.Mvc;
using DotnetProjet.Entities;
using DotnetProjet.Services;

namespace DotnetProjet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FormateurController : ControllerBase
{
    private readonly IServices _service;
    public FormateurController(IServices service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAllFormateurs());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var formateur = _service.GetFormateurById(id);
        if (formateur == null) return NotFound(new { message = "Formateur introuvable." });
        return Ok(formateur);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Formateur formateur)
    {
        _service.AddFormateur(formateur);
        return Ok(new { message = "Formateur ajouté.", formateur });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Formateur formateur)
    {
        _service.UpdateFormateur(id, formateur);
        return Ok(new { message = "Formateur modifié." });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteFormateur(id);
        return Ok(new { message = "Formateur supprimé." });
    }
}