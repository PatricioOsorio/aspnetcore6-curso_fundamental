using CursoFundamental.Data;
using CursoFundamental.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CursoFundamental.Controllers
{
  public class HomeController : Controller
  {
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View(_context.User.ToList());
    }

    [HttpGet]
    public IActionResult CreateUser()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
      if (ModelState.IsValid)
      {
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
      }

      return View();
    }

    [HttpGet]
    public IActionResult UpdateUser(int? id)
    {
      if (id == null) return NotFound();

      var user = _context.User.Find(id);

      if (user == null) return NotFound();

      return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateUser(User user)
    {
      if (ModelState.IsValid)
      {
        _context.Update(user);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
      }

      return View();
    }

    [HttpGet]
    public IActionResult DeleteUser(int? id)
    {
      if (id == null) return NotFound();

      var user = _context.User.Find(id);

      if (user == null) return NotFound();

      return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUserConfirmed(int? id)
    {
      var user = await _context.User.FindAsync(id);

      if (user == null) return NotFound();

      _context.User.Remove(user);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}