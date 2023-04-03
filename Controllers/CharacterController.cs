using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegendsOfArdjorda.Models;
using LegendsOfArdjorda.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LegendsOfArdjorda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // GET: api/Character
        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            return _characterService.Get();
        }

        // GET: api/Character/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Character> Get(string id)
        {
            var character = _characterService.Get(id);
            if (character == null) return NotFound($"Character with id {id} not found");
            return character;
        }

        // POST: api/Character
        [HttpPost]
        public ActionResult<Character> Post([FromBody] Character character)
        {
            _characterService.Create(character);
            return CreatedAtAction(nameof(Get), new {id = character.Id}, character);

        }

        // PUT: api/Character/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Character character)
        {
            var existingCharacter = _characterService.Get(id);
            if (existingCharacter == null) return NotFound($"Character with id {id} not found");
            
            _characterService.Update(id, character);
            return NoContent();
        }

        // DELETE: api/Character/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var character = _characterService.Get(id);
            if (character == null) return NotFound($"Character with id {id} not found");
            
            _characterService.Remove(id);
            return Ok($"Character with id: {id} deleted");
        }
    }
}
