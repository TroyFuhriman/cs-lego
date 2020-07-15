using System;
using System.Collections.Generic;
using legos.Models;
using Legos.Models;
using Legos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Legos.Controller
{
  [ApiController]
  [Route("api/[controller]")]

  public class KitLegoController : ControllerBase
  {
    private readonly KitLegoService _service;
    public KitLegoController(KitLegoService service)
    {
      _service = service;
    }

    //POST
    [HttpPost]
    public ActionResult<DTOKitLego> Create([FromBody] DTOKitLego newDTOKitLego)
    {
      try
      {
        return Ok(_service.Create(newDTOKitLego));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    //DELETE
    [HttpDelete("{id}")]
    public ActionResult<DTOKitLego> Delete(int id)
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