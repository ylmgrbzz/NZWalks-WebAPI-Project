using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks_WebAPI__Project.Data;
using NZWalks_WebAPI__Project.Models.Domain;
using NZWalks_WebAPI__Project.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NZWalks_WebAPI__Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;

        public RegionsController(NZWalksDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetRegions()
        {
            var regions = _context.Regions.ToList();
            var regionDtos = new List<RegionDto>();
            foreach (var region in regions)
            {
                var regionDto = new RegionDto
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                };
                regionDtos.Add(regionDto);
            }
            return Ok(regions);
        }

        [HttpGet("{id}")]
        public IActionResult GetRegionById(Guid id)
        {
            var region = _context.Regions.FirstOrDefault(x => x.Id == id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDto = new RegionDto
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };
            return Ok(region);
        }

        [HttpPost]
        public IActionResult CreateRegion([FromBody] AddRegionRequestDto AddRegionRequestDto)
        {
            var region = new Region
            {
                Name = AddRegionRequestDto.Name,
                Code = AddRegionRequestDto.Code,
                RegionImageUrl = AddRegionRequestDto.RegionImageUrl
            };
            _context.Regions.Add(region);
            _context.SaveChanges();

            var regionDto = new RegionDto
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateRegion(Guid id, [FromBody] Region region)
        {
            if (id != region.Id)
            {
                return BadRequest();
            }
            _context.Regions.Update(region);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRegion(Guid id)
        {
            var region = _context.Regions.Find(id);
            if (region == null)
            {
                return NotFound();
            }
            _context.Regions.Remove(region);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
