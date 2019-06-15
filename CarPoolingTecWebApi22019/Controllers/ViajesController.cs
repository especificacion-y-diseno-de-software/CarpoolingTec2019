using CarPoolingTecWebApi22019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarPoolingTecWebApi22019.Controllers
{
    /// <summary>
    /// Controlador para interactuar con los viajes de 
    /// un chofer.
    /// </summary>
    public class ViajesController : ApiController
    {
        private CARPOOLINGTECWebApi2019_dbEntities dbEntities = new CARPOOLINGTECWebApi2019_dbEntities();
        private string respond = "{\"respond\": 0}";

        /// <summary>
        /// Not implemented yet.
        /// </summary>
        public IEnumerable<VIAJE> Get()
        {
            return dbEntities.VIAJES.ToList();
        }

        /// <summary>
        /// Metodo para obtener la informacion de un viaje creado 
        /// por un chofer, incluye info de persona y su carro.
        /// </summary>
        /// <param name="id">La identificacion del viaje.</param>
        public IEnumerable<usp_GetInfoViaje_Result> GetInfoViaje(int id)
        {
            var tt = dbEntities.usp_GetInfoViaje(id);
            return tt.ToList();
        }

        /// <summary>
        /// Metodo para ingresar un nuevo viaje
        /// </summary>
        /// <param name="pViajes"> Es un objeto tipo viaje, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string Post([FromBody]VIAJE pViajes)
        {
            dbEntities.usp_PostViajes(pViajes.VI_choferID, pViajes.VI_fecha, pViajes.VI_fecha );
            dbEntities.SaveChanges();
            return respond;
        }

        /// <summary>
        /// Metodo para establecerle un parqueo a un 
        /// viaje.
        /// <remarks>
        /// Nota: se hace realmente una actualizacion 
        ///     a la informacion del viaje.
        /// </remarks>
        /// </summary>
        /// <param name="pViaje"> Es un objeto tipo viaje, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string PutParqueoToViaje([FromBody]VIAJE pViaje)
        {
            dbEntities.usp_PutNoParqueo(pViaje.VI_ID, pViaje.VI_parqueo);
            dbEntities.SaveChanges();
            return respond;
        }
    }
}
