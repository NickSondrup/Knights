using System.Collections.Generic;
using Knights.Models;
using Knights.Repositories;

namespace Knights.Services
{
  public class CastlesService
  {
    private readonly CastlesRepository _cr;

    public CastlesService(CastlesRepository cr)
    {
      _cr = cr;
    }

    public Castle CreateCastle(Castle castleData)
    {
      return _cr.CreateCastle(castleData);
    }

    public List<Castle> Get()
    {
      return _cr.Get();
    }
    public Castle Get(int castleId)
    {
      var castle = _cr.Get(castleId);
      if (castle == null)
      {
          throw new System.Exception("Invalid Castle Id or something");
      }
      return castle;
    }

    public Castle Edit(int castleId, Castle castleData)
    {
      var castle = Get(castleId);

      castle.Name = castleData.Name ?? castle.Name;
      castle.Kingdom = castleData.Kingdom ?? castle.Kingdom;

      _cr.Edit(castleId, castleData);
      return castle;
    }
  }
}