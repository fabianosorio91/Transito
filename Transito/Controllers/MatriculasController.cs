using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using Transito.DTO;
using Transito.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Transito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculasController : ControllerBase
    {
        private readonly TransitoContext _context;

        public MatriculasController(TransitoContext context)
        {
            _context = context;
        }
        #region GET
        // GET: api/<MatriculaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculaDTO>>> Get()

        {
            var matricula = await _context.Matriculas.Select(x =>
            new MatriculaDTO
            {
                Id = x.Id,
                Numero = x.Numero,
                FechaExpedicion= x.FechaExpedicion,
                ValidaHasta= x.ValidaHasta,
                Activo= x.Activo
             
            }).ToListAsync();

            if (matricula == null)
            {
                return NotFound();
            }
            else
            {
                return matricula;
            }

        }
        #endregion GET
        #region GETXID
        // GET api/<MatriculaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatriculaDTO>> Get(int id)
        {
            var matricula = await _context.Matriculas.Select(x =>
            new MatriculaDTO
            {
                Id = x.Id,
                Numero = x.Numero,
                FechaExpedicion = x.FechaExpedicion,
                ValidaHasta = x.ValidaHasta,
                Activo = x.Activo

            }).FirstOrDefaultAsync();
            try
            {
                if (matricula == null)
                {
                    return NotFound();
                }
                else
                {
                    return matricula;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        #endregion GETXID

        // POST api/<MatriculaController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(MatriculaDTO matriculadto)
        {
            try
            {
                var entity = new Matricula()
                {
                    Numero= matriculadto.Numero,
                    FechaExpedicion= matriculadto.FechaExpedicion,
                    ValidaHasta= matriculadto.ValidaHasta,
                    Activo = matriculadto.Activo
                };

                _context.Matriculas.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;

        }

        // PUT api/<MatriculaController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(MatriculaDTO matriculadto)
        {
            try
            {
                var entity = await _context.Matriculas.FirstOrDefaultAsync(a => a.Id == matriculadto.Id);

                entity.Id = matriculadto.Id;
                entity.Numero = matriculadto.Numero;
                entity.FechaExpedicion = matriculadto.FechaExpedicion;
                entity.ValidaHasta = matriculadto.ValidaHasta;
                entity.Activo = matriculadto.Activo;
               


                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.NoContent;
        }

        // DELETE api/<MatriculaController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return HttpStatusCode.BadRequest;
            }
            else
            {
                _context.Entry(matricula).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
            return HttpStatusCode.OK;
        }
    }
}
