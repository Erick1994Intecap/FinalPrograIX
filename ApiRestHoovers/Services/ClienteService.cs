using ApiRestHoovers.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestHoovers.Services
{
    public class ClienteService
    {
        private SqlConnection _Conn = new SqlConnection();

        public List<TotalViaje> getTotalViajes(string idCliente)
        {
            
            _Conn = SqlService.GetSqlConnection();
            _Conn.Open();
            var result = _Conn.Query<TotalViaje>("SELECT NOMBRE, COUNT(1) TOTAL FROM VW_VIAJE_CLIENTE"+
                " WHERE ID_CLIENTE = ISNULL("+ nullToString(idCliente) + ", ID_CLIENTE) GROUP BY NOMBRE").ToList();
            return result;

        }

        public List<TotalViaje> getTotalViajesDepto(string idDepto)
        {

            _Conn = SqlService.GetSqlConnection();
            _Conn.Open();
            var result = _Conn.Query<TotalViaje>("SELECT D.NOMBRE, COUNT(1) TOTAL FROM VIAJE V JOIN DEPARTAMENTO D ON V.ID_DEPTO_VIAJE = D.ID" +
                " WHERE ID_DEPTO_VIAJE = ISNULL(" + nullToString(idDepto) + ", ID_DEPTO_VIAJE) GROUP BY D.NOMBRE").ToList();
            return result;

        }

        public List<ReporteVista> GetReportAll()
        {
            _Conn = SqlService.GetSqlConnection();
            _Conn.Open();
            List<ReporteVista> result = _Conn.Query<ReporteVista>("SELECT * FROM VW_VIAJE_CLIENTE").ToList();
            _Conn.Close();
            return result;
        }

        public List<ViajesByIdDates> getTotalViajesIdClientAndDates(string idCliente, string fechaInicio, string fechaFin)
        {
            _Conn = SqlService.GetSqlConnection();
            _Conn.Open();

            var result = _Conn.Query<ViajesByIdDates>("SELECT NOMBRE AS CLIENTE, COUNT(1) VIAJES FROM VW_VIAJE_CLIENTE " +
                   "WHERE ID_CLIENTE = ISNULL(" + nullToString(idCliente) + ", ID_CLIENTE)" +
                    " AND FECHA_VIAJE BETWEEN ISNULL("+ nullToStringDate(fechaInicio) + ", FECHA_VIAJE) AND ISNULL(" + nullToStringDate(fechaFin) + ", FECHA_FIN)"+
                    " GROUP BY NOMBRE").ToList();

            
            return result;

        }

        public List<ViajesYearMothTotals> getTotalViajesByDates(string fechaInicio, string fechaFin)
        {
            _Conn = SqlService.GetSqlConnection();
            _Conn.Open();
            var result = _Conn.Query<ViajesYearMothTotals>("SELECT YEAR(FECHA_VIAJE) ANIO, MONTH(FECHA_VIAJE) MES, COUNT(1) VIAJES FROM VW_VIAJE_CLIENTE " +
                   "WHERE FECHA_VIAJE BETWEEN ISNULL(" + nullToStringDate(fechaInicio) + ", FECHA_VIAJE) AND ISNULL(" + nullToStringDate(fechaFin) + ", FECHA_FIN)" +
                   "GROUP BY YEAR(FECHA_VIAJE), MONTH(FECHA_VIAJE)").ToList();

            if (result.Count != 0)
            {
                return result;
            } else
            {
                return null;
            }
        }

        public string nullToString(string? value)
        {
            if (value == null) return "NULL";
            return value;
        }

        public string nullToStringDate(string? value)
        {
            if (value == null) return "NULL";
            return "'"+value+"'";
        }


        public List<ClienteResult> GetClientes()
        {
            _Conn = SqlService.GetSqlConnection();
            _Conn.Open();
            List<ClienteResult> result = _Conn.Query<ClienteResult>("SELECT * FROM CLIENTE").Where(x => x.Estado == 1).ToList();
            _Conn.Close();
            return result;
        }

        public List<VehiculoResult> GetVehiculos()
        {
            _Conn = SqlService.GetSqlConnection();
            _Conn.Open();
            List<VehiculoResult> result = _Conn.Query<VehiculoResult>("SELECT * FROM VEHICULO").Where(x => x.Estado == 1).ToList();
            _Conn.Close();
            return result;
        }

        public List<ViajeResult> GetViajes()
        {
            _Conn = SqlService.GetSqlConnection();
            _Conn.Open();
            List<ViajeResult> result = _Conn.Query<ViajeResult>("SELECT * FROM VIAJE").ToList();
            _Conn.Close();
            return result;
        }

    }
}
