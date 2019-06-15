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
    /// Controlador para interactuar con los objetos 
    /// intercambiados por puntos realizado por una persona.
    /// </summary>
    public class ObjetosIntercambioController : ApiController
    {
        private CARPOOLINGTECWebApi2019_dbEntities dbEntities = new CARPOOLINGTECWebApi2019_dbEntities();
        private string respond = "{\"respond\": 0}";

        /// <summary>
        /// not implemented yet.
        /// </summary>
        public IEnumerable<OBJETOS_INTERCAMBIO> Get()
        {
            return dbEntities.OBJETOS_INTERCAMBIO.ToList();
        }

        /// <summary>
        /// Metodo para obtener la informacion de todos 
        /// los objetos intercambiados por puntos realizados 
        /// por una persona.
        /// </summary>
        /// <param name="id">La identificacion de la persona.</param>
        public IEnumerable<usp_GetObjIntercambios_Result> Get(int id)
        {
            var tt=dbEntities.usp_GetObjIntercambios(id);
            return tt.ToList();
        }

        /// <summary>
        /// Metodo para obtener los puntos consumidos por una 
        /// persona, usados en los intercambbios.
        /// </summary>
        /// <param name="id">La identificacion de la persona.</param>
        public IEnumerable<int?> GetPuntosGastados(int id)
        {
            var tt = dbEntities.usp_GetPuntosGastados(id);
            return tt.ToList();
        }

        /// <summary>
        /// Metodo para obtener los puntos ganados por una 
        /// persona, ganados durante la realizacion de viajes.
        /// </summary>
        /// <param name="id">La identificacion de la persona.</param>
        public IEnumerable<int?> GetPuntosGanados(int id)
        {
            var tt = dbEntities.usp_GetPuntosGanados(id);
            return tt.ToList();
        }

        /// <summary>
        /// Metodo para ingresar un nuevo producto intercambiado.
        /// </summary>
        /// <param name="pObjetosInt"> Es un objeto tipo objeto_intercambio, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string Post([FromBody]OBJETOS_INTERCAMBIO pObjetosInt)
        {
            dbEntities.usp_PostObjIntercambio(pObjetosInt.OI_ID, pObjetosInt.OI_userID,  pObjetosInt.OI_nombre,
                                                pObjetosInt.OI_cantidad, pObjetosInt.OI_puntaje,
                                                pObjetosInt.OI_precio, pObjetosInt.OI_fecha);
            dbEntities.SaveChanges();
            return respond;
        }
        
    }
}
