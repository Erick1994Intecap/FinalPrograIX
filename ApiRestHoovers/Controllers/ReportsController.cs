using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRestHoovers.Models;
using ApiRestHoovers.Services;

namespace ApiRestHoovers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly HOOVERSContext _context;

        public ReportsController(HOOVERSContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("infoReport")]
        public ActionResult<List<ReporteVista>> GetInfoReport()
        {
            var clienteService = new ClienteService();
            List<ReporteVista> report = clienteService.GetReportAll();

            return Ok(report);
        }

        [HttpGet]
        [Route("viajesPorCliente")]
        public ActionResult<List<TotalViaje>> GetTotal(string idCliente)
        {
            var clienteService = new ClienteService();
            return Ok(clienteService.getTotalViajes(idCliente));
        }

        [HttpGet]
        [Route("viajesPorDepartamento")]
        public ActionResult<List<TotalViaje>> GetTotalDepto(string id_departamento)
        {
            var clienteService = new ClienteService();
            return Ok(clienteService.getTotalViajesDepto(id_departamento));
        }

        [HttpGet]
        [Route("viajesByIdAndDates")]
        public ActionResult<List<ViajesByIdDates>> GetReportOne(string idCliente, string fechaInicio, string fechaFin)
        {
            var clienteService = new ClienteService();
            return Ok(clienteService.getTotalViajesIdClientAndDates(idCliente, fechaInicio, fechaFin));
        }

        [HttpGet]
        [Route("GetViajesByDates")]
        public ActionResult<List<ViajesYearMothTotals>> GetReportTwo(string fechaInicio, string fechaFin)
        {
            var clienteService = new ClienteService();
            {
                var cliente = clienteService.getTotalViajesByDates(fechaInicio, fechaFin);
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound("Error: No existen viajes en este rango de fechas");
            }
        }

        [HttpGet]
        [Route("GetVehiculosConsultados")]
        public ActionResult<List<VehiculosConsultados>> GetReportVConsultados()
        {
            var clienteService = new ClienteService();
            {
                var cliente = clienteService.GetVehiculosConsultados();
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound();
            }
        }


        [HttpGet]
        [Route("GetDetalleVehiculosConsultados")]
        public ActionResult<List<DetalleVehiculos>> GetReportDetalleVConsultados()
        {
            var clienteService = new ClienteService();
            {
                var cliente = clienteService.GetDetalleVehiculosConsultados();
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound();
            }
        }
    }
}


