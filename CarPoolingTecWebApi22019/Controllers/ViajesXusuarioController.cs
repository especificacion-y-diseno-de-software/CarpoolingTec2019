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
    /// Controlador para interactuar con los viajes 
    /// colaborativos de un usuario.
    /// </summary>
    public class ViajesXusuarioController : ApiController
    {
        private CARPOOLINGTECWebApi2019_dbEntities dbEntities = new CARPOOLINGTECWebApi2019_dbEntities();
        private string respond = "{\"respond\": 0}";

        /// <summary>
        /// Not implemented yet.
        /// </summary>
        public IEnumerable<VIAJESXUSUARIO> Get()
        {
            return dbEntities.VIAJESXUSUARIOs.ToList();
        }

        /// <summary>
        /// Metodo para la informacion de los viajes que ha 
        /// realizado una persona.
        /// </summary>
        /// <param name="id">La identificacion de la persona.</param>
        public IEnumerable<usp_GetInfoViaje_Result> GetInfoViaje(int id)
        {
            var tt = dbEntities.usp_GetInfoViaje(id);
            return tt.ToList();
        }

        /// <summary>
        /// Metodo para obtener la cantidad de personas que han 
        /// viajado en todos los viajes que ha realizado una persona.
        /// </summary>
        /// <param name="id">La identificacion de la persona.</param>
        public IEnumerable<usp_GetCantPassViaje_Result> GetCantPassPViaje(int id)
        {
            var tt = dbEntities.usp_GetCantPassViaje(id);
            return tt.ToList();
        }

        /// <summary>
        /// Metodo para ingresar un nuevo viaje colaborativo de un usuario
        /// </summary>
        /// <param name="pViajesXusuario"> Es un objeto tipo usuario, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string Post([FromBody]VIAJESXUSUARIO pViajesXusuario)
        {
            dbEntities.usp_PostViajesXusuario(pViajesXusuario.VU_userID, pViajesXusuario.VU_viajeID,
                                    pViajesXusuario.VU_codigoViaje);
            dbEntities.SaveChanges();
            return respond;
        }

        /// <summary>
        /// Metodo para agregar los puntos ganados a un viaje realizado.
        /// </summary>
        /// <param name="pViajesXusuario"> Es un objeto tipo viajesXusuario, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string PutPuntos([FromBody]VIAJESXUSUARIO pViajesXusuario)
        {
            dbEntities.usp_PutPuntaje(pViajesXusuario.VU_viajeID, pViajesXusuario.VU_userID, 
                                      pViajesXusuario.VU_puntajeXviaje);
            dbEntities.SaveChanges();
            return respond;
        }
    }
}

