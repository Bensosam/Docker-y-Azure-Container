using GestionClientes.API.Data;
using GestionClientes.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionClientes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
    {
        return Ok(await _context.Clientes
            .AsNoTracking()
            .OrderBy(c => c.Id_cliente)
            .ToListAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Cliente>> GetCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente is null)
            return NotFound(new { mensaje = "Cliente no encontrado." });

        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetCliente),
            new { id = cliente.Id_cliente },
            cliente);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutCliente(int id, Cliente cliente)
    {
        if (id != cliente.Id_cliente)
            return BadRequest(new { mensaje = "El ID de la URL no coincide con el ID del cliente." });

        var existe = await _context.Clientes.AnyAsync(c => c.Id_cliente == id);

        if (!existe)
            return NotFound(new { mensaje = "Cliente no encontrado." });

        _context.Entry(cliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente is null)
            return NotFound(new { mensaje = "Cliente no encontrado." });

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
