using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Knights.Models;

namespace Knights.Repositories
{
  public class KnightsRepository
  {
    private readonly IDbConnection _db;

    public KnightsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Knight> GetAll()
    {
      string sql = @"
      SELECT * FROM knights;
      ";
      return _db.Query<Knight>(sql).ToList();
    }
    internal Knight GetById(int knightId)
    {
      string sql = @"
      SELECT
      k.*,
      c.*
      FROM knights k
      JOIN castles c on k.castleId = c.id
      WHERE k.id = @knightId;
      ";
      return _db.Query<Knight, Castle, Knight>(sql, (k, c) =>
      {
        k.Castle = c;
        return k;
      }, new{knightId}).FirstOrDefault();
    }

    internal Knight Post(Knight knightData)
    {
      string sql = @"
      INSERT INTO knights(knightName, castleId)
      VALUES(@Knightname, @CastleId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, knightData);
      knightData.Id = id;
      return knightData;
    }
  }
}