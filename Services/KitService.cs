using System;
using System.Collections.Generic;
using Legos.Models;
using Legos.Repository;

namespace Legos.Services
{
  public class KitService
  {
    private readonly KitRepository _repo;
    public KitService(KitRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Kit> Get()
    {
      return _repo.GetAll();
    }

    internal Kit Get(int id)
    {
      return _repo.GetById(id);
    }

    internal Kit Create(Kit newKit)
    {
      int id = _repo.Create(newKit);
      newKit.Id = id;
      return newKit;
    }

    internal object Edit(Kit editKit)
    {
      Kit original = Get(editKit.Id);
      original.Description = editKit.Description.Length > 0 ? editKit.Description : original.Description;
      original.Name = editKit.Name.Length > 0 ? editKit.Name : original.Name;
      original.Price = editKit.Price > 0 ? editKit.Price : original.Price;
      return _repo.Edit(original);
    }

    internal object Delete(int id)
    {
      Kit exists = Get(id);
      _repo.Delete(id);
      return $"{exists} has been deleted";
    }
  }
}