using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using StickerShop.Models;
using StickerShop.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StickerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StickersController : ControllerBase
    {
        private readonly iStickerService stickerService;

        public StickersController(iStickerService stickerService) 
        {
            this.stickerService = stickerService;
        }

        // GET: api/<StickersController>
        [HttpGet]
        public ActionResult<List<Sticker>> Get()
        {
            return new JsonResult(stickerService.GetStickers());
        }

        // GET api/<StickersController>/5
        [HttpGet("{id}")]
        public ActionResult<Sticker> Get(int id)
        {
            var sticker = stickerService.GetSticker(id);

            if(sticker == null)
            {
                return NotFound($"The sticker with id {id} was not found");
            }

            return new JsonResult(sticker);
        }

        // POST api/<StickersController>
        [HttpPost]
        public ActionResult<Sticker> Post([FromBody] Sticker sticker)
        {
            stickerService.CreateSticker(sticker);

            return CreatedAtAction(nameof(Get), new {id = sticker.StickerId}, sticker);
        }

        // PUT api/<StickersController>/5
        [HttpPut("{id}")]
        public ActionResult<Sticker> Put(int id, [FromBody] Sticker sticker)
        {
            var existingSticker =stickerService.GetSticker(id);

            if (existingSticker == null)
            {
                return NotFound($"The sticker with id {id} was not found");
            }

            stickerService.UpdateSticker(id, sticker);

            return NoContent();
        }

        // DELETE api/<StickersController>/5
        [HttpDelete("{id}")]
        public ActionResult<Sticker> Delete(int id)
        {
            var existingSticker = stickerService.GetSticker(id);

            if (existingSticker == null)
            {
                return NotFound($"The sticker with id {id} was not found");
            }

            stickerService.DeleteSticker(existingSticker.StickerId);
            return Ok($"The sticker with id {id} was successfully deleted");
        }
    }
}
