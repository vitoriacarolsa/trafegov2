using AutoMapper;
using fiap.Data;
using fiap.Models;
using fiap.Services;
using fiap.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fiap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemaforoController : ControllerBase
    {
        private readonly ISemaforoService _service;
        private readonly IMapper _mapper;

        public SemaforoController(ISemaforoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SemaforoPaginacaoReferenciaViewModel>> Get([FromQuery] int referencia = 0, [FromQuery] int tamanho = 10)
        {
            var semaforos = _service.ListarSemaforosUltimaReferencia(referencia, tamanho);
            if (!semaforos.Any())
                return NotFound("Nenhum semáforo encontrado.");

            var viewModelList = _mapper.Map<IEnumerable<SemaforoViewModel>>(semaforos);

            var viewModel = new SemaforoPaginacaoReferenciaViewModel
            {
                Semaforos = viewModelList,
                PageSize = tamanho,
                Ref = referencia,
                NextRef = viewModelList.Last().SemaforoId
            };

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,user")]
        public ActionResult<SemaforoViewModel> Get(int id)
        {
            var semaforo = _service.ObterSemaforoPorId(id);
            if (semaforo == null)
                return NotFound($"Semáforo com ID {id} não encontrado.");

            var viewModel = _mapper.Map<SemaforoViewModel>(semaforo);
            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Post([FromBody] SemaforoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var semaforo = _mapper.Map<SemaforoModel>(viewModel);
            _service.CriarSemaforo(semaforo);
            return CreatedAtAction(nameof(Get), new { id = semaforo.SemaforoId }, viewModel);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Put(int id, [FromBody] SemaforoViewModel viewModel)
        {
            if (id != viewModel.SemaforoId)
                return BadRequest("O ID fornecido na URL não corresponde ao ID do recurso.");

            var semaforoExistente = _service.ObterSemaforoPorId(id);
            if (semaforoExistente == null)
                return NotFound($"Semáforo com ID {id} não encontrado.");

            _mapper.Map(viewModel, semaforoExistente);
            _service.AtualizarSemaforo(semaforoExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var semaforoExistente = _service.ObterSemaforoPorId(id);
            if (semaforoExistente == null)
                return NotFound($"Semáforo com ID {id} não encontrado.");

            _service.DeletarSemaforo(id);
            return NoContent();
        }
    }
}
