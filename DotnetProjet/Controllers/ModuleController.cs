// Controllers/ModuleController.cs
using Microsoft.AspNetCore.Mvc;
using DotnetProjet.Entities;
using DotnetProjet.Services;

namespace DotnetProjet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModuleController : ControllerBase
{
    private readonly IServices _service;
    public ModuleController(IServices service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAllModules());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var module = _service.GetModuleById(id);
        if (module == null) return NotFound(new { message = "Module introuvable." });
        return Ok(module);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Module module)
    {
        _service.AddModule(module);
        return Ok(new { message = "Module ajouté.", module });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Module module)
    {
        _service.UpdateModule(id, module);
        return Ok(new { message = "Module modifié." });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteModule(id);
        return Ok(new { message = "Module supprimé." });
    }
}