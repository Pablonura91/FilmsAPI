using Application.Films.Interfaces;
using AutoMapper;
using DTOs.Genero;
using Microsoft.AspNetCore.Mvc;

namespace API.Films.Controller
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneroService _generoService;
        private readonly IMapper _mapper;

        public GenerosController(IGeneroService generoService, IMapper mapper)
        {
            this._generoService = generoService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneroGetAllDTO>>> Get()
        {
            var generos = await _generoService.GetAllAsync();
            var dtos = _mapper.Map<List<GeneroGetAllDTO>>(generos);
            return Ok(dtos);
        }
    }
}
