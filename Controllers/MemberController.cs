using BackEnd.Models;
using BackEnd.Services;

using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Contollers;

public class MemberController : Controller
{

    IServices<Member> services = null;
    public MemberController()
    {
        services = new Services<Member>();
    }

    public IActionResult Index()
    {
        return Json(services.GettAll());
    }


    [HttpPost]
    public IActionResult Create([FromBody] Member model)
    {
        //model.Picture=  file.FileName;
        services.Insert(model);
        return Ok();

    }

    [HttpGet]
    public IActionResult Single([FromRoute] int id)
    {
        return Json(services.GetById(id));

    }

    public IActionResult Edit([FromBody] Member model)
    {
        services.Update(model);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {

        services.Delele(id);
        return Ok(id);
    }
}
