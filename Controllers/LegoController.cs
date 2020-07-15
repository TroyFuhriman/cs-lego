using System;
using System.Collections.Generic;
using Legos.Models;
using Legos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Legos.Controller
{
  [ApiController]
  [Route("api/[controller]")]

  public class LegoController : ControllerBase
  {
    private readonly LegoService _service;
    public LegoController(LegoService service)
    {
      _service = service;
    }

    //GetALl
    [HttpGet]
    public ActionResult<IEnumerable<Lego>> Get()
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
    public ActionResult<Lego> Get(int id)
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
    public ActionResult<Lego> Create([FromBody] Lego newLego)
    {
      try
      {
        return Ok(_service.Create(newLego));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    //PUT
    [HttpPut("{id}")]
    public ActionResult<Lego> Edit([FromBody] Lego editLego, int id)
    {
      try
      {
        editLego.Id = id;
        return Ok(_service.Edit(editLego));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    //DELETE
    [HttpDelete("{id}")]
    public ActionResult<Lego> Delete(int id)
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