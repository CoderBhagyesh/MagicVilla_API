using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicVilla_API.Data;
using MAGICVILLA_API.Models;
using MAGICVILLA_API.Models.Domain;
using MAGICVILLA_API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillasApiController : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        public VillasApiController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        [HttpGet]
        public IActionResult GetVillas()
        {
            return Ok(_db.Villas.ToList());
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = _db.Villas.FirstOrDefault(vo => vo.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]



        public ActionResult CreateVilla(Villa villa)
        {
            if (villa == null)
            {
                return BadRequest();
            }

            // villa.Id = _db.Villas.OrderByDescending(vo => vo.Id).FirstOrDefault().Id + 1;

           _db.Villas.Add(villa);
           _db.SaveChanges();

            // return Ok();
            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = _db.Villas.FirstOrDefault(vo => vo.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            _db.Villas.Remove(villa);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public IActionResult PutVilla(int id, [FromBody] VillaDTO villa)
        {
            if(id==0 || villa == null)
            {
                return BadRequest();
            }

            var existingVilla = _db.Villas.FirstOrDefault(vo => vo.Id==id);

            if (existingVilla == null)
            {
                return BadRequest();
            }

            existingVilla.Name = villa.Name;

            return NoContent();
        }

    }
}