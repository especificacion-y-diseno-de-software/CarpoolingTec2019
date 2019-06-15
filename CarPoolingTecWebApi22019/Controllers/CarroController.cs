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
    /// Controlador para interactuar con los carros de una persona.
    /// </summary>
    public class CarroController : ApiController
    {
        private CARPOOLINGTECWebApi2019_dbEntities dbEntities = new CARPOOLINGTECWebApi2019_dbEntities();
        private string respond = "{\"respond\": 0}";

        /// <summary>
        /// not implemented yet.
        /// </summary>
        public IEnumerable<CARRO> Get()
        {
            return dbEntities.CARROes.ToList();
        }

        /// <summary>
        /// Metodo para obtener todos los carros de una persona.
        /// </summary>
        /// <param name="id">La identificacion de la persona.</param>
        public IEnumerable<usp_GetCarro_Result> Get(int id)
        {
            var tt = dbEntities.usp_GetCarro(id);
            return tt.ToList();
        }

        /// <summary>
        /// Metodo para ingresar un nuevo carro.
        /// </summary>
        /// <param name="pCarro"> Es un objeto tipo carro, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string Post([FromBody]CARRO pCarro)
        {
            dbEntities.usp_PostCarro(pCarro.CA_placa, pCarro.CA_marca, pCarro.CA_modelo, 
                                     pCarro.CA_pasa_cant, pCarro.CA_userID);
            dbEntities.SaveChanges();
            return respond;
        }

        /// <summary>
        /// Metodo para eliminar un carro.
        /// </summary>
        /// <param name="pPlaca"> objeto tipo string, es identificador de la placa.</param>
        public string Delete(string pPlaca)
        {
            dbEntities.usp_DelCarro(pPlaca);
            dbEntities.SaveChanges();
            return respond;
        }
    }
}
