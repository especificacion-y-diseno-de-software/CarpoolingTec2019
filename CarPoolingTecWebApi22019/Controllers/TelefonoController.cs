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
    /// Controlador para interactuar con los telefonos de una persona.
    /// </summary>
    public class TelefonoController : ApiController
    {
        private CARPOOLINGTECWebApi2019_dbEntities dbEntities = new CARPOOLINGTECWebApi2019_dbEntities();
        private string respond = "{\"respond\": 0}";

        /// <summary>
        /// not implemented yet.
        /// </summary>
        public IEnumerable<TELEFONO> Get()
        {
            return dbEntities.TELEFONOS.ToList();
        }

        /// <summary>
        /// Metodo para obtener todos los telefonos de una persona.
        /// </summary>
        /// <param name="id">La identificacion de la persona.</param>
        public IEnumerable<String> Get(int id)
        {
            var tt = dbEntities.usp_GetTelefonos(id);
            return tt.ToList();
        }

        /// <summary>
        /// Metodo para ingresar un nuevo telefono.
        /// </summary>
        /// <param name="pTelefono"> Es un objeto tipo telefono, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string Post([FromBody]TELEFONO pTelefono)
        {
            dbEntities.usp_PostTelefono(pTelefono.TE_telefono, pTelefono.TE_userID);
            dbEntities.SaveChanges();
            return respond;
        }

        /// <summary>
        /// Metodo para eliminar un telefono.
        /// </summary>
        /// <param name="pTelefono"> Es un objeto tipo telefono, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string Delete([FromBody]TELEFONO pTelefono)
        {
            dbEntities.usp_DelTelefono(pTelefono.TE_telefono, pTelefono.TE_userID);
            dbEntities.SaveChanges();
            return respond;
        }
    }
}
