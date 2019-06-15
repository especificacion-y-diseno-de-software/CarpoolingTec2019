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
    /// Controlador para interactuar con los datos de los 
    /// usuarios.
    /// </summary>
    public class UsuarioController : ApiController
    {
        private CARPOOLINGTECWebApi2019_dbEntities dbEntities = new CARPOOLINGTECWebApi2019_dbEntities();
        private string respond = "{\"respond\": 0}";

        /// <summary>
        /// metodo para obtener una lista con todos los 
        /// id y nombre de las personas registradas.
        /// Usar solo para pruebas.
        /// </summary>
        public IEnumerable<usp_GetAllUser_Result> Get()
        {
            return dbEntities.usp_GetAllUser();
        }

        /// <summary>
        /// Metodo para obtener la informacion completa de un
        /// usuario.
        /// </summary>
        /// <param name="id">La identificacion de la persona.</param>
        public IEnumerable<usp_GetUsuario_Result> Get(int id)
        {
            var tt = dbEntities.usp_GetUsuario(id);
            return tt.ToList();
        }

        /// <summary>
        /// Metodo para ingresar un nuevo usuario
        /// </summary>
        /// <param name="pUser"> Es un objeto tipo usuario, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string Post([FromBody]USUARIO pUser)
        {
            dbEntities.usp_PostUsuario(pUser.US_ID, pUser.US_nombre,
                                        pUser.US_apellido1, pUser.US_apellido2,
                                        pUser.US_correo, pUser.US_rol, 
                                        pUser.US_estadoCuenta, pUser.US_categoria);
            dbEntities.SaveChanges();
            return respond;
        }

        /// <summary>
        /// Metodo para actualizar la informacion de un
        /// usuario.
        /// </summary>
        /// <remarks>
        /// Nota: se usa este para remover el elimidado de una persona.
        /// </remarks>
        /// <param name="pUser"> Es un objeto tipo usuario, se debe de 
        ///                   ingresar en el cuerpo del llamado a 
        ///                   la pagina web.</param>
        public string Put([FromBody]USUARIO pUser)
        {
            dbEntities.usp_PutUsuario(pUser.US_ID, pUser.US_nombre,
                                        pUser.US_apellido1, pUser.US_apellido2,
                                        pUser.US_correo, pUser.US_rol,
                                        pUser.US_estadoCuenta, pUser.US_categoria);
            dbEntities.SaveChanges();
            return respond;
        }

        /// <summary>
        /// Metodo para eliminar un usuario.
        /// </summary>
        /// <param name="id"> Es un identificador del usuario</param>
        public string Delete(int id)
        {
            dbEntities.usp_DelUsuario(id);
            dbEntities.SaveChanges();
            return respond;
        }
    }
}
