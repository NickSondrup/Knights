using System.Collections.Generic;
using Knights.Models;
using Knights.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Knights.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class knightsController : ControllerBase
  {
    private readonly KnightsService _knightsService;

    public knightsController(KnightsService knightsService)
    {
      _knightsService = knightsService;
    }

    [HttpGet]
    public ActionResult<List<Knight>> GetAll()
    {
      try
      {
        return Ok(_knightsService.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{knightId}")]
    public ActionResult<Knight> GetById(int knightId)
    {
      try
      {
        return Ok(_knightsService.GetById(knightId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Knight> Post([FromBody] Knight knightData)
    {
      try
      {
        Knight createdKnight = _knightsService.Post(knightData);
        return createdKnight;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}