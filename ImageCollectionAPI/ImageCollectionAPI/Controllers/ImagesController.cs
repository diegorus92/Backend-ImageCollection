using ImageCollectionAPI_BL.Dtos;
using ImageCollectionAPI_BL.Services;
using ImageCollectionAPI_DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageCollectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }





        // GET: api/<ImagesController>
        [HttpGet]
        public IEnumerable<Image> Get()
        {
            return _imageService.GetAll();
        }

        // GET api/<ImagesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(long id)
        {
            Image? request = _imageService.GetImage(id);

            if(request == null)
                return NotFound();
            return Ok(request);
        }


        // POST api/<ImagesController>
        [HttpPost]
        public async Task<ActionResult<String>> Post([FromForm] ImageDTO image)
        {
            if(_imageService.CreateImage(image))
                return Ok("Image uploaded");
            return BadRequest("Error during image upload or incorrect extension");
        }


        // PUT api/<ImagesController>/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(long id, string newName, string newDescription)
        {
            if (_imageService.UpdateImage(id, newName, newDescription))
                return Ok("Image Updated");
            return NotFound();
        }

        // DELETE api/<ImagesController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(long id)
        {
            if (_imageService.DeleteImage(id))
                return Ok("Image deleted");
            return NotFound();
        }
    }
}
