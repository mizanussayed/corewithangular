using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Contollers;

public class FundCollectionController : Controller
{

    IServices<FundCollection> services = null;
    IServices<Session> isession = null;
    public FundCollectionController()
    {
        services = new Services<FundCollection>();
        isession = new Services<Session>();
    }

    public IActionResult Index()
    {
        //Bag.session = isession.GettAll();
        return Json(services.GettAll());
    }


    [HttpPost]
    public IActionResult Create([FromBody] FundCollection model)
    {
        services.Insert(model);
        return Ok();
    }


    public IActionResult Edit([FromBody] FundCollection model)
    {
        services.Update(model);
        return Ok();
    }

    [HttpPost]
    public IActionResult Delete(int ReceiptNumber)
    {
        services.Delele(ReceiptNumber);
        return Ok();
    }
}
