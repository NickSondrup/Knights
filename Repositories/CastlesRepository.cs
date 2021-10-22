using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Knights.Models;

namespace Knights.Repositories
{
  public class CastlesRepository
  {
    private readonly IDbConnection _db;

    public CastlesRepository(IDbConnection db)
    {
      _db = db;
    }

    public Castle CreateCastle(Castle castleData)
    {
      var sql = @"
      INSERT INTO castles(
        name,
        kingdom,
        creatorId
      )
      VALUES (
        @Name,
        @Kingdom,
        @CreatorId
      );
      SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, castleData);
      castleData.Id = id;
      return castleData;
    }

    public List<Castle> Get()
    {
      return _db.Query<Castle>("SELECT * FROM castles").ToList();
    }

    public Castle Get(int castleId)
    {
      // return _db.QueryFirstOrDefault<Castle>("SELECT * FROM castles WHERE id = @castleId", new { castleId });
      string sql = @"
        SELECT
        c.*,
        a.*
        FROM castles c
        JOIN accounts a on c.creatorId = a.id
        WHERE c.id = @castleId;
      ";
      return _db.Query<Castle, Account, Castle>(sql, (c, a) =>
      {
        c.Creator = a;
        return c;
      }, new{castleId}).FirstOrDefault();
    }

    public Castle Edit(int castleId, Castle castleData)
    {
       castleData.Id = castleId;
      var sql = @"
      UPDATE castles
      SET
        name = @Name,
        kingdom = @Kingdom
      WHERE id = @Id
      ";

      var rowsAffected = _db.Execute(sql, castleData);

      if (rowsAffected > 1)
      {
        throw new System.Exception("the update failed");
      }
      if (rowsAffected == 0)
      {
        throw new System.Exception("The update failed");
      }
      return castleData;
    }

    internal void DeleteCastle(int castleId)
    {
      string sql = "DELETE FROM castles WHERE id = @castleId LIMIT 1;";
      var rowsAffected = _db.Execute(sql, new {castleId});
      if(rowsAffected == 0)
      {
        throw new Exception("something went wrong yo");
      }
    }
  }
}