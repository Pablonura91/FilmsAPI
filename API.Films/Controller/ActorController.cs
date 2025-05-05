using AutoMapper;
using Domain.Films.Entities;
using Domain.Films.Interfaces;
using DTOs.Actor;
using Microsoft.AspNetCore.Mvc;

namespace API.Films.Controller
{
    [ApiController]
    [Route("api/actor")]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _actorServices;
        private readonly IMapper _mapper;

        public ActorController(IActorRepository actorServices, IMapper mapper)
        {
            this._actorServices = actorServices;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorGetAllDTO>>> Get()
        {
            var result = await _actorServices.GetAllAsync();
            var dtos = _mapper.Map<List<ActorGetAllDTO>>(result);
            return Ok(dtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ActorDTO>> GetById(int id)
        {
            var actor = await _actorServices.GetByIdAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<ActorDTO>(actor);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<ActorDTO>> Post([FromForm] ActorCreateDTO actorCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actor = _mapper.Map<Actor>(actorCreateDto);
            var result = await _actorServices.AddAsync(actor);

            var actorDTO = _mapper.Map<ActorDTO>(result);
            return CreatedAtAction(nameof(GetById), new { id = actorDTO.Id }, actorDTO);

            return null;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ActorDTO>> Put(int id, [FromForm] ActorUpdateDTO actorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actor = await _actorServices.GetByIdAsync(id);
            if (actor == null)
            {
                return NotFound();
            }

            _mapper.Map(actorDto, actor);
            var result = await _actorServices.UpdateAsync(actor);
            var resultMapped = _mapper.Map<ActorDTO>(actor);
            return Ok(resultMapped);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var actor = await _actorServices.GetByIdAsync(id);
            if (actor == null)
            {
                return NotFound();
            }

            await _actorServices.DeleteAsync(actor);
            return NoContent();
        }
    }
}
