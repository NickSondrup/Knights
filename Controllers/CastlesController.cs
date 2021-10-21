using System.Collections.Generic;
using Knights.Models;
using Knights.Services;
using Microsoft.AspNetCore.Mvc;

namespace Knights.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CastlesController : ControllerBase
  {
    private readonly CastlesService _castlesService;
    public CastlesController(CastlesService castlesService)
    {
      _castlesService = castlesService;
    }

    [HttpPost]
    public ActionResult<Castle> CreateCastle([FromBody] Castle castleData)
    {
      try
      {
        var castle = _castlesService.CreateCastle(castleData);
        return Ok(castle);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<List<Castle>> GetCastles()
    {
      try
      {
        var castles = _castlesService.Get();
        return Ok(castles);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{castleId}")]
    public ActionResult<Castle> GetCastlesById(int castleId)
    {
      try
      {
        var castle = _castlesService.Get(castleId);
        return Ok(castle);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{castleId}")]
    public ActionResult<Castle> EditCastle(int castleId, [FromBody] Castle castleData)
    {
      try
      {
        var castle = _castlesService.Edit(castleId, castleData);
        return Ok(castle);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}