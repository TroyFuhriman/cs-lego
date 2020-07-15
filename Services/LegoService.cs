using System;
using System.Collections.Generic;
using Legos.Models;
using Legos.Repository;

namespace Legos.Services
{
  public class LegoService
  {
    private readonly LegoRepository _repo;
    public LegoService(LegoRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Lego> Get()
    {
      return _repo.GetAll();
    }

    internal Lego Get(int id)
    {
      return _repo.GetById(id);
    }

    internal Lego Create(Lego newLego)
    {
      int id = _repo.Create(newLego);
      newLego.Id = id;
      return newLego;
    }

    internal object Edit(Lego editLego)
    {
      Lego original = Get(editLego.Id);
      original.Color = editLego.Color.Length > 0 ? editLego.Color : original.Color;
      original.Description = editLego.Description.Length > 0 ? editLego.Description : original.Description;
      original.size = editLego.size.Length > 0 ? editLego.size : original.size;
      return _repo.Edit(original);
    }

    internal object Delete(int id)
    {
      Lego exists = Get(id);
      _repo.Delete(id);
      return $"{exists.Description} has been deleted";
    }
  }
}