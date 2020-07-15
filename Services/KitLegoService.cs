using System;
using System.Collections.Generic;
using legos.Models;
using Legos.Models;
using Legos.Repository;

namespace Legos.Services
{
  public class KitLegoService
  {
    private readonly KitLegoRepository _repo;
    public KitLegoService(KitLegoRepository repo)
    {
      _repo = repo;
    }

    internal DTOKitLego Get(int id)
    {
      return _repo.GetById(id);
    }

    internal DTOKitLego Create(DTOKitLego newKitLego)
    {
      int id = _repo.Create(newKitLego);
      newKitLego.Id = id;
      return newKitLego;
    }

    internal object Delete(int id)
    {
      DTOKitLego exists = Get(id);
      _repo.Delete(id);
      return exists;
    }
    public IEnumerable<KitLego> GetLegoByKitId(int id)
    {
      return _repo.GetLegoByKitId(id);
    }
  }
}