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
    public class VehiculoController : ControllerBase
    {
        private readonly HOOVERSContext _context;

        public VehiculoController(HOOVERSContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(int? id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }
            try
            {
                //string jsonString = JsonSerializer.Serialize(vehiculo);
                _context.Bitacoras.Add(new Bitacora
                {
                    IdMetodo = 1,
                    IdModulo = 2,
                    Descripcion = id.ToString()
                });
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return vehiculo;
        }

        [HttpGet]
        public ActionResult<List<VehiculoResult>> Get()
        {
            var vehiculoService = new ClienteService();
            List<VehiculoResult> clientes = vehiculoService.GetVehiculos();
            try
            {

                _context.Bitacoras.Add(new Bitacora
                {
                    IdMetodo = 1,
                    IdModulo = 1,
                    Descripcion = "LISTADO DE TODOS LOS VEHICULOS, NO SE ENVIA JSON"
                });
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return Ok(clientes);
        }

        // PUT: api/Vehiculo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculo(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(new Vehiculo
            {
                Id = vehiculo.Id,
                Modelo = vehiculo.Modelo,
                Nombre = vehiculo.Nombre,
                Descripcion = vehiculo.Descripcion,
                IdTipo = vehiculo.IdTipo,
                Estado = vehiculo.Estado,
                FechaCreacion = DateTime.Now.AddDays(-1),
                FechaActualizacion = DateTime.Now
            }).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                try
                {
                    string jsonString = JsonSerializer.Serialize(vehiculo);
                    _context.Bitacoras.Add(new Bitacora
                    {
                        IdMetodo = 3,
                        IdModulo = 2,
                        Descripcion = jsonString
                    });
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    throw;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
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

        // POST: api/Vehiculo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<String> PostVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add( new Vehiculo { 
                Modelo = vehiculo.Modelo,
                Nombre = vehiculo.Nombre,
                Descripcion = vehiculo.Descripcion,
                IdTipo = vehiculo.IdTipo
            });
            await _context.SaveChangesAsync();
            try
            {
                string jsonString = JsonSerializer.Serialize(vehiculo);
                _context.Bitacoras.Add(new Bitacora
                {
                    IdMetodo = 2,
                    IdModulo = 2,
                    Descripcion = jsonString
                });
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return "Vehiculo creado exitosament";
        }

        [HttpPost("Masivo")]
        public ActionResult<IEnumerable<Vehiculo>> AddUsuario(List<Vehiculo> Usuario)
        {
            List<Vehiculo> guardados = new List<Vehiculo>();
            if (Usuario != null)
            {
                foreach (var item in Usuario)
                {
                    if (item != null)
                    {
                        _context.Vehiculos.Add(new Vehiculo
                        {
                            Modelo = item.Modelo,
                            Nombre = item.Nombre,
                            Descripcion = item.Descripcion,
                            IdTipo = item.IdTipo
                        });

                        guardados.Add(item);
                        //_context.SaveChanges();


                    }
                }
                if (guardados.Count > 0)
                {
                    _context.SaveChanges();
                    try
                    {
                        string jsonString = JsonSerializer.Serialize(Usuario);
                        _context.Bitacoras.Add(new Bitacora
                        {
                            IdMetodo = 3,
                            IdModulo = 2,
                            Descripcion = jsonString
                        });
                        _context.SaveChanges();
                    }
                    catch
                    {
                        throw;
                    }

                    return Ok(guardados);
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

        // DELETE: api/Vehiculo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
            try
            {
                string jsonString = JsonSerializer.Serialize(vehiculo);
                _context.Bitacoras.Add(new Bitacora
                {
                    IdMetodo = 4,
                    IdModulo = 2,
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

        private bool VehiculoExists(int id)
        {
            return _context.Vehiculos.Any(e => e.Id == id);
        }
    }
}
