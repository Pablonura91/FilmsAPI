using Application.Films.Interfaces;
using AutoMapper;
using Domain.Films.Entities;
using DTOs.Genero;
using Microsoft.AspNetCore.Mvc;

namespace API.Films.Controller
{
    [ApiController]
    [Route("api/genero")]
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GeneroDTO>> GetById(int id)
        {
            var genero = await _generoService.GetByIdAsync(id);

            if (genero == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<GeneroDTO>(genero);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<GeneroDTO>> Post([FromBody] GeneroCreateDTO generoCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genero = _mapper.Map<Genero>(generoCreateDto);
            var result = await _generoService.AddAsync(genero);

            var generoDTO = _mapper.Map<GeneroDTO>(result);
            return CreatedAtAction(nameof(GetById), new { id = generoDTO.Id }, generoDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GeneroDTO>> Put(int id, [FromBody] GeneroUpdateDTO generoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genero = await _generoService.GetByIdAsync(id);
            if (genero == null)
            {
                return NotFound();
            }

            _mapper.Map(generoDto, genero);
            var result = await _generoService.UpdateAsync(genero);
            var resultMapped = _mapper.Map<GeneroDTO>(genero);
            return Ok(resultMapped);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genero = await _generoService.GetByIdAsync(id);
            if (genero == null)
            {
                return NotFound();
            }

            await _generoService.DeleteAsync(genero);
            return NoContent();
        }
    }
}
