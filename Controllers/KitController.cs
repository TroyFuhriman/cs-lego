using System;
using System.Collections.Generic;
using Legos.Models;
using Legos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Legos.Controller
{
  [ApiController]
  [Route("api/[controller]")]

  public class KitController : ControllerBase
  {
    private readonly KitService _service;
    public KitController(KitService service)
    {
      _service = service;
    }

    //GetALl
    [HttpGet]
    public ActionResult<IEnumerable<Kit>> Get()
    {
      try
      {
        return Ok(_service.Get());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    //GetById
    [HttpGet("{id}")]
    public ActionResult<Kit> Get(int id)
    {
      try
      {
        return Ok(_service.Get(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    //POST
    [HttpPost]
    public ActionResult<Kit> Create([FromBody] Kit newKit)
    {
      try
      {
        return Ok(_service.Create(newKit));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    //PUT
    [HttpPut("{id}")]
    public ActionResult<Kit> Edit([FromBody] Kit editKit, int id)
    {
      try
      {
        editKit.Id = id;
        return Ok(_service.Edit(editKit));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    //DELETE
    [HttpDelete("{id}")]
    public ActionResult<Kit> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }

}