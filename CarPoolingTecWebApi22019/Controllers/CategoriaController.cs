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
    /// Controlador para interactuar con las categorias.
    /// </summary>
    public class CategoriaController : ApiController
    {
        private CARPOOLINGTECWebApi2019_dbEntities dbEntities = new CARPOOLINGTECWebApi2019_dbEntities();
        private string respond = "{\"respond\": 0}";

        /// <summary>
        /// Metodo para obtener todas las categorias conocidas.
        /// </summary>
        public IEnumerable<usp_GetCategorias_Result> Get()
        {
            return dbEntities.usp_GetCategorias() .ToList();
        }

        /// <summary>
        /// Metodo para ingresar una nueva categoria.
        /// </summary>
        /// <param name="pCategoria"> Es un objeto tipo categoria, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string Post([FromBody]CATEGORIA pCategoria)
        {
            dbEntities.usp_PostCategoria(pCategoria.CA_nombre, pCategoria.CA_puntaje, 
                                         pCategoria.CA_Umbral, pCategoria.CA_UmbralPmes);
            dbEntities.SaveChanges();
            return respond;
        }

        /// <summary>
        /// Metodo para actualizar una categoria.
        /// </summary>
        /// <param name="pCategoria"> Es un objeto tipo categoria, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string Put([FromBody]CATEGORIA pCategoria)
        {
            dbEntities.usp_PutCategoria(pCategoria.CA_ID, pCategoria.CA_nombre, pCategoria.CA_puntaje,
                                         pCategoria.CA_Umbral, pCategoria.CA_UmbralPmes);
            dbEntities.SaveChanges();
            return respond;
        }

        /// <summary>
        /// Metodo para eliminar una categoria.
        /// </summary>
        /// <param name="id"> Es un identificador de la categoria</param>
        public string Delete(int id)
        {
            dbEntities.usp_DelCategoria(id);
            dbEntities.SaveChanges();
            return respond;
        }
    }
}
