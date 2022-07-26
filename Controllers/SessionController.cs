using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Contollers;
public class SessionController : Controller
{

    IServices<Session> services = null;
    public SessionController()
    {
        services = new Services<Session>();
    }
    public IActionResult Index()
    {
        return Json(services.GettAll());
    }

    [HttpPost]
    public IActionResult Create([FromBody] Session model)
    {
        services.Insert(model);
        return Ok(model);
    }


    [HttpGet]
    public IActionResult Single([FromRoute] int id)
    {
        return Json(services.GetById(id));
    }

    [HttpPut]
    public IActionResult Edit([FromBody] Session model)
    {
        services.Update(model);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        services.Delele(id);
        return Ok();

    }
}
