using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Net;
using Transito.DTO;
using Transito.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Transito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SancionesController : ControllerBase
    {
        private readonly TransitoContext _Context;

        public SancionesController(TransitoContext context)
        {
            _Context = context;
        }

        // GET: api/<SancionesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SancionesDTO>>> Get()
        {
            var sancion = await _Context.Sanciones.Select(x =>
            new SancionesDTO
            {
                Id = x.Id,
                FechaActual= x.FechaActual,                
                Sancion= x.Sancion,
                Observacion= x.Observacion,
                Valor= x.Valor,
                ConductoresId = x.ConductoresId,
                
            }).ToListAsync();

            if (sancion == null)
            {
                return NotFound();
            }
            else
            {
                return sancion;
            }
        }

        // GET api/<SancionesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SancionesDTO>>> Get(int ID)
        {
            try
            {
                var sancion = await _Context.Sanciones.Select(x =>
                new SancionesDTO
                {
                    Id = x.Id,
                    FechaActual = x.FechaActual,
                    Sancion = x.Sancion,
                    Observacion = x.Observacion,
                    Valor = x.Valor,
                    ConductoresId = x.ConductoresId,

                }).FirstOrDefaultAsync();

                if (sancion == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(sancion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        // POST api/<SancionesController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(SancionesDTO sancionesdto)
        {
            try
            {
                var entity = new Sancione()
                {
                    FechaActual= sancionesdto.FechaActual,
                    Sancion = sancionesdto.Sancion,
                    Observacion= sancionesdto.Observacion,
                    Valor= sancionesdto.Valor,
                    ConductoresId= sancionesdto.ConductoresId,                 

                };

                _Context.Sanciones.Add(entity);
                await _Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;

        }

        // PUT api/<SancionesController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(SancionesDTO sancionesdto)
        {
            var entity = await _Context.Sanciones.FirstOrDefaultAsync(a => a.Id == sancionesdto.Id);

            entity.Id = sancionesdto.Id;
            entity.FechaActual = sancionesdto.FechaActual;
            entity.Sancion = sancionesdto.Sancion;
            entity.Observacion = sancionesdto.Observacion;
            entity.Valor = sancionesdto.Valor;
            entity.ConductoresId = sancionesdto.ConductoresId; 

            try
            {
                _Context.Entry(entity).State = EntityState.Modified;
                await _Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.NoContent;
        }

        // DELETE api/<SancionesController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var sancion = await _Context.Sanciones.FindAsync(id);
            if (sancion == null)
            {
                return HttpStatusCode.BadRequest;
            }
            else
            {
                _Context.Entry(sancion).State = EntityState.Deleted;
                await _Context.SaveChangesAsync();
            }
            return HttpStatusCode.OK;
        }
    }
}
