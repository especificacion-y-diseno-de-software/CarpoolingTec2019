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
    /// Controlador para interactuar con las notificaciones de una persona.
    /// </summary>
    public class NotificacionesController : ApiController
    {
        private CARPOOLINGTECWebApi2019_dbEntities dbEntities = new CARPOOLINGTECWebApi2019_dbEntities();
        private string respond = "{\"respond\": 0}";

        /// <summary>
        /// Metodo para obtener todas las notificaciones de una persona.
        /// </summary>
        /// <param name="id"> Es un identificador de la persona asociada.</param>
        public IEnumerable<usp_GetNotifi_Result> Get(int id)
        {
            return dbEntities.usp_GetNotifi(id);
        }

        /// <summary>
        /// Metodo para ingresar una nueva notificacion de una persona.
        /// </summary>
        /// <param name="pNotifi"> Es un objeto tipo notificacion, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string Post([FromBody]NOTIFICACIONE pNotifi)
        {
            dbEntities.usp_PostNotifi(pNotifi.NO_userID, pNotifi.NO_type, pNotifi.NO_descrip);
            dbEntities.SaveChanges();
            return respond;
        }

        /// <summary>
        /// Metodo para borrar una notificacion.
        /// </summary>
        /// <remarks>
        /// Nota: luego de leida la notificacion se elimina para
        /// no sobrecargar la base de datos.
        /// </remarks>
        /// <param name="id"> Es un identificador de la notificacion</param>
        public string Delete(int id)
        {
            dbEntities.usp_DelNotifi(id);
            dbEntities.SaveChanges();
            return respond;
        }
    }
}
