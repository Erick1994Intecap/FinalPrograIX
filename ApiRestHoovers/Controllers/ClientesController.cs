using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRestHoovers.Models;
using ApiRestHoovers.Services;
using System.Text.Json;

namespace ApiRestHoovers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly HOOVERSContext _context;

        public ClientesController(HOOVERSContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("cliente")]
        public ActionResult<List<ClienteResult>> Get()
        {
            var clienteService = new ClienteService();
            List<ClienteResult> clientes = clienteService.GetClientes();
            try
            {
                
                _context.Bitacoras.Add(new Bitacora
                {
                    IdMetodo = 1,
                    IdModulo = 1,
                    Descripcion = "LISTADO DE TODOS LOS CLIENTES, NO SE ENVIA JSON"
                });
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

            return Ok(clientes);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

           

            _context.Entry(new Cliente {
                Id = id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Telefono = cliente.Telefono,
                Estado = cliente.Estado,
                FechaCreacion = DateTime.Now.AddDays(-1),
                FechaActualizacion = DateTime.Now

            }).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
                try
                {
                    string jsonString = JsonSerializer.Serialize(cliente);
                    _context.Bitacoras.Add(new Bitacora { 
                        IdMetodo = 3,
                        IdModulo = 1, 
                        Descripcion = jsonString
                    });
                    await _context.SaveChangesAsync();
                }
                catch {
                    throw;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<String> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(new Cliente
            {
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Telefono = cliente.Telefono
            });

            await _context.SaveChangesAsync();
            try
            {
                string jsonString = JsonSerializer.Serialize(cliente);
                _context.Bitacoras.Add(new Bitacora
                {
                    IdMetodo = 2,
                    IdModulo = 1,
                    Descripcion = jsonString
                });
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return "Cliente creado exitosamente";
        }

        [HttpPost("Masivo")]
        public ActionResult<IEnumerable<Cliente>> AddUsuario(List<Cliente> Usuario)
        {
            List<Cliente> guardados = new List<Cliente>();
            if (Usuario != null)
            {
                foreach (var item in Usuario)
                {
                    if (item != null)
                    {
                        _context.Clientes.Add(new Cliente
                        {
                            Nombre = item.Nombre,
                            Apellido = item.Apellido,
                            Telefono = item.Telefono
                        });

                        guardados.Add(item);
                        //_context.SaveChanges();


                    }
                }
                if (guardados.Count > 0)
                {
                    _context.SaveChanges();
                    return Ok(guardados);
                    try
                    {
                        string jsonString = JsonSerializer.Serialize(Usuario);
                        _context.Bitacoras.Add(new Bitacora
                        {
                            IdMetodo = 3,
                            IdModulo = 1,
                            Descripcion = jsonString
                        });
                        _context.SaveChanges();
                    }
                    catch
                    {
                        throw;
                    }
                }
                else
                {
                    return NotFound("No se pudieron agregar los Usuarios" + guardados.Count);
                }
            }
            else
            {
                return BadRequest("No se recibió información para almacenar");
            }
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            try
            {
                string jsonString = JsonSerializer.Serialize(cliente);
                _context.Bitacoras.Add(new Bitacora
                {
                    IdMetodo = 4,
                    IdModulo = 1,
                    Descripcion = jsonString
                });
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }


            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
