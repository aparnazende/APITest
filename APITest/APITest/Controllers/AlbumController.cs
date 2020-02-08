using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interface;

namespace APITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly ILogger<AlbumController> logger;
        private readonly IAlbumService albumService;
        public AlbumController(ILogger<AlbumController> _logger, IAlbumService _albumService)
        {
            logger = _logger;
            albumService = _albumService;
        }
        /// <summary>
        /// Methods
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int albumId=1)
        {
             
            logger.LogDebug($"Entered in the controller with albumid:{albumId}");
            try
            {
                if (albumId == 0)
                {
                    logger.LogDebug($"Invalid albumId:{albumId}");
                    return BadRequest("Invalid album Id");
                }
                var albumDetails = albumService.AlbumDetails(albumId);
                if (albumDetails != null)
                {
                    //return Ok(albumDetails);
                    return Ok(albumDetails);

                }
                else
                {
                    logger.LogDebug($"Album not found with alumId:{albumId}");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception while fecthing the request. Exception: {ex.Message},Stack Trace:{ex.StackTrace}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
       
    }
}
