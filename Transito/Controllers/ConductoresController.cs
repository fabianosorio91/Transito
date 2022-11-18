using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using Transito.DTO;
using Transito.Entities;

namespace Transito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductoresController : ControllerBase
    {
        private readonly TransitoContext _context;

        public ConductoresController(TransitoContext context)
        {
            _context = context;
        }
        #region GET 
        // GET: api/<ConductoresController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConductorDTO>>> Get()
               {
            var conductor = await _context.Conductores.Select(x=> 
            new ConductorDTO
            {
                Id = x.Id,
                Identificacion = x.Identificacion,
                Nombre= x.Nombre,
                Apellidos= x.Apellidos,
                Direccion= x.Direccion,
                Telefono= x.Telefono,
                Email= x.Email,
                FechaNacimiento= x.FechaNacimiento,
                Activo= x.Activo,
                MatriculaId= x.MatriculaId              

            }).ToListAsync();

            if (conductor == null)
            {
                return NotFound();
            }
            else
            {
                return conductor;
            }
        }
        #endregion GET 
        #region GET X ID 
        // GET api/<ConductoresController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConductorDTO>> Get(int id)
        {
            var conductor = await _context.Conductores.Select(x =>
            new ConductorDTO
            {
                Id = x.Id,
                Identificacion = x.Identificacion,
                Nombre = x.Nombre,
                Apellidos = x.Apellidos,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                Email = x.Email,
                FechaNacimiento = x.FechaNacimiento,
                Activo = x.Activo,
                MatriculaId = x.MatriculaId

            }).FirstOrDefaultAsync();
            try
            {
                if (conductor == null)
                {
                    return NotFound();
                }
                else
                {
                    return conductor;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        #endregion GET X ID 
        #region POST OK
        // POST api/<ConductoresController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(ConductorDTO conductordto)
        {
            try
            {
                var entity = new Conductore()
                {

                    Identificacion = conductordto.Identificacion,
                    Nombre = conductordto.Nombre,
                    Apellidos = conductordto.Apellidos,
                    Direccion = conductordto.Direccion,
                    Telefono = conductordto.Telefono,
                    Email = conductordto.Email,
                    Activo= conductordto.Activo,
                    MatriculaId = conductordto.MatriculaId
                };

                _context.Conductores.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;

        }
        #endregion POST OK
        #region PUT 
        // PUT api/<ConductoresController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(ConductorDTO conductordto)
        {
            var entity = await _context.Conductores.FirstOrDefaultAsync(a => a.Id == conductordto.Id);

            entity.Id = conductordto.Id;
            entity.Identificacion = conductordto.Identificacion;
            entity.Nombre = conductordto.Nombre;
            entity.Apellidos = conductordto.Apellidos;
            entity.Direccion = conductordto.Direccion;
            entity.Telefono = conductordto.Telefono;
            entity.Email = conductordto.Email;
            entity.Activo = conductordto.Activo;
            entity.MatriculaId = conductordto.MatriculaId;

            try
            {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.InnerException.Message);
        }
        return HttpStatusCode.NoContent;
        }

        #endregion PUT 
        #region DELETE OK
        // DELETE api/<ConductoresController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var conductor = await _context.Conductores.FindAsync(id);
            if (conductor == null)
            {
                return HttpStatusCode.BadRequest;
            }
            else
            {
                _context.Entry(conductor).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
            return HttpStatusCode.OK;
        }
        #endregion DELETE OK
    }
}
