using LaboratorieAPI.Interfaces;
using LaboratorieAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ISampleRepository _repository;

        public SampleController(ISampleRepository repository)
        {
            _repository = repository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<Sample>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Sample> GetById(int id)
        {
            var item = _repository.GetById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Sample> Create([FromBody] Sample item)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.Name) || item.Temperature < -80)
                return BadRequest();

            var newSample = new Sample(0, item.Name, DateTime.UtcNow, item.Temperature);
            var created = _repository.Add(newSample);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
