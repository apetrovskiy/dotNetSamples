namespace MyWebService.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MyWebService.Repositories;
using MyWebService.Models;
using MyWebService.Data;

[ApiController]
[Route("[controller]")]
public class PreferencesController : ControllerBase
{
    private readonly AppDbContext _context;

    public PreferencesController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets all preferences.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Preference>>> GetPreferences()
    {
        return Ok(await _context.Preferences.ToListAsync());
    }
}
