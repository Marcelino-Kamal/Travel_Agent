﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgent.Data;

namespace TravelAgent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context) { 
        
            _context = context;
        
        }

        [HttpGet("TravelPackages")]
        public async Task<IActionResult> GetAll()
        {
            var packages = await _context.TravelPackages.ToListAsync();
            return Ok(packages);
            
        }
        [HttpGet("Search")]
        public async Task<IActionResult> search([FromQuery]string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Cant be empty");
            }
            var res = await _context.TravelPackages.Where(p => EF.Functions.Like(p.Name, $"%{name.ToLower()}%")).ToListAsync();

            return Ok(res);
        }

    }
}
