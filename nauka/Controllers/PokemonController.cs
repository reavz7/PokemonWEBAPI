using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using nauka.Data;
using nauka.Interfaces;
using nauka.Modele;
using System.Runtime.CompilerServices;

namespace nauka.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly DataContext _context;

        public PokemonController(IPokemonRepository pokemonRepository, DataContext context)
        {
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {

            var pokemons = _pokemonRepository.GetPokemons();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemons);

        }
    }
}
