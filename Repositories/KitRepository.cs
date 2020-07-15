using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Legos.Models;

namespace Legos.Repository
{
  public class KitRepository
  {
    public readonly IDbConnection _db;
    public KitRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Kit> GetAll()
    {
      string sql = "SELECT * FROM kit";
      return _db.Query<Kit>(sql);
    }

    internal Kit GetById(int Id)
    {
      string sql = "SELECT * FROM kit WHERE id = @Id";
      return _db.QueryFirstOrDefault<Kit>(sql, new { Id });
    }

    internal int Create(Kit newKit)
    {
      string sql = @"
      INSERT INTO kit
      (description, color, size)
      VALUES
      (@Description, @Color, @Size);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKit);
    }

    internal void Delete(int Id)
    {
      string sql = "DELETE FROM kit WHERE id = @Id";
      _db.Execute(sql, new { Id });
    }

    internal Kit Edit(Kit original)
    {
      string sql = @"
      UPDATE tacos
      SET
          name = @Name
          description = @Description,
          price = @Price
        WHERE id = @Id;
        SELECT * FROM kit WHERE id = @ID;";
      return _db.QueryFirstOrDefault<Kit>(sql, original);
    }
  }
}