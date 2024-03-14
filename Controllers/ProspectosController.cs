using Prospectos.Models;
using Prospectos.Services;
using Prospectos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Prospectos.Data.Interfaces;
using System.Net;

namespace Prospectos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProspectosController : ControllerBase
    {
        private readonly IApiRepository _repository;

        public ProspectosController(IApiRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]Parameters parameters)
        {
            parameters.sort.direction = parameters.sort.direction.ToUpper();
            var table = await _repository.GetProspectosAsync(parameters);

            return Ok(table);
        }

        [HttpGet("{nProspecto:int}")]
        public async Task<IActionResult> GetOne(int nProspecto)
        {
            var prospecto = await _repository.GetProspectoByIdAsync(nProspecto);
         
            return Ok(prospecto);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Prospecto prospecto)
        {
            prospecto.Estatus = await _repository.GetEstatusByIdAsync(prospecto.nEstatus);
            _repository.Add(prospecto);
            if (await _repository.SaveAll())
                return Ok(prospecto);
            else
                return BadRequest();

        }


        [HttpPut("{nProspecto:int}")]
        public IActionResult Update([FromBody] Prospecto prospecto)
        {
            _repository.Update(prospecto);
            _repository.SaveAll();
            return Ok();
        }

        [HttpPut("autorizar/{nProspecto:int}")]
        public async Task<IActionResult> Autorizar(int nProspecto)
        {
            var prospecto = await _repository.GetProspectoByIdAsync(nProspecto);
            prospecto.Estatus = await _repository.GetEstatusByIdAsync(2);
            _repository.SaveAll();
            return Ok(true);
        }

        [HttpPut("rechazar/{nProspecto:int}")]
        public async Task<IActionResult> Rechazar([FromBody]RechazoProspecto rechazo, int nProspecto)
        {
            var prospecto = await _repository.GetProspectoByIdAsync(nProspecto);
            prospecto.Estatus = await _repository.GetEstatusByIdAsync(3);
            prospecto.cObservacionesRechazo = rechazo.cObservacionesRechazo;
            _repository.SaveAll();
            return Ok(true);
        }


    }
}
