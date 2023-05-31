using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;
using proyectoef.Services;

namespace proyectoef.Controllers;

[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    ICategoriaService categoriaService;

    public CategoriaController(ICategoriaService service)
    {
        categoriaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoriaService.Get());
    }


   /*  [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        categoriaService.Save(categoria);
        return Ok();
    } */
    [HttpPost]
    public async Task<IResult> Post([FromServices] TareasContext dbContext, [FromBody] Categoria categoria)
    {
        categoria.CategoriaId = Guid.NewGuid();
        await dbContext.AddAsync(categoria);
        await dbContext.SaveChangesAsync();

        return Results.Created("Se ha creado con exito!", categoria);
    }


    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {
        categoriaService.Update(id, categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoriaService.Delete(id);
        return Ok();
    }

}