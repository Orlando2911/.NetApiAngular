using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECRUD.Models;
using Azure;
using System.Diagnostics.CodeAnalysis;
using System;
using Microsoft.AspNetCore.Cors;

namespace ECRUD.Controllers
{
    [EnableCors("CorsRules")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        public readonly TamtestContext _dbcontext;

        public PersonController(TamtestContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()   {
            List<Person> lista = new List<Person>();

            try
            {
                lista = _dbcontext.People.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }

        }

        [HttpGet]
        [Route("Obtener/{idperson}")]
        public IActionResult Obtener(string idperson)
            {
            Person oPerson = _dbcontext.People.Find(idperson);

            if (oPerson == null)
            {
                return BadRequest("Persona no encontrada");
            }

                try
                {
                oPerson = _dbcontext.People.Where(p => p.Idperson == idperson).FirstOrDefault();
           
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oPerson });
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oPerson });
                }
            }

        [HttpPost]
        [Route("Guardar")]

        public IActionResult Guardar([FromBody] Person objeto)
        {

            try
            {
                _dbcontext.People.Add(objeto);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok"});

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message});

            }

        }

        [HttpPut]
        [Route("Editar")]

        public IActionResult Editar([FromBody] Person objeto)
        {
            Person oPerson = _dbcontext.People.Find(objeto.Idperson);

            if (oPerson == null)
            {
                return BadRequest("Persona no encontrada");
            }

            try
            {
                oPerson.Name = objeto.Name is null?  oPerson.Name : objeto.Name;
                oPerson.Lastname = objeto.Lastname is null ? oPerson.Lastname : objeto.Lastname;
                oPerson.UserPhoto = objeto.UserPhoto is null ? oPerson.UserPhoto : objeto.UserPhoto;
                oPerson.Borthdate = objeto.Borthdate is null ? oPerson.Borthdate : objeto.Borthdate;
                oPerson.Status= objeto.Status is null ? oPerson.Status : objeto.Status;
                oPerson.Brothers = objeto.Brothers is null ? oPerson.Brothers : objeto.Brothers;


                _dbcontext.People.Update(oPerson);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }

        }

        [HttpDelete]
        [Route("Eliminar/{idperson}")]
        public IActionResult Eliminar (string idperson)
        {

            Person oPerson = _dbcontext.People.Find(idperson);

            if (oPerson == null)
            {
                return BadRequest("Persona no encontrada");
            }

            try
            {
                

                _dbcontext.People.Remove(oPerson);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }


        }
    }
}
