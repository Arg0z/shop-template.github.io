using Microsoft.AspNetCore.Mvc;
using StickerShop.Models;
using StickerShop.Services;

namespace StickerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : Controller
    {
        private iStickerService _stickerService;

        public ReactController(iStickerService _stickersService) 
        {
            this._stickerService = _stickersService;
        }

        [HttpGet]
        public IActionResult GetAllStickers()
        {
            return new JsonResult(_stickerService.GetStickers());
        }
    }
}
