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
    /// Controlador para interactuar con los amigos de una persona.
    /// </summary>
    public class AmigoController : ApiController
    {
        private CARPOOLINGTECWebApi2019_dbEntities dbEntities = new CARPOOLINGTECWebApi2019_dbEntities();
        private string respond = "{\"respond\": 0}";

        /// <summary>
        /// not implemented yet.
        /// </summary>
        public IEnumerable<AMIGO> Get()
        {
            return dbEntities.AMIGOS.ToList();
        }

        /// <summary>
        /// Metodo para obtener todos los amigos de una persona.
        /// </summary>
        /// <param name="id">La identificacion de la persona.</param>
        public IEnumerable<usp_GetAmigos_Result> Get(int id)
        {
            var tt = dbEntities.usp_GetAmigos(id);
            return tt.ToList();
        }

        /// <summary>
        /// Metodo para ingresar una nueva amistad.
        /// </summary>
        /// <param name="pAmigo"> Es un objeto tipo amigo, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string Post([FromBody]AMIGO pAmigo)
        {
            dbEntities.usp_PostAmigo(pAmigo.AA_userID,pAmigo.AA_amigoID);
            dbEntities.SaveChanges();
            return respond;
        }

        /// <summary>
        /// Metodo para eliminar una amistad :(.
        /// </summary>
        /// <param name="pAmigo"> Es un objeto tipo amigo, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string Delete([FromBody]AMIGO pAmigo)
        {
            dbEntities.usp_DelAmigo(pAmigo.AA_userID, pAmigo.AA_amigoID);
            dbEntities.SaveChanges();
            return respond;
        }
    }
}
