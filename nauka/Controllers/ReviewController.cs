using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using nauka.Dto;
using nauka.Interfaces;
using nauka.Modele;

namespace nauka.Controllers
{


    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public ActionResult GetReviews()
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviews);
        }


        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public ActionResult GetReview(int reviewId)
        { 
            if (! _reviewRepository.ReviewExists(reviewId))
                return NotFound();

            var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(reviewId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(review);
        
        }
        [HttpGet("pokemon/{pokemonId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsForAPokemon(int pokemonId)
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewsOfAPokemon(pokemonId));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(reviews);
        
        }

    }
}
