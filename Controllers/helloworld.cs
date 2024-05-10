using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using Newtonsoft.Json; //nugget json instalado

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class helloworld : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }

        [HttpGet("GetSaludo/{nombre}")]
        public string Get(string nombre)
        {
            return "Hola " + nombre;
        }

        private struct User // preg a Mau
        {
            public string nombre;
            public int id;
            public string edad;
        }

        [HttpGet("GetUsuario/{id}/{nombre}/{edad}")]  //parametros que recibe entre {}, separados por /
        public string Get(int id, string nombre, string edad)
        {
            User usuario = new User();
            usuario.edad = edad;
            usuario.id = id;
            usuario.nombre = nombre;

            string respuesta = JsonConvert.SerializeObject(usuario); //me convierte "respuesta"a Json
            return respuesta;
        }

        public class UsuarioP
        {
            public int id { get; set; }
            public string name { get; set; }
        } 

        [HttpPost("PostUser")]
        public string Post(UsuarioP usuario)
        {
            return JsonConvert.SerializeObject(usuario);
        }

        [HttpPatch("UpdateUser")]
        public string Patch(UsuarioP usuario)
        {
            return "Se actualizó el usuario correctamente";
        }

        [HttpDelete("DelUsuario")]
        public string Delete(int idusuario)
        {
            return "Se eliminó el usuario correctamente";
        }
    }
}
