using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Legos.Models;

namespace Legos.Repository
{
  public class LegoRepository
  {
    public readonly IDbConnection _db;
    public LegoRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Lego> GetAll()
    {
      string sql = "SELECT * FROM lego";
      return _db.Query<Lego>(sql);
    }

    internal Lego GetById(int Id)
    {
      string sql = "SELECT * FROM lego WHERE id = @Id";
      return _db.QueryFirstOrDefault<Lego>(sql, new { Id });
    }

    internal int Create(Lego newLego)
    {
      string sql = @"
      INSERT INTO lego
      (description, color, size)
      VALUES
      (@Description, @Color, @Size);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newLego);
    }

    internal void Delete(int Id)
    {
      string sql = "DELETE FROM lego WHERE id = @Id";
      _db.Execute(sql, new { Id });
    }

    internal Lego Edit(Lego original)
    {
      string sql = @"
      UPDATE lego
      SET
          description = @Description,
          color = @Color,
          size = @Size
          WHERE id = @Id;
          SELECT * FROM lego WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Lego>(sql, original);
    }
  }
}