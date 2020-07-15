using System.Collections.Generic;
using System.Data;
using Dapper;
using legos.Models;
using Legos.Models;

namespace Legos.Repository
{
  public class KitLegoRepository
  {
    private readonly IDbConnection _db;
    public KitLegoRepository(IDbConnection db)
    {
      _db = db;
    }
    internal DTOKitLego GetById(int Id)
    {
      string sql = "SELECT * FROM kitlego WHERE id = @Id";
      return _db.QueryFirstOrDefault<DTOKitLego>(sql, new { Id });
    }
    internal int Create(DTOKitLego newDTO)
    internal void Delete(int Id)
    {
      string sql = "DELETE FROM kitlego WHERE id = @Id";
      _db.Execute(sql, new { Id });
    }
    internal IEnumerable<KitLego> GetLegoByKitId(int id)
    {
      string sql = @"
      SELECT 
        l.*,
        kl.id as kitLegoId
        FROM kitlego kl
        INNER JOIN ingredients l ON l.id = kl.legoId
        WHERE(kl.kitId = @id) 
      ";
      return _db.Query<KitLego>(sql, new { id });
    }
  }
}