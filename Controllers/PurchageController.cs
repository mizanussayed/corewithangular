using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BackEnd.Contollers;


public class PurchageController : Controller
{
    IServices<Purchage> services = null;
    IServices<Session> isession = null;
    public PurchageController()
    {
        services = new Services<Purchage>();
        isession = new Services<Session>();
    }


    public IActionResult Index()
    {

        var s = isession.GettAll();
        var p = services.GettAll();
        var joined = from Item1 in s
                     join Item2 in p
                     on Item1.SessionNumber equals Item2.SessionNumber // join on some property
                     select new { Item2.SerialNumber, Item2.Dated, Item2.Amount, Item2.Items, Item1.SessionName };

        return Json(joined);
    }


    [HttpPost]
    public IActionResult Create([FromBody] Purchage model) //need to work
    {

        services.Insert(model);
        return Ok();

    }


    [HttpGet]
    public IActionResult Single([FromRoute] int id)
    {
        return Json(services.GetById(id));

    }

    public IActionResult Edit([FromBody] Purchage model)
    {
        services.Update(model);
        return Ok();
    }


    [HttpDelete]
    public IActionResult Delete(int Id)
    {
        services.Delele(Id);
        return Ok();

    }
}
