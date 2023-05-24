using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks_WebAPI__Project.Data;
using NZWalks_WebAPI__Project.Models.Domain;
using System;
using System.Collections.Generic;

namespace NZWalks_WebAPI__Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        public RegionController(NZWalksDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetRegions()
        {
            //var regions = new List<Region>
            //{
            //    new Region {Id = Guid.NewGuid(), Name = "Northland", Code = "AKL", RegionImageUrl= "https://pbs.twimg.com/profile_images/1654575412482121729/VOBGrzvy_400x400.jpg"},
            //    new Region {Id = Guid.NewGuid(), Name = "Northland123", Code = "AKL123", RegionImageUrl= "https://pbs.twimg.com/profile_images/1654575412482121729/VOBGrzvy_400x400.jpg"}
            //};
            var regions = _context.Regions.ToList();
            return Ok(regions);
        }
    }
}
