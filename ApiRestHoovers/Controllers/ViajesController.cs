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
    public class ViajesController : ControllerBase
    {
        private readonly HOOVERSContext _context;

        public ViajesController(HOOVERSContext context)
        {
            _context = context;
        }

        //GET: api/Viajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viaje>>> GetViajes()
        {
            try
            {

                _context.Bitacoras.Add(new Bitacora
                {
                    IdMetodo = 1,
                    IdModulo = 3,
                    Descripcion = "LISTADO DE TODOS LOS VIAJES, NO SE ENVIA JSON"
                });
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return await _context.Viajes.ToListAsync();
        }

        // PUT: api/Viajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViaje(int id, Viaje viaje)
        {
            if (id != viaje.Id)
            {
                return BadRequest();
            }

            _context.Entry(viaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                try
                {
                    string jsonString = JsonSerializer.Serialize(viaje);
                    _context.Bitacoras.Add(new Bitacora
                    {
                        IdMetodo = 3,
                        IdModulo = 3,
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
                if (!ViajeExists(id))
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

        // POST: api/Viajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Viaje>> PostViaje(Viaje viaje)
        {
            _context.Viajes.Add(new Viaje
            {
                IdCliente = viaje.IdCliente,
                IdVehiculo = viaje.IdVehiculo,
                FechaViaje = viaje.FechaViaje,
                FechaFin = viaje.FechaFin,
                IdDeptoViaje = viaje.IdDeptoViaje,
                DescripcionViaje = viaje.DescripcionViaje,
                ViajeRealizado = viaje.ViajeRealizado,
                PrecioViaje = viaje.PrecioViaje
            }
            );
            try
            {
                await _context.SaveChangesAsync();
                try
                {
                    string jsonString = JsonSerializer.Serialize(viaje);
                    _context.Bitacoras.Add(new Bitacora
                    {
                        IdMetodo = 2,
                        IdModulo = 3,
                        Descripcion = jsonString
                    });
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    throw;
                }
            }
            catch (DbUpdateException)
            {
                if (ViajeExists(viaje.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        [HttpPost("Masivo")]
        public ActionResult<IEnumerable<Viaje>> AddViajeMasivo(List<Viaje> Viaje)
        {
            List<Viaje> guardados = new List<Viaje>();
            if (Viaje != null)
            {
                foreach (var item in Viaje)
                {
                    if (item != null)
                    {
                        _context.Viajes.Add(new Viaje
                        {
                            IdCliente = item.IdCliente,
                            IdVehiculo = item.IdVehiculo,
                            FechaViaje = item.FechaViaje,
                            FechaFin = item.FechaFin,
                            IdDeptoViaje = item.IdDeptoViaje,
                            DescripcionViaje = item.DescripcionViaje,
                            ViajeRealizado = item.ViajeRealizado,
                            PrecioViaje = item.PrecioViaje
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
                        string jsonString = JsonSerializer.Serialize(Viaje);
                        _context.Bitacoras.Add(new Bitacora
                        {
                            IdMetodo = 3,
                            IdModulo = 3,
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

        // DELETE: api/Viajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViaje(int id)
        {
            var viaje = await _context.Viajes.FindAsync(id);
            if (viaje == null)
            {
                return NotFound();
            }

            _context.Viajes.Remove(viaje);
            await _context.SaveChangesAsync();
            try
            {
                string jsonString = JsonSerializer.Serialize(viaje);
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

        private bool ViajeExists(int id)
        {
            return _context.Viajes.Any(e => e.Id == id);
        }
    }
}
