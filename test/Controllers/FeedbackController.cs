using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test.Models;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace test.Controllers;

public class FeedbackController : Controller
{
    public readonly FACULTYContext _dbContext;

    public FeedbackController(FACULTYContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Login()
    {   
        string fileName= "login.json";
        List<Admin> admin = _dbContext.Admins.ToList();
        string jsonString = JsonSerializer.Serialize(admin);
        System.IO.File.WriteAllText(fileName, jsonString);

        return View();
    }

    [HttpPost]
    public IActionResult Login(Admin admin)
    {
        string jsonstr = System.IO.File.ReadAllText("login.json");
        List<Admin> list = JsonSerializer.Deserialize<List<Admin>>(jsonstr);

        foreach(Admin a in list){
            if(admin.User==a.User && admin.Pass==a.Pass){
                return RedirectToAction("Show");
            }
        }
        return View();
    }

    public IActionResult Show()
    {   
        List<Feedback> feed=_dbContext.Feedbacks.ToList();
        this.ViewData["fee"]=feed;
        return View();
    }

    public IActionResult Delete(int id)
    {   
        _dbContext.Feedbacks.Remove(_dbContext.Feedbacks.Find(id));
        _dbContext.SaveChanges();
        return RedirectToAction("Show");
    }



    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Feedback empform)
    {
        _dbContext.Feedbacks.Add(empform);
        _dbContext.SaveChanges();
        return RedirectToAction("Show");
    }











    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
